using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Specialty : BaseEntity
{
    private IList<Doctor> _doctors;

    protected Specialty()
    {
    }

    public Specialty(string title)
    {
        Name = title;
        CreateDate = DateTime.UtcNow;
        _doctors = new List<Doctor>();
    }

    public string Name { get; private set; }
    public EStatus Status { get; private set; }
    public IReadOnlyCollection<Doctor> Doctors { get; private set; }
    public bool IsValid => new SpecialtyValidator().Validate(this).IsValid;

    public void AddDoctor(Doctor doctor)
    {
        var validator = new DoctorValidator();
        var result = validator.Validate(doctor);

        if (!result.IsValid)
            throw new UnableToAddDoctorException($"Não foi possível adicionar um médico a especialidade {Name}!",
                result.Errors);

        var doctorExists = Doctors.Any(x => x.Name == doctor.Name);

        if (doctorExists)
            throw new UnableToAddDoctorException("Médico já adicionado a esta especialidade anteriormente!");

        _doctors.Add(doctor);
    }

    public void UpdateTitle(string title)
    {
        Name = title ?? throw new UnableToChangeNameException("O campo título não pode ser vázio!");
        LastUpdateDate = DateTime.UtcNow;
    }

    public void UpdateStatus(EStatus status)
    {
        if (Status.Equals(status))
            throw new UnableToChangeStatusException("Este é o status atual da especialidade!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}