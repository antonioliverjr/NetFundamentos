using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Models.Usuarios
{
    public class RegistrarViewModelInput
    {
        [Required(ErrorMessage ="O login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage ="O E-mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage ="A Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
