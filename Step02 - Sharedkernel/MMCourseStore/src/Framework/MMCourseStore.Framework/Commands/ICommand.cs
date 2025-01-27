using MediatR;
using MMCourseStore.Framework.Domain;

namespace MMCourseStore.Framework.Commands;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}