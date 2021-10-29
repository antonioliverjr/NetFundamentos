using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories.Interfaces
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Obter(int pagina, int quantidade);
        Task<Jogo> Obter(Guid id);
        Task Inserir(JogoViewModelInput jogo);
        Task Atualizar(Jogo jogo);
        Task Remover(Guid id);
    }
}
