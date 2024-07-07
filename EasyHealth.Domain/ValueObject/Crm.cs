using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObject;

public class Crm : Shared.ValueObject
{
    public Crm(
        int code,
        string state)
    {
        InvalidCrmException.ThrowIfInvalid(code, state);
        Code = code;
        State = state;
    }

    public int Code { get; private set; }
    public string State { get; private set; }

    public static implicit operator string(Crm crm)
        => crm.ToString();

    public override string ToString()
        => $"{Code}/{State}";
}