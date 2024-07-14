using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Interfaces.Repositories;
using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Repositories;

public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly EasyHealthDbContext _context;

    public SpecialtyRepository(EasyHealthDbContext context)
        => _context = context;

    public async Task<IEnumerable<Specialty>?> GetAllAsync()
        => await _context.Specialties.AsNoTracking().ToListAsync();

    public async Task<Specialty?> GetByIdAsync(Guid id)
        => await _context.Specialties.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Specialty?> GetByNameAsync(string title)
        => await _context.Specialties.AsNoTracking().FirstOrDefaultAsync(x => x.Title.Text == title);

    public async Task AddAsync(Specialty specialty)
        => await _context.Specialties.AddAsync(specialty);

    public void UpdateAsync(Specialty specialty)
        => _context.Specialties.Update(specialty);

    public void DeleteAsync(Specialty specialty)
        => _context.Specialties.Remove(specialty);
}