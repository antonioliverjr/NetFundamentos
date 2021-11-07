using MediatR;
using Mercadinho.Prateleira.API.Application.Produto.Command;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Produto.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;
        private readonly IGenericRepository<Domain.Categoria> _categoriaRepository;

        public CreateProductCommandHandler(IGenericRepository<Domain.Produto> produtoRepository, 
            IGenericRepository<Domain.Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;

            var categorias = _categoriaRepository.GetAll()
                .Where(x => request.IdCategorias.Contains(x.Id)).ToList();

            var produto = new Domain.Produto
            {
                Descricao = request.Descricao,
                Categorias = categorias
            };

            await _produtoRepository.AddAsync(produto, cancellationToken).ConfigureAwait(false);
            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
