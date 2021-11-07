using MediatR;
using Mercadinho.Prateleira.API.Application.Estoque.Command;
using Mercadinho.Prateleira.API.Application.Estoque.Query;
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
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todo o Estoque
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="204">Não há dados em Estoque ou Produto cadastro para listar...</response>
        /// <response code="200">Lista o Estoque do produto cadastrado!</response>
        [HttpGet]
        [Route("{idProduto:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductEstoque([FromRoute] int idProduto, CancellationToken cancellationToken = default)
        {
            var estoque = await _mediator.Send(new ListaEstoqueQuery
                {
                    IdProduto = idProduto
                }, cancellationToken).ConfigureAwait(false);

            return estoque.Equals(null) ? NoContent() : Ok(estoque);
        }

        /// <summary>
        /// Inserir registro de Estoque
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Estoque cadastrado com sucesso!</response>
        /// <response code="400">Erro ao inserir registro, verifique os dados informados...</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateEstoqueCommand createEstoqueCommand, CancellationToken cancellationToken = default)
        {
            var sucesso = await _mediator.Send(createEstoqueCommand, cancellationToken).ConfigureAwait(false);
            return sucesso.Equals(true) ? Ok(sucesso) : BadRequest("Falha ao inserir registro...");
        }
    }
}
