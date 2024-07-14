using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Interfaces.Repositories;
using EasyHealth.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly EasyHealthDbContext _context;

    public PatientRepository(EasyHealthDbContext context)
        => _context = context;

    public async Task<IEnumerable<Patient>?> GetAllAsync()
        => await _context.Patients.AsNoTracking().ToListAsync();

    public async Task<Patient?> GetByIdAsync(Guid id)
        => await _context.Patients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Patient?> GetByNameAsync(string name)
        => await _context.Patients.AsNoTracking().FirstOrDefaultAsync(x => x.Name.FirstName == name);

    public async Task AddAsync(Patient patient)
        => await _context.Patients.AddAsync(patient);

    public void UpdateAsync(Patient patient)
        => _context.Patients.Update(patient);

    public void DeleteAsync(Patient patient)
        => _context.Patients.Remove(patient);
}