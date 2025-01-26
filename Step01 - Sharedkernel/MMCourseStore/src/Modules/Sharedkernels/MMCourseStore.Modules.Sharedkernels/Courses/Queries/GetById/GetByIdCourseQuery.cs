using MMCourseStore.Framework.Queries;

namespace MMCourseStore.Modules.Sharedkernels.Courses.Queries.GetById;

public record GetByIdCourseQuery(long Id) : IQuery<GetByIdCourseResponse>;

