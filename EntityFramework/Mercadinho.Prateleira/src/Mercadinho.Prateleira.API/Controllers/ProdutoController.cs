using MediatR;
using Mercadinho.Prateleira.API.Application.Produto.Command;
using Mercadinho.Prateleira.API.Application.Produto.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todos os Produtos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="204">Não há Produtos para listar...</response>
        /// <response code="200">Lista os Produtos cadastrados!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProdutos(CancellationToken cancellationToken)
        {
            var produtos = await _mediator.Send(new ListaProdutosQuery(), cancellationToken)
                .ConfigureAwait(false);
            return produtos.Any() ? Ok(produtos) : NoContent();
        }

        /// <summary>
        /// Inserir registro do Produto
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Produto cadastrado com sucesso!</response>
        /// <response code="400">Erro ao inserir registro, verifique os dados informados...</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductCommand createProductCommand, 
            CancellationToken cancellationToken)
        {
            if (!createProductCommand.Validation.IsValid)
                return BadRequest(createProductCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createProductCommand, cancellationToken)
                .ConfigureAwait(false);

            return sucesso.Equals(true) ? Ok("Produto cadastrado com sucesso!") : BadRequest("Falha ao inserir registro...");
        }

        /// <summary>
        /// Atualizar registro do Produto
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Produto atualizado com sucesso!</response>
        /// <response code="400">Erro ao atualizar registro, verifique os dados informados...</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
        {
            if (!updateProductCommand.Validation.IsValid)
                return BadRequest(updateProductCommand.Validation.Errors);

            var sucesso = await _mediator.Send(updateProductCommand, cancellationToken).ConfigureAwait(false);
            return sucesso.Equals(true) ? Ok(sucesso) : BadRequest("Erro ao atualizar registro...");
        }

        /// <summary>
        /// Excluir registro do Produto
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Produto excluído com sucesso!</response>
        /// <response code="400">Erro ao excluir registro, verifique os dados informados...</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteProductCommand deleteProductCommand, 
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteProductCommand, cancellationToken).ConfigureAwait(false);

            return sucesso.Equals(true) ? Ok(sucesso) : BadRequest($"Operação {sucesso}, Id não localizado ou erro desconhecido...");
        }
    }
}
