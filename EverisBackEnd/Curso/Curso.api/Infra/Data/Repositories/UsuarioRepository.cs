using Curso.api.Business.Entities;
using Curso.api.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _contexto;

        public UsuarioRepository(CursoDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
