using System.Collections.Generic;

namespace Mercadinho.Prateleira.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; } = default;
    }
}