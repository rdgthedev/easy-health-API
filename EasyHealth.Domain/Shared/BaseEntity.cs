namespace EasyHealth.Domain.Shared;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreateDate = DateTime.UtcNow;
    }
    
    public Guid Id { get; protected set; }
    public DateTime CreateDate { get; protected set; }
    public DateTime LastUpdateDate { get; protected set; }
}