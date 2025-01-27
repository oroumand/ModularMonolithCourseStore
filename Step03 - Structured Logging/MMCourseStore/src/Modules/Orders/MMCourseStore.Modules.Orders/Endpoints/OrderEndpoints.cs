using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMCourseStore.Framework.Domain;
using MMCourseStore.Modules.Orders.ApplicationServices.Commands.CreateOrder;

namespace MMCourseStore.Modules.Endpoints;

public static class OrderEndpoints
{
    public static WebApplication MapOrderEndpoint(this WebApplication app, string route)
    {
        app.MapPost(route, async (ISender sender, [FromBody] CreateOrderCommand command) =>
        {
            var result = await sender.Send(command);
            return TypedResults.Ok<Result<long>>(result);
        });
        return app;
    }
}
