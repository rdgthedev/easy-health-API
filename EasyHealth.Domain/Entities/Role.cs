﻿namespace EasyHealth.Domain.Entities;

public class Role
{
    public Role(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}