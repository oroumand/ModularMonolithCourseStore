using MediatR;
using MMCourseStore.Framework.Domain;

namespace MMCourseStore.Framework.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}