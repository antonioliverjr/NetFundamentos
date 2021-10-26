using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.OutputModel;
using ApiCatalogoJogos.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Services
{
    public class JogoService : IJogoService
    {
        public Task Atualizar(Guid id, JogoViewModelInput jogo)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Guid id, double preco)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModelOutput> Inserir(JogoViewModelInput jogo)
        {
            throw new NotImplementedException();
        }

        public Task<List<JogoViewModelOutput>> Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<JogoViewModelOutput> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
