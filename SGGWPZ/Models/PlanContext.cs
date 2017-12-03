using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SGGWPZ.Models
{
    public class PlanContext : DbContext
    {
        //public PlanContext(DbContextOptions<PlanContext> options)//:base(options)
        //{
        //}

        public DbSet<Cyklicznosc> Cyklicznosci { get; set; }
        public DbSet<Grupa> Grupy { get; set ;}
        public DbSet<Katedra> Katedry { get; set; }
        public DbSet<Przedmiot> Przedmioty { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
        public DbSet<Sala> Sale { get; set; }
        public DbSet<Typ_przedmiotu> Typy_przedmiotu { get; set; }
        public DbSet<Wykladowca> Wykladowcy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=C:\\Users\\przemek1236\\source\\repos\\SGGWPZ\\planzajec.db");
        }

    }
}
