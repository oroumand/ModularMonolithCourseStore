using MMCourseStore.Framework.Domain;

namespace MMCourseStore.Modules.Courses.Domain;

public record CoursePriceChangedDomainEvent(long Id, int Price) : IDomainEvent;