using Microsoft.EntityFrameworkCore;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Framework.Queries;
using MMCourseStore.Modules.Courses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
internal class GetAllCourseQueryHandler(CourseDbContext context) : IQueryHandler<GetAllCourseQuery, List<GetAllCourseResponse>>
{
    public async Task<Result<List<GetAllCourseResponse>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        List<GetAllCourseResponse> result = await context.Courses.Select(c => new GetAllCourseResponse
        (
            c.Id,
             c.Title,
            c.Teacher
        )).ToListAsync(cancellationToken: cancellationToken);

        return result;
    }
}
