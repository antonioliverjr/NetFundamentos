using Curso.api.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(usuarioViewModelOutput usuarioViewModelOutput);
    }
}
