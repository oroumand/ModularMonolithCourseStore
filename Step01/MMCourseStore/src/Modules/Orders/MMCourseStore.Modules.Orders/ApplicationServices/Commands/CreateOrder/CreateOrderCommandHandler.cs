using IdGen;
using MediatR;
using MMCourseStore.Framework.Commands;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Framework.Services.DateTimeServices;
using MMCourseStore.Framework.Services.IdGeneratorServices;
using MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetById;
using MMCourseStore.Modules.Orders.Data;
using MMCourseStore.Modules.Orders.Domain;

namespace MMCourseStore.Modules.Orders.ApplicationServices.Commands.CreateOrder;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, long>
{
    private readonly Framework.Services.IdGeneratorServices.IIdGenerator<long> idGenerator;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly OrderDbContext context;
    private readonly ISender sender;

    public CreateOrderCommandHandler(Framework.Services.IdGeneratorServices.IIdGenerator<long> idGenerator,
                                     IDateTimeProvider dateTimeProvider,
                                     OrderDbContext context,
                                     ISender sender)
    {
        this.idGenerator = idGenerator;
        this.dateTimeProvider = dateTimeProvider;
        this.context = context;
        this.sender = sender;
    }
    public async Task<Result<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = new Order(idGenerator.GetId(), request.studentId, dateTimeProvider.GetUtcNow());
        //1. as input
        //2. query from db
        //3. HTTP API
        //4. Direct Call To Service 
        //5. Call using Mediator
        //6. Materialized view/ or View
        //7. Call using Mediator and shared kernel
        var course = await sender.Send(new GetByIdCourseQuery(request.courseId));
        order.AddItem(idGenerator.GetId(), request.courseId, 1, course.Value.Price);
        context.Orders.Add(order);
        await context.SaveChangesAsync(cancellationToken);
        return Result<long>.Success(order.Id);

    }
}
