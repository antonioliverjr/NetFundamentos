using MediatR;
using Mercadinho.Prateleira.API.Application.Categoria.Command;
using Mercadinho.Prateleira.API.Application.Categoria.Query;
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
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todas as Categorias
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="204">Não há categorias para listar...</response>
        /// <response code="200">Lista as categorias cadastradas!</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
        {
            var categorias = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken)
                .ConfigureAwait(false);

            return categorias.Any() ? Ok(categorias) : NoContent();
        }

        /// <summary>
        /// Inserir registro da Categoria
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Categoria cadastrada com sucesso!</response>
        /// <response code="400">Erro ao inserir registro, verifique os dados informados...</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken)
        {
            if (!createCategoryCommand.Validation.IsValid)
                return BadRequest(createCategoryCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return sucesso.Equals(true) ? Ok("Categoria cadastrada com sucesso") : BadRequest("Falha ao inserir a categoria, tente novamente...");
        }

        /// <summary>
        /// Atualizar registro da Categoria
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Categoria atualizada com sucesso!</response>
        /// <response code="400">Erro ao atualizar registro, verifique os dados informados...</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
        {
            if (!updateCategoryCommand.Validation.IsValid)
                return BadRequest(updateCategoryCommand.Validation.Errors);

            var sucesso = await _mediator.Send(updateCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return sucesso.Equals(true) ? Ok(sucesso) : BadRequest("Erro ao atualizar a categoria!");
        }

        /// <summary>
        /// Excluir registro da Categoria
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code="200">Categoria excluída com sucesso!</response>
        /// <response code="400">Erro ao excluir registro, verifique os dados informados...</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategoryCommand, CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteCategoryCommand, cancellationToken)
                .ConfigureAwait(false);

            return sucesso.Equals(true) ? Ok(sucesso) : BadRequest($"Operação {sucesso}, Id não localizado ou erro desconhecido...");
        }
    }
}
