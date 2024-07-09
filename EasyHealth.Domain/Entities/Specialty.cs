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
        Title = title;
        CreateDate = DateTime.UtcNow;
        _doctors = new List<Doctor>();
    }

    public string Title { get; private set; }
    public EStatus Status { get; private set; }
    public IReadOnlyCollection<Doctor> Doctors { get; private set; }
    public bool IsValid => new SpecialtyValidator().Validate(this).IsValid;

    public void AddDoctor(Doctor doctor)
    {
        var validator = new DoctorValidator();
        var result = validator.Validate(doctor);

        if (!result.IsValid)
            throw new DomainException($"Não foi possível adicionar um médico a especialidade {Title}!", result.Errors);

        var doctorExists = Doctors.Any(x => x.Name == doctor.Name);
        
        if(doctorExists)
            throw new DomainException("Médico já adicionado a esta especialidade anteriormente!");
        
        _doctors.Add(doctor);
    }

    public void UpdateTitle(string title)
    {
        Title = title ?? throw new DomainException("O campo título não pode ser vázio!");
        LastUpdateDate = DateTime.UtcNow;
    }

    public void UpdateStatus(EStatus status)
    {
        if (Status.Equals(status))
            throw new DomainException("Este é o status atual da categoria!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}