using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Models.Usuarios
{
    public class usuarioViewModelOutput
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Informe o login é obrigatório!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe um e-mail é obrigatório!")]
        public string Email { get; set; }
    }
}
