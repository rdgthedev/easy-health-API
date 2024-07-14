using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class DoctorValidator : AbstractValidator<Doctor>
{
    public DoctorValidator()
    {
        RuleFor(x => x.Name).SetValidator(new NameValidator());
        RuleFor(x => x.Gender).Must(GenderValidation);
        RuleFor(x => x.BirthDate).Must(MinimumAgeValidation);
        RuleFor(x => x.Email).SetValidator(new EmailValidator());
        RuleFor(x => x.Address).SetValidator(new AddressValidator());
        RuleFor(x => x.Crm).SetValidator(new CrmValidator());
        RuleFor(x => x.Role).SetValidator(new RoleValidator());
        RuleFor(x => x.Document).SetValidator(new DocumentValidator());
        RuleForEach(x => x.Specialties)
            .NotEmpty().WithMessage("O médico deve ter no mínimo uma especialidade!");

        RuleForEach(x => x.Specialties)
            .NotNull().WithMessage("Especialidade inválida!");

        RuleFor(x => x.Specialties)
            .Must(SpecialtyExists).WithMessage("O médico não pode possuir especialidades repetidas!")
            .When(x => x.Specialties.Count > 0 && x.Specialties.All(s => s != null!));
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

    private static bool MinimumAgeValidation(DateTime birthDate)
        => birthDate <= DateTime.UtcNow.AddYears(-18);

    private static bool SpecialtyExists(IReadOnlyCollection<Specialty> specialties)
        => specialties
            .DistinctBy(x => x.Title).Count()
            .Equals(specialties.Select(x => x.Title).Count());
}