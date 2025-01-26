using MMCourseStore.Framework.Queries;

namespace MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetById;

public record GetByIdCourseQuery(long Id) : IQuery<GetByIdCourseResponse>;

