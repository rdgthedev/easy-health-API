using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Interfaces.Repositories;
using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly EasyHealthDbContext _context;

    public DoctorRepository(EasyHealthDbContext context)
        => _context = context;

    public async Task<IEnumerable<Doctor>?> GetAllAsync()
        => await _context.Doctors.AsNoTracking().ToListAsync();

    public async Task<Doctor?> GetByIdAsync(Guid id)
        => await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Doctor?> GetByNameAsync(string name)
        => await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Name.FirstName == name);

    public async Task<Doctor?> GetByCrmAsync(string code)
        => await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Crm.Code == code);

    public async Task AddAsync(Doctor doctor)
        => await _context.AddAsync(doctor);

    public void UpdateAsync(Doctor doctor)
        => _context.Doctors.Update(doctor);

    public void DeleteAsync(Doctor doctor)
        => _context.Doctors.Remove(doctor);
}