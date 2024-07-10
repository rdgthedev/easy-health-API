using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Appointment : BaseEntity
{
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
    public bool IsValid => new AppointmentValidator().Validate(this).IsValid;
    
    public void UpdateStatus(EAppointmentStatus status)
    {
        if (Status.Equals(status))
            throw new UnableToChangeStatusException("O exame já se encontra neste eStatus!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}