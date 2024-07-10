﻿using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;

namespace EasyHealth.Domain.ValueObjects;

public class Crm : Shared.ValueObject
{
    public Crm(
        int code,
        EState state)
    {
        Code = code;
        State = state;
    }

    public int Code { get; private set; }
    public EState State { get; private set; }

    public static implicit operator string(Crm crm)
        => crm.ToString();

    public override string ToString()
        => $"{Code}/{State}";
}