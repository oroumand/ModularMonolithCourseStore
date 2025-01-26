using Microsoft.EntityFrameworkCore;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Framework.Queries;
using MMCourseStore.Modules.Students.Data;

namespace MMCourseStore.Modules.Students.ApplicationServices.Queries.GetAll;
internal class GetAllStudentQueryHandler(StudentDbContext context) : IQueryHandler<GetAllStudentQuery, List<GetAllStudentResponse>>
{
    public async Task<Result<List<GetAllStudentResponse>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
        List<GetAllStudentResponse> result = await context.Students.Select(c => new GetAllStudentResponse
        (
            c.Id,
             c.FirstName,
            c.LastName
        )).ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
