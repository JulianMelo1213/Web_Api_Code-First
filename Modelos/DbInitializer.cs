using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SistemaControlCitasMedicas.Modelos
{
    public static class DbInitializer
    {
        public static void Initialize(SistemaControlCitasMedicasContext context)
        {
            // Crear la base de datos si no existe
            context.Database.EnsureCreated();

            // Buscar si ya existen médicos
            if (context.Medicos.Any())
            {
                return; // La base de datos ya está poblada
            }

            var medicos = new Medico[]
            {
                new Medico { Nombre = "Juan", Apellido = "Perez", Especialidad = "Cardiología" },
                new Medico { Nombre = "Ana", Apellido = "Gomez", Especialidad = "Neurología" }
            };
            foreach (Medico m in medicos)
            {
                context.Medicos.Add(m);
            }
            context.SaveChanges();

            var pacientes = new Paciente[]
            {
                new Paciente { Nombre = "Carlos", Apellido = "Ramirez", FechaNacimiento = DateTime.Parse("1990-01-01") },
                new Paciente { Nombre = "Maria", Apellido = "Lopez", FechaNacimiento = DateTime.Parse("1985-05-23") }
            };
            foreach (Paciente p in pacientes)
            {
                context.Pacientes.Add(p);
            }
            context.SaveChanges();

            var clinicas = new Clinica[]
            {
                new Clinica { Nombre = "Clínica Central", Direccion = "Calle Falsa 123" },
                new Clinica { Nombre = "Clínica Norte", Direccion = "Avenida Siempre Viva 742" }
            };
            foreach (Clinica c in clinicas)
            {
                context.Clinicas.Add(c);
            }
            context.SaveChanges();

            var citas = new Cita[]
            {
                new Cita { Fecha = DateTime.Now.AddDays(1), PacienteId = pacientes[0].Id, MedicoId = medicos[0].Id, ClinicaId = clinicas[0].Id },
                new Cita { Fecha = DateTime.Now.AddDays(2), PacienteId = pacientes[1].Id, MedicoId = medicos[1].Id, ClinicaId = clinicas[1].Id }
            };
            foreach (Cita c in citas)
            {
                context.Citas.Add(c);
            }
            context.SaveChanges();
        }
    }
}
