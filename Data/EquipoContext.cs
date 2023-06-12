using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Models;

namespace SegundoParcial.Data
{
    public class EquipoContext : DbContext
    {
        public EquipoContext (DbContextOptions<EquipoContext> options)
            : base(options)
        {
        }

        public DbSet<SegundoParcial.Models.Area> Area { get; set; } = default!;

        public DbSet<SegundoParcial.Models.Deposito> Deposito { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
            .HasMany(p=> p.Depositos)
            .WithMany(p=> p.Areas)
            .UsingEntity("AreaDeposito");
        }

        public DbSet<SegundoParcial.Models.Equipo> Equipo { get; set; } = default!;
    }
}
