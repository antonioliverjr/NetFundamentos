using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Estoque.Query
{
    public class ListaEstoqueQuery : IRequest<Domain.Estoque>
    {
        public int IdProduto { get; set; }
    }
}
