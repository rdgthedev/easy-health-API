﻿using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome não pode ser inválido!")
            .Length(3, 60).WithMessage("O campo nome deve ter no mínimo 6 e no máximo 60 caracteres!");
        
        RuleFor(x => x.Gender).Must(GenderValidation);
        
        RuleFor(x => x.BirthDate)
            .Must(date => date != default).WithMessage("O campo data de nascimento não pode ser vázio!");

        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
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