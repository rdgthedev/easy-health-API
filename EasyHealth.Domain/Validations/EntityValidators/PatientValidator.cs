using System.Reflection.Metadata;
using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name).SetValidator(new NameValidator());
        RuleFor(x => x.Gender).Must(GenderValidation);
        RuleFor(x => x.BirthDate)
            .Must(date => date != default).WithMessage("O campo data de nascimento não pode ser vázio!");
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
    }

    private static bool GenderValidation(EGender gender)
    {
        return gender switch
        {
            EGender.Male => true,
            EGender.Female => true,
            _ => false
        };
    }
}