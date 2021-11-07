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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;
        private readonly IGenericRepository<Domain.Categoria> _categoriaRepository;

        public UpdateProductCommandHandler(IGenericRepository<Domain.Produto> produtoRepository,
            IGenericRepository<Domain.Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validation.IsValid)
                return false;
            var produtos = await _produtoRepository.GetAllAsync(
                filter: x => x.Id == request.Id,
                includeProperties: "Categorias"
                ).ConfigureAwait(false);
            var produto = produtos.FirstOrDefault() ??
                throw new ArgumentNullException($"Produto {request.Id} não encontrado...");

            produto.Descricao = request.Descricao;
            if(request.IdCategorias.Any())
            {
                var categorias = _categoriaRepository.GetAll()
                    .Where(x => request.IdCategorias.Contains(x.Id)).ToList();
                produto.Categorias = categorias;
            }
            _produtoRepository.Update(produto);
            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
