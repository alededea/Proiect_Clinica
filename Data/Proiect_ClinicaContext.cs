using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Clinica.Models;

namespace Proiect_Clinica.Data
{
    public class Proiect_ClinicaContext : DbContext
    {
        public Proiect_ClinicaContext (DbContextOptions<Proiect_ClinicaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Clinica.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Proiect_Clinica.Models.Angajat>? Angajat { get; set; }
        public DbSet<Calificare> Calificare { get; set; }
        public DbSet<Proiect_Clinica.Models.Client>? Client { get; set; }
        public DbSet<Proiect_Clinica.Models.Programare>? Programare { get; set; }
        public DbSet<Animal> Animale { get; set; }

    }
}
