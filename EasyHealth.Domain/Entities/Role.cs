using EasyHealth.Domain.Enums;

namespace EasyHealth.Domain.Entities;

public class Role
{
    public Role(ERole name)
        => Name = name;

    public ERole Name { get; private set; }

    public bool IsValid => Validate();
    public bool Validate() => !string.IsNullOrEmpty(Name.ToString());
}