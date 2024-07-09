using System.Text.RegularExpressions;
using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public sealed partial class EmailValidator : AbstractValidator<Email>
{
    private const string _pattern =
        @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

    public EmailValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("O campo email não pode ser vázio!")
            .Must(EmailRegex().IsMatch);
    }

    [GeneratedRegex(_pattern)]
    private static partial Regex EmailRegex();
}