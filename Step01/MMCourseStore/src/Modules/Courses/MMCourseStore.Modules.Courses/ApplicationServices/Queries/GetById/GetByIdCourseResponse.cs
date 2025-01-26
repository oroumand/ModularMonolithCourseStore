namespace MMCourseStore.Modules.Courses.ApplicationServices.Queries.GetById;

public record GetByIdCourseResponse(long Id, string Title, string Teacher, int Price);
