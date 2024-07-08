namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeSector : Exception
{
    private const string _message = "Não foi possível alterar o setor!";

    public UnableToChangeSector(string message = _message) : base(message)
    {
    }
}