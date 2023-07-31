using CarrosMvc.Models;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

public class CarroDbContext : DbContext
{
    public CarroDbContext(DbContextOptions<CarroDbContext> options) : base(options)
    {

    }
    public Microsoft.EntityFrameworkCore.DbSet<Carro> Carros { get; set; } = default!;
    public Microsoft.EntityFrameworkCore.DbSet<CarroFlex> CarrosFlex { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CarroDiesel> CarrosDiesel { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<CarroEletrico> CarrosEletricos { get; set; }
}
