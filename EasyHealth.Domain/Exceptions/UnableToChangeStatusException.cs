using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeStatusException : DomainException
{
    public UnableToChangeStatusException(string message) : base(message)
    {
    }

    public static void ThrowIfStatusAreEquals(EStatus oldStatus, EStatus newStatus)
    {
        if (oldStatus.Equals(newStatus))
            throw new UnableToChangeStatusException("Este é o status atual da categoria!");
    }

    public static void ThrowIfStatusTypeIsInvalid(EStatus oldStatus, EStatus newStatus)
    {
        if (newStatus != EStatus.Active && newStatus != EStatus.Inactive)
            throw new UnableToChangeStatusException("O tipo do status é inválido!");
    }
}