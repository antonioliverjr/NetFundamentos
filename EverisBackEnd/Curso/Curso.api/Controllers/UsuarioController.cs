using Curso.api.Business.Entities;
using Curso.api.Business.Repositories;
using Curso.api.Configurations;
using Curso.api.Filters;
using Curso.api.Infra.Data;
using Curso.api.Models;
using Curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Curso.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthenticationService _authenticationService;
        public UsuarioController(
            IUsuarioRepository usuarioRepository
            , IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios não informados", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Ops! Erro Interno!", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            Usuario usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if(usuario == null)
            {
                return BadRequest("E-mail informado não cadastrado!");
            }

            if(usuario.Senha != loginViewModelInput.Senha)
            {
                return BadRequest("Senha informada não corresponde a cadastrada!");
            }

            var usuarioViewModelOutput = new usuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = usuario.Login,
                Email = usuario.Email
            };
            
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);
            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistrarViewModelInput registrarViewModelInput)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            //optionsBuilder.UseSqlServer("Server=DELLJR\\SQLEXPRESS;Database=CURSOS;User ID=project;Password=Jrdbsql");
            //CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options);

            var usuario = new Usuario();
            usuario.Login = registrarViewModelInput.Login;
            usuario.Email = registrarViewModelInput.Email;
            usuario.Senha = registrarViewModelInput.Senha;
            
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", registrarViewModelInput);
        }
    }
}
