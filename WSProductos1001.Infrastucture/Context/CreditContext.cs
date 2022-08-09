using Microsoft.EntityFrameworkCore;
using WSProductos1001.Entities;
using WSProductos1001.Infrastucture.Config;

namespace WSProductos1001.Infrastucture.Context;

public class CreditContext: DbContext
{
    public CreditContext(DbContextOptions<CreditContext> options) : base(options)
    {
    }
    
    public DbSet<EPatio> Patios { get; set; }
    public DbSet<EVehicle> Vehicles { get; set; }
    public DbSet<EBrand> Brands { get; set; }
    public DbSet<EAgent> Agents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new PatioConfig().Configure(modelBuilder.Entity<EPatio>());
        new VehicleConfig().Configure(modelBuilder.Entity<EVehicle>());
        new BrandConfig().Configure(modelBuilder.Entity<EBrand>());
        new AgentConfig().Configure(modelBuilder.Entity<EAgent>());
    }
}