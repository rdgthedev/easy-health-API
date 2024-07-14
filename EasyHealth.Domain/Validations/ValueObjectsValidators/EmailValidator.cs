using System.Text.RegularExpressions;
using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public sealed class EmailValidator : AbstractValidator<Email>
{
    public EmailValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("O e-mail não pode ser vázio!")
            .EmailAddress()
            .WithMessage("O e-mail está em um formato inválido!\nExemplo de e-mail válido Ola@exemplo.com");
    }

    private bool NoWhiteSpace(string email)
    {
        return !email.Contains(" ");
    }
}