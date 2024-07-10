using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public sealed class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo street não pode ser vázio!");

        RuleFor(x => x.Number)
            .GreaterThan(0).WithMessage("O campo número deve ser maior que zero!");

        RuleFor(x => x.Neighbordhood)
            .NotEmpty().WithMessage("O campo neighborhood não pode ser vázio!");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("O campo city não pode ser vázio!");
        
        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("O campo zipcode não pode ser vázio!")
            .Length(8).WithMessage("O campo zipcode deve ter oito digitos!"); 
        
        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O campo state não pode ser vázio!")
            .Length(2, 2). WithMessage("O campo estado deve ter no mínimo dois caracteres!");
    }
}