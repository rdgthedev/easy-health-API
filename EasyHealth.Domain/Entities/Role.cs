using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Role : BaseEntity
{
    public Role(string name)
        => Name = name;

    public string Name { get; private set; }
    public EStatus Status { get; private set; }
    public bool IsValid => new RoleValidator().Validate(this).IsValid;

    public void UpdateName(string name)
    {
        if (!string.IsNullOrEmpty(name))
            throw new UnableToChangeNameException("Não foi possível alterar o nome do perfil");

        Name = name;
    }

    public void UpdateStatus(EStatus status)
    {
        if (Status.Equals(status))
            throw new UnableToChangeStatusException("Este é o eStatus atual da categoria!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}