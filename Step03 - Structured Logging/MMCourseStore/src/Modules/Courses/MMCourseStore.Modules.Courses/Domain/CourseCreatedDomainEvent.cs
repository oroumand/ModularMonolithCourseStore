using MMCourseStore.Framework.Domain;

namespace MMCourseStore.Modules.Courses.Domain;

public record CourseCreatedDomainEvent(long Id,
                                       string Title,
                                       string Description,
                                       DateTime StartDate,
                                       int SessionCount,
                                       int Price) : IDomainEvent;