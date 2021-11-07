using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Produto.Query
{
    public class ListaProdutosQuery : IRequest<IEnumerable<Domain.Produto>>
    {
    }
}
