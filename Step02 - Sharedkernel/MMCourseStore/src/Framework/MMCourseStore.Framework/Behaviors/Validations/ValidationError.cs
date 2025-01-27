namespace MMCourseStore.Framework.Behaviors.Validations;

public sealed record ValidationError(string PropertyName, string ErrorMessage);