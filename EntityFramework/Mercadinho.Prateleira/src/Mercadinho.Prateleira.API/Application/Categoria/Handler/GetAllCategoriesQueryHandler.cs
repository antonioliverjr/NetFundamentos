using MediatR;
using Mercadinho.Prateleira.API.Application.Categoria.Query;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Categoria.Handler
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Domain.Categoria>>
    {
        private readonly IGenericRepository<Domain.Categoria> _categoriaRepository;

        public GetAllCategoriesQueryHandler(IGenericRepository<Domain.Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Domain.Categoria>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepository.GetAllAsync(
                noTracking: true,
                includeProperties: "Produtos",
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
