using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Role : BaseEntity
{
    public Role(string name)
        => Name = name;

    public string Name { get; private set; }

    public bool IsValid => Validate();
    private bool Validate() => !string.IsNullOrEmpty(Name);
}