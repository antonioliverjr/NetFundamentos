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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public DeleteProductCommandHandler(IGenericRepository<Domain.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken, request.Id)
                .ConfigureAwait(false);
            
            if (produto == null)
                return false;

            _produtoRepository.Delete(produto);

            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
