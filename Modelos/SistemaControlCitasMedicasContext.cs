using Microsoft.EntityFrameworkCore;

namespace SistemaControlCitasMedicas.Modelos
{
    public class SistemaControlCitasMedicasContext : DbContext
    {
        public SistemaControlCitasMedicasContext(DbContextOptions<SistemaControlCitasMedicasContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
    }
}
