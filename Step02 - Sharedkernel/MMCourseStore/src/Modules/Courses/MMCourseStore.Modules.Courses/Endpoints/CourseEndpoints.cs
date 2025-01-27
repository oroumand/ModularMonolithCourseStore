using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Endpoints;
public static class CourseEndpoints
{
    public static WebApplication MapCourseEndpoint(this WebApplication app, string route)
    {
        app.MapGet(route,async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllCourseQuery());
            return TypedResults.Ok<Result<List<GetAllCourseResponse>>>(result);
        });
        return app;
    }
}
