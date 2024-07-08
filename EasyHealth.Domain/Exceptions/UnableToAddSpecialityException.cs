namespace EasyHealth.Domain.Exceptions;

public class UnableToAddSpecialityException : Exception
{
    private const string _message = "Não foi possível adicionar uma especialidade!";

    public UnableToAddSpecialityException(string message = _message) : base(message)
    {
    }
}