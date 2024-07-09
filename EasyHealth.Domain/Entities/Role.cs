using EasyHealth.Domain.Enums;

namespace EasyHealth.Domain.Entities;

public class Role
{
    public Role(string name)
        => Name = name;

    public string Name { get; private set; }

    public bool IsValid => Validate();
    public bool Validate() => !string.IsNullOrEmpty(Name.ToString());
}