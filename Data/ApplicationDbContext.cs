using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaCitasMedicas.Models;

namespace SistemaCitasMedicas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Consulta> Consultas { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Expediente> Expedientes { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}