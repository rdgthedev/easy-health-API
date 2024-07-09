using EasyHealth.Domain.Entities;

namespace EasyHealth.Domain.Interfaces.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>?> GetAllAsync();
    Task<Doctor?> GetByIdAsync(Guid id);
    Task<Doctor?> GetByNameAsync(string name);
    Task AddAsync(Doctor doctor);
    void UpdateAsync(Doctor doctor);
    void DeleteAsync(Doctor doctor);
}