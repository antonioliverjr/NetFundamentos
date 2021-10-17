using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Produto
    {
        public int id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe uma descrição!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a quantidade!")]
        [Range(1, 10, ErrorMessage = "Digite uma quantidade entre 1 e 10!")]
        public int Quantidade { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        
    }
}
