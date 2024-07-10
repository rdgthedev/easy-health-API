using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObjects;

public class Crm : Shared.ValueObject
{
    public Crm(
        string code,
        string state)
    {
        Code = code;
        State = state;
    }

    public string Code { get; private set; }
    public string State { get; private set; }

    public static implicit operator string(Crm crm)
        => crm.ToString();

    public override string ToString()
        => $"{Code}/{State}";
}