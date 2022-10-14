using ASPNET3.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNET3.Conexion
{
    public class EmpresaxDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public EmpresaxDbContext(DbContextOptions<EmpresaxDbContext> options) : base(options)
        { }
    }
}
