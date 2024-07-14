using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Interfaces.Repositories;
using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EasyHealthDbContext _context;

    public EmployeeRepository(EasyHealthDbContext context)
        => _context = context;

    public async Task<IEnumerable<Employee>?> GetAllAsync()
        => await _context.Employees.AsNoTracking().ToListAsync();

    public async Task<Employee?> GetByIdAsync(Guid id)
        => await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Employee?> GetByNameAsync(string name)
        => await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Name.FirstName == name);

    public async Task AddAsync(Employee employee)
        => await _context.Employees.AddAsync(employee);

    public void UpdateAsync(Employee employee)
        => _context.Employees.Update(employee);

    public void DeleteAsync(Employee employee)
        => _context.Employees.Remove(employee);
}