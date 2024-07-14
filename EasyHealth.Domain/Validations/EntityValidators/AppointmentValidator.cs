using EasyHealth.Domain.Entities;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public class AppointmentValidator : AbstractValidator<Appointment>
{
    public AppointmentValidator()
    {
        RuleFor(x => x.Date)
            .Must(date => date != default).WithMessage("O campo data não pode ser vázio!")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("O campo data não pode conter uma data no futura!");

        RuleFor(x => x.Doctor)
            .NotNull().WithMessage("O campo médico não pode ser vázio!")
            .SetValidator(new DoctorValidator());
        RuleFor(x => x.Patient)
            .NotNull().WithMessage("O campo paciente não pode ser vázio!")
            .SetValidator(new PatientValidator());
        RuleFor(x => x.Exam)
            .NotNull().WithMessage("O campo exame não pode ser vázio!")
            .SetValidator(new ExamValidator());
    }
}