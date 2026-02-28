using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Pahra.Domain.Models;

namespace Pahra.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Participant> Participants { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Participant>().Property(p => p.FirstName).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Participant>().HasIndex(p => p.Email).IsUnique();
    }
}
