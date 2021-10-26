using Curso.api.Business.Entities;
using Curso.api.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Infra.Data
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Cursos> Cursos { get; set; }
    }
}
