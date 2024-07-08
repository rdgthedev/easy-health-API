using EasyHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyHealth.Infrastructure.Data;

public class EasyHealthDbContext : DbContext
{
    public EasyHealthDbContext(DbContextOptions<EasyHealthDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Specialty> Specialties { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}