using EasyHealth.Domain.Entities;

namespace EasyHealth.Domain.Interfaces.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>?> GetAllAsync();
    Task<Patient?> GetByIdAsync(Guid id);
    Task<Patient?> GetByNameAsync(string name);
    Task AddAsync(Patient patient);
    void UpdateAsync(Patient patient);
    void DeleteAsync(Patient patient);
}