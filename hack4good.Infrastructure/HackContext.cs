using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace hack4good.Infrastructure;

public class HackContext : DbContext
{
    public HackContext()
    {
    }

    public HackContext(DbContextOptions<HackContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        throw new Exception("Context was not configured");
    }
}