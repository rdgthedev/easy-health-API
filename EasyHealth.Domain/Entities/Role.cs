using EasyHealth.Domain.Enums;

namespace EasyHealth.Domain.Entities;

public class Role
{
    public Role(ERole name)
    {
        Name = name;
    }

    public ERole Name { get; private set; }
}