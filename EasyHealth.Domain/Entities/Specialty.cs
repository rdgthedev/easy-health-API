using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Specialty : BaseEntity
{
    protected Specialty()
    {
    }

    public Specialty(string title)
    {
        Title = title;
        CreateDate = DateTime.UtcNow;
    }

    public string Title { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }

    public bool IsValid() => true;

    public void ChangeTitle()
    {
        LastUpdateDate = DateTime.UtcNow;
    }
}