using Microsoft.EntityFrameworkCore;
using CheapFly.Models;

public class CheapFlyDbContext : DbContext
{
    public CheapFlyDbContext(DbContextOptions<CheapFlyDbContext> options) : base(options) { }

    public DbSet<PretragaLeta> PretragaLeta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<PretragaLeta>()
            .Property(f => f.ukupnaCijena)
            .HasPrecision(18, 2);  

        base.OnModelCreating(modelBuilder);
    }

}
