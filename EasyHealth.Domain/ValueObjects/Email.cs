﻿using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation.Results;

namespace EasyHealth.Domain.ValueObjects;

public class Email : Shared.ValueObject
{
    public Email(string address) => Address = address;

    public string Address { get; private set; }

    public static implicit operator string(Email email)
        => email.ToString();

    public static implicit operator Email(string email)
        => new(email);

    public ValidationResult Validate()
        => new EmailValidator().Validate(this);

    public override string ToString()
        => Address;
}