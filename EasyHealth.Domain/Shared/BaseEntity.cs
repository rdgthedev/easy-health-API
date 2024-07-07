namespace EasyHealth.Domain.Shared;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; protected set; }
}