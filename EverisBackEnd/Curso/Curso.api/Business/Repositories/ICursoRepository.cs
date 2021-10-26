using Curso.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Cursos Curso);
        void Commit();
        IList<Cursos> ObterPorUsuario(int codigoUsuario);
    }
}
