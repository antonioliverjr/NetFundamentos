using MediatR;
using Mercadinho.Prateleira.API.Application.Estoque.Command;
using Mercadinho.Prateleira.Infrastructure.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Estoque.Handler
{
    public class CreateEstoqueCommandHandler : IRequestHandler<CreateEstoqueCommand, bool>
    {
        private readonly IGenericRepository<Domain.Estoque> _estoqueRepository;
        private readonly IGenericRepository<Domain.Produto> _produtoRepository;

        public CreateEstoqueCommandHandler(IGenericRepository<Domain.Estoque> estoqueRepository, 
            IGenericRepository<Domain.Produto> produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> Handle(CreateEstoqueCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken, request.IdProduto)
                ?? throw new ArgumentException("Id do produto inválido!");

            var estoque = new Domain.Estoque
            {
                ProdutoId = produto.Id,
                InfoCompra = new Domain.Qualitativo
                {
                    PrecoUnidade = request.PrecoUnidade.Equals(null) ? 1 : request.PrecoUnidade,
                    Quantidade = request.Quantidade.Equals(null) ? 1 : request.Quantidade,
                    UnidadeMedida = request.UnidadeMedida.Equals(null) ? Domain.UnidadeMedidaEnum.peca : request.UnidadeMedida
                }
            };

            await _estoqueRepository.AddAsync(estoque, cancellationToken).ConfigureAwait(false);
            return await _estoqueRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
