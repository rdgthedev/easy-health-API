using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Specialty : BaseEntity
{
    private IList<Doctor> _doctors;

    protected Specialty()
    {
    }

    public Specialty(Title title)
    {
        Title = title;
        CreateDate = DateTime.UtcNow;
        _doctors = new List<Doctor>();
    }

    public Title Title { get; private set; }
    public EStatus Status { get; private set; }
    public IReadOnlyCollection<Doctor> Doctors { get; private set; }

    public ValidationResult Validate()
        => new SpecialtyValidator().Validate(this);

    public void AddDoctor(Doctor doctor)
        => _doctors.Add(doctor);

    public void Update(Title title, EStatus status)
    {
        Title = title;
        Status = status;
    }
}