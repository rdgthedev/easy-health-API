namespace EasyHealth.Domain.Exceptions;

public class UnableToAddExamException : Exception
{
    private const string _message = "Não foi possível adicionar um exame!";

    public UnableToAddExamException(string message = _message) : base(message)
    {
    }
}