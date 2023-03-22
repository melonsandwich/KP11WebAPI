using KP11.Integration.Models;

namespace KP11WebAPI;

public class ManualDb : DbContext
{
    public ManualDb(DbContextOptions<ManualDb> options) : base(options)
    {}

    public DbSet<Manual> Manuals => Set<Manual>();
    
    public DbSet<Subject> Subjects => Set<Subject>();

    public DbSet<Professor> Professors => Set<Professor>();
}