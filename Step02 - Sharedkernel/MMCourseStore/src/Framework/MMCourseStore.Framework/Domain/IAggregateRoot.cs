namespace MMCourseStore.Framework.Domain;

public interface IAggregateRoot
{
    void ClearDomainEvents();
    IReadOnlyList<IDomainEvent> Events();
}