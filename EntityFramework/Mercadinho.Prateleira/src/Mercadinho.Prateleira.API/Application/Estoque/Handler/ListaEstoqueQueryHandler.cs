using MediatR;
using Mercadinho.Prateleira.API.Application.Estoque.Query;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Estoque.Handler
{
    public class ListaEstoqueQueryHandler : IRequestHandler<ListaEstoqueQuery, Domain.Estoque>
    {
        private readonly IGenericRepository<Domain.Estoque> _estoqueRepository;

        public ListaEstoqueQueryHandler(IGenericRepository<Domain.Estoque> estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<Domain.Estoque> Handle(ListaEstoqueQuery request, CancellationToken cancellationToken)
        {
            var estoque = await _estoqueRepository.GetAllAsync(
                noTracking: true,
                filter: x => x.ProdutoId == request.IdProduto,
                includeProperties: "Produto",
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);

            return estoque.FirstOrDefault();
        }
    }
}
