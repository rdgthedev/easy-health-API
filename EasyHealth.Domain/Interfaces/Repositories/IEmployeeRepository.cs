using EasyHealth.Domain.Entities;

namespace EasyHealth.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>?> GetAllAsync();
    Task<Employee?> GetByIdAsync(Guid id);
    Task<Employee?> GetByNameAsync(string name);
    Task AddAsync(Employee employee);
    void UpdateAsync(Employee employee);
    void DeleteAsync(Employee employee);
}