using Microsoft.EntityFrameworkCore;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Framework.Queries;
using MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
using MMCourseStore.Modules.Courses.Data;
using MMCourseStore.Modules.Sharedkernels.Courses.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Courses.IntegrationServices.Queries.GetById;
internal class GetByIdCourseQueryHandler(CourseDbContext context) : IQueryHandler<GetByIdCourseQuery, GetByIdCourseResponse>
{
    public async Task<Result<GetByIdCourseResponse>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Courses.Where(c => c.Id == request.Id).Select(c => new GetByIdCourseResponse
        (
            c.Id,
             c.Title,
            c.Teacher,
            c.Price
        )).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        return Result.Success<GetByIdCourseResponse>(result);
    }
}
