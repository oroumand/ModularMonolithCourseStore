using MediatR;
using MMCourseStore.Framework.Domain;

namespace MMCourseStore.Framework.Queries;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}