using KP11WebAPI.Models;

namespace KP11WebAPI;

public class ManualDb : DbContext
{
    public ManualDb(DbContextOptions<ManualDb> options) : base(options)
    {}

    public DbSet<Manual> Manuals => Set<Manual>();
}