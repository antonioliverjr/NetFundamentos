using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services.Interfaces
{
    public interface IJogoService
    {
        Task<List<JogoViewModelOutput>> Obter(int pagina, int quantidade);
        Task<JogoViewModelOutput> Obter(Guid id);
        Task<JogoViewModelOutput> Inserir(JogoViewModelInput jogo);
        Task Atualizar(Guid id, JogoViewModelInput jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
