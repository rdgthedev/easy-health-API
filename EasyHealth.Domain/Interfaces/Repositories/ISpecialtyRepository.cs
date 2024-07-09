﻿using EasyHealth.Domain.Entities;

namespace EasyHealth.Domain.Interfaces.Repositories;

public interface ISpecialtyRepository
{
    Task<IEnumerable<Specialty>?> GetAllAsync();
    Task<Specialty?> GetByIdAsync(Guid id);
    Task<Specialty?> GetByTitleAsync(string title);
    Task AddAsync(Specialty specialty);
    void UpdateAsync(Specialty specialty);
    void DeleteAsync(Specialty specialty);
}