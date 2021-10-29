using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.OutputModel;
using ApiCatalogoJogos.Repositories.Interfaces;
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
        private readonly IJogoRepository _jogoRepository;

        public JogosController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModelOutput>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);

            if (jogos.Count().Equals(0))
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModelOutput>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoRepository.Obter(idJogo);

            if (jogo.Equals(null))
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModelOutput>> InserirJogo([FromBody] JogoViewModelInput JogoInputModel)
        {
            try 
            {
                await _jogoRepository.Inserir(JogoInputModel);

                return Ok("Cadastrado com sucesso");
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
                var jogoUpdate = await _jogoRepository.Obter(idJogo);

                if(!jogoUpdate.Equals(null))
                {
                    jogoUpdate.Nome = jogoUpdate.Nome != JogoViewModelInput.Nome && JogoViewModelInput.Nome != null ? JogoViewModelInput.Nome : jogoUpdate.Nome;
                    jogoUpdate.Produtora = jogoUpdate.Produtora != JogoViewModelInput.Produtora && JogoViewModelInput.Produtora != null ? JogoViewModelInput.Produtora : jogoUpdate.Produtora;
                    jogoUpdate.Preco = jogoUpdate.Preco != JogoViewModelInput.Preco && JogoViewModelInput.Preco != null ? JogoViewModelInput.Preco : jogoUpdate.Preco;
                    await _jogoRepository.Atualizar(jogoUpdate);
                } else
                {
                    return BadRequest("Valor de ID do Jogo informado não encontrado!");
                }
                
                return Ok("O Jogo foi atualizado com sucesso!");
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
                var jogoUpdate = await _jogoRepository.Obter(idJogo);

                if (!jogoUpdate.Equals(null))
                {
                    jogoUpdate.Preco = jogoUpdate.Preco != preco && preco != null ? preco : jogoUpdate.Preco;
                    await _jogoRepository.Atualizar(jogoUpdate);
                }
                else
                {
                    return BadRequest("Valor de ID do Jogo informado não encontrado!");
                }

                return Ok("O Preço do Jogo foi atualizado com sucesso!");
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
                var existeJogo = await _jogoRepository.Obter(idJogo);
                if (!existeJogo.Equals(null))
                {
                    await _jogoRepository.Remover(idJogo);
                }
                else
                {
                    return BadRequest("Valor de ID do Jogo informado não encontrado!");
                }
                
                return Ok($"Jogo {existeJogo.Nome} foi deletado com sucesso!");
            }
            catch(Exception ex)
            {
                return NotFound("Não existe este jogo");
            }
            
        }
    }
}
