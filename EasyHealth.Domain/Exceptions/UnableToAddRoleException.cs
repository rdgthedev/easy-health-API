namespace EasyHealth.Domain.Exceptions;

public class UnableToAddRoleException : Exception
{
    private const string _message = "Não foi possível adicionar o perfil!";
    
    public UnableToAddRoleException(string message = _message) : base(message)
    {
        
    }
}