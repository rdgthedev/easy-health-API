using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObject;

public class Crm : Shared.ValueObject
{
    public Crm(
        int code,
        State state)
    {
        Code = code;
        State = state;
        InvalidCrmException.ThrowIfInvalid(Code);
    }

    public int Code { get; private set; }
    public State State { get; private set; }

    public static implicit operator string(Crm crm)
        => crm.ToString();

    public override string ToString()
        => $"{Code}/{State}";
}