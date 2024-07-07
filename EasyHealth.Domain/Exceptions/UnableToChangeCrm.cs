namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeCrm : Exception
{
    private const string _message = "Não foi possível adicionar uma especialidade!";

    public UnableToChangeCrm(string message = _message) : base(message)
    {
    }
}