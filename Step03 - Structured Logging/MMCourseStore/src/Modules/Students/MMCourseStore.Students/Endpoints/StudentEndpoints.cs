using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Modules.Students.ApplicationServices.Queries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCourseStore.Modules.Endpoints;

public static class StudentEndpoints
{
    public static WebApplication MapStudentEndpoint(this WebApplication app, string route)
    {
        app.MapGet(route, async (ISender sender) =>
        {
            var result = await sender.Send(new GetAllStudentQuery());
            return TypedResults.Ok<Result<List<GetAllStudentResponse>>>(result);
        });
        return app;
    }
}
