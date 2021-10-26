﻿using Curso.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Business.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
