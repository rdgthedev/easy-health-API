namespace EasyHealth.Domain.Exceptions;

public class UnableToAddSpeciality : Exception
{
    private const string _message = "Não foi possível adicionar uma especialidade!";

    public UnableToAddSpeciality(string message = _message) : base(message)
    {
    }
}