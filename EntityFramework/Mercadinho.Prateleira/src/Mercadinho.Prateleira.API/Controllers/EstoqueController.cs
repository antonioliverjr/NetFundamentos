using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <response code="204">Não há dados em Estoque para listar...</response>
        /// <response code="200">Lista o Estoque cadastrado!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEstoque()
        {
            return Ok();
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
        public async Task<IActionResult> Create()
        {
            return Ok();
        }

        /// <summary>
        /// Atualizar registro do Estoque
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Estoque atualizado com sucesso!</response>
        /// <response code="400">Erro ao atualizar registro, verifique os dados informados...</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        /// <summary>
        /// Excluir registro do Estoque
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Registro excluído com sucesso!</response>
        /// <response code="400">Erro ao excluir registro, verifique os dados informados...</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
