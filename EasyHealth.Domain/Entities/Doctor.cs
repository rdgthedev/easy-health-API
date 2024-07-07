﻿using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Doctor : BaseEntity
{
    public Doctor(
        string name,
        int birthDate,
        Gender gender,
        string specialty,
        string crm)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Specialty = specialty;
        Crm = crm;
    }

    public string Name { get; private set; }
    public int BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public string Specialty { get; private set; }
    public string Crm { get; private set; }

    public bool IsValid() => true;

    public void ChangeSpecialty(string specialty)
    {
    }

    public void AddSpecialty(string specialty)
    {
    }
}