namespace JobsApp.Domain.Entities.Base
{
    public class BaseEntity : IEntity
    {
    }

    public class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}