using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Interfaces.Repositories;
using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly EasyHealthDbContext _context;

    public RoleRepository(EasyHealthDbContext context)
        => _context = context;

    public async Task<IEnumerable<Role>?> GetAllAsync()
        => await _context.Roles.AsNoTracking().ToListAsync();

    public async Task<Role?> GetByIdAsync(Guid id)
        => await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Role?> GetByNameAsync(string name)
        => await _context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

    public async Task AddAsync(Role role)
        => await _context.Roles.AddAsync(role);

    public void UpdateAsync(Role role)
        => _context.Roles.Update(role);

    public void DeleteAsync(Role role)
        => _context.Roles.Remove(role);
}