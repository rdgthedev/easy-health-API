using EasyHealth.Domain.Entities;

namespace EasyHealth.Domain.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<IEnumerable<Role>?> GetAllAsync();
    Task<Role?> GetByIdAsync(Guid id);
    Task<Role?> GetByTitleAsync(string title);
    Task AddAsync(Role role);
    void UpdateAsync(Role role);
    void DeleteAsync(Role role);
}