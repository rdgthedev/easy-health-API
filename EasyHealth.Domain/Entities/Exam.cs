using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Exam : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
}