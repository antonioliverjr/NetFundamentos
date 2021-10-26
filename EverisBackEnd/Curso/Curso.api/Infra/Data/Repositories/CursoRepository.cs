using Curso.api.Business.Entities;
using Curso.api.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Infra.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _contexto;

        public CursoRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Cursos Curso)
        {
            _contexto.Cursos.Add(Curso);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IList<Cursos> ObterPorUsuario(int codigoUsuario)
        {
            return (IList<Cursos>)_contexto.Cursos.Include(l => l.Usuario).Where(c => c.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
