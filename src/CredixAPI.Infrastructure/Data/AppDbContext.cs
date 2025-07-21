using CredixAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CredixAPI.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=loans.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}