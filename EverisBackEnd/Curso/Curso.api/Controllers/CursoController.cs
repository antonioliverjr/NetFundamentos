using Curso.api.Business.Entities;
using Curso.api.Business.Repositories;
using Curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [SwaggerResponse(statusCode:201, description:"Sucesso ao Cadastrar um curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public IActionResult Post(CursoViewModelInput cursoViewModelInput)
        {
            Cursos curso = new Cursos();
            curso.Nome = cursoViewModelInput.Nome;
            curso.Descricao = cursoViewModelInput.Descricao;
            curso.CodigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            _cursoRepository.Adicionar(curso);
            _cursoRepository.Commit();

            return Created("", cursoViewModelInput);
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CursoViewModelOutput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = _cursoRepository.ObterPorUsuario(codigoUsuario)
                .Select(c => new CursoViewModelOutput()
                {
                    Nome = c.Nome,
                    Descricao = c.Descricao,
                    Login = c.Usuario.Login
                });

            return Ok(cursos);
        }
    }
}
