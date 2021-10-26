using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.OutputModel;
using ApiCatalogoJogos.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModelOutput>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModelOutput>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModelOutput>> InserirJogo([FromBody] JogoViewModelInput JogoViewModelInput)
        {
            try 
            {
                var jogo = await _jogoService.Inserir(JogoViewModelInput);
                
                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoViewModelInput JogoViewModelInput)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, JogoViewModelInput);
                
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> Atualizarjogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Remover(idJogo);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }
    }
}
