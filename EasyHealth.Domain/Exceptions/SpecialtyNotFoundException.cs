namespace EasyHealth.Domain.Exceptions;

public class SpecialtyNotFoundException : Exception
{
    private const string _message = "Especialidade não encontrada!";

    public SpecialtyNotFoundException(string message = _message) : base(message)
    {
    }
}