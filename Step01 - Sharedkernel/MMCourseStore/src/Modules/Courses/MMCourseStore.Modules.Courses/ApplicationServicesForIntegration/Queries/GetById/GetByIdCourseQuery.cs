using MMCourseStore.Framework.Queries;

namespace MMCourseStore.Modules.Courses.ApplicationServicesForIntegration.Queries.GetById;

public record GetByIdCourseQuery(long Id) : IQuery<GetByIdCourseResponse>;

