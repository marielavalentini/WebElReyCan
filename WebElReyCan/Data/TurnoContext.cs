using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using WebElReyCan.Models;

namespace WebElReyCan.Data
{
    public class TurnoContext : DbContext
    {
        public TurnoContext(DbContextOptions<TurnoContext> options) : base(options)
        {
        }

        public DbSet<Turno> Turnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPCIONAL PARA INICIALIZAR DATOS EN LA BASE DE DATOS
            //INICIALIZA LA TABLA PERSONA CON DOS INSTANCIAS

            modelBuilder.Entity<Turno>().HasData(
               new Turno
               {
                   TurnoId = 1,
                   Fecha = new DateTime(2022,12,3),
                   Nombre = "Sako",
                   Raza = "Labrador",
                   Edad = 7,
                   NombreDuenio = "Tomas",
                   Telefono= "2235643241"
               },
               new Turno
               {
                   TurnoId= 2,
                   Fecha = new DateTime(2022, 12, 7),
                   Nombre = "Negra",
                   Raza = "Puro perro",
                   Edad = 10,
                   NombreDuenio = "Mariela",
                   Telefono = "2235643241"
               });
        }
    }
}
