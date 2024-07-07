namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeCrm : Exception
{
    private const string _message = "Não foi possível alterar o CRM!";

    public UnableToChangeCrm(string message = _message) : base(message)
    {
    }
}