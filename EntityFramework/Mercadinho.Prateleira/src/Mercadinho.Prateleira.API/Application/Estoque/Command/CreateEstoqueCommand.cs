using MediatR;
using Mercadinho.Prateleira.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Estoque.Command
{
    public class CreateEstoqueCommand : IRequest<bool>
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; }
    }
}
