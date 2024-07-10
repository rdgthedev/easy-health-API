using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class SpecialtyNotFoundException : DomainException
{
    public SpecialtyNotFoundException(string message) : base(message)
    {
    }
}