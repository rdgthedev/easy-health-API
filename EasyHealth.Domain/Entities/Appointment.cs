using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Appointment : BaseEntity
{
    protected Appointment()
    {
        
    }
    public Appointment(
        Doctor doctor,
        Patient patient,
        Exam exam,
        DateTime date)
    {
        Doctor = doctor;
        Patient = patient;
        Exam = exam;
        Date = date;
        Status = EAppointmentStatus.Scheduled;
    }

    public Doctor Doctor { get; private set; }
    public Patient Patient { get; private set; }
    public Exam Exam { get; private set; }
    public DateTime Date { get; private set; }
    public EAppointmentStatus Status { get; private set; }

    public void Validate()
        => new AppointmentValidator().Validate(this);

    public void Update(EAppointmentStatus status)
        => Status = status;
}