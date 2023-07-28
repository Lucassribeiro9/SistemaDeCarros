using CarrosMvc.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

public class CarroDbContext : DbContext
{
    public CarroDbContext(DbContextOptions<CarroDbContext> options) : base(options)
    {

    }
    public DbSet<Carro> Carros { get; set; } = default!;
    public DbSet<CarroFlex> CarrosFlex { get; set; }
    public DbSet<CarroDiesel> CarrosDiesel { get; set; }
    public DbSet<CarroEletrico> CarrosEletricos { get; set; }
}
