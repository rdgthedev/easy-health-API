using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObject;

public class Crm : Shared.ValueObject
{
    public Crm(
        int code,
        EState eState)
    {
        Code = code;
        EState = eState;
        InvalidCrmException.ThrowIfInvalid(Code);
    }

    public int Code { get; private set; }
    public EState EState { get; private set; }

    public static implicit operator string(Crm crm)
        => crm.ToString();

    public override string ToString()
        => $"{Code}/{EState}";
}