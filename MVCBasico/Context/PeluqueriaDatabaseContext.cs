using Microsoft.EntityFrameworkCore;
using System;
using MVCBasico.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasico.Context
{
    public class PeluqueriaDatabaseContext : DbContext
    {
        public PeluqueriaDatabaseContext()
        {
        }

        public PeluqueriaDatabaseContext(DbContextOptions<PeluqueriaDatabaseContext> options)
       : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Peluquero> Peluqueros { get; set; }

        public DbSet<Turno> Turnos { get; set; }
    }

}
