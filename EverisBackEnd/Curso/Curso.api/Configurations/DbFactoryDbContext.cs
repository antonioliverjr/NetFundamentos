using Curso.api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseSqlServer("Server=DELLJR\\SQLEXPRESS;Database=CURSOS;User ID=project;Password=Jrdbsql");
            CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
