using ApiCatalogoJogos.Entities;
using ApiCatalogoJogos.Models.InputModel;
using ApiCatalogoJogos.Models.OutputModel;
using ApiCatalogoJogos.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly SqlConnection sqlConnection;

        public JogoRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task Atualizar(Jogo jogo)
        {
            var comando = "[dbo].[AtualizarJogo]";
            await sqlConnection.OpenAsync();
            SqlCommand queryDb = new SqlCommand(comando, sqlConnection);
            queryDb.CommandType = CommandType.StoredProcedure;
            queryDb.Parameters.Add(new SqlParameter("@Id", jogo.Id));
            queryDb.Parameters.Add(new SqlParameter("@Nome", jogo.Nome));
            queryDb.Parameters.Add(new SqlParameter("@Produtora", jogo.Produtora));
            queryDb.Parameters.Add(new SqlParameter("@Preco", jogo.Preco.ToString().Replace(",", ".")));
            await queryDb.ExecuteReaderAsync();
            await sqlConnection.CloseAsync();
        }

        public async Task Inserir(JogoViewModelInput jogoInput)
        {
            var comando = "[dbo].[InserirJogo]";

            await sqlConnection.OpenAsync();
            SqlCommand queryDb = new SqlCommand(comando, sqlConnection);
            queryDb.CommandType = CommandType.StoredProcedure;
            queryDb.Parameters.Add(new SqlParameter("@Nome", jogoInput.Nome));
            queryDb.Parameters.Add(new SqlParameter("@Produtora", jogoInput.Produtora));
            queryDb.Parameters.Add(new SqlParameter("@Preco", jogoInput.Preco.ToString().Replace(",", ".")));
            await queryDb.ExecuteReaderAsync();
            await sqlConnection.CloseAsync();
        }

        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            var jogos = new List<Jogo>();
            var comando = "[dbo].[ObterJogosPaginados]";
            await sqlConnection.OpenAsync();
            SqlCommand queryDb = new SqlCommand(comando, sqlConnection);
            queryDb.CommandType = CommandType.StoredProcedure;
            queryDb.Parameters.Add(new SqlParameter("@pagina", pagina));
            queryDb.Parameters.Add(new SqlParameter("@quantidade", quantidade));
            SqlDataReader jogoResult = await queryDb.ExecuteReaderAsync();

            while(jogoResult.Read())
            {
                jogos.Add(new Jogo
                {
                    Id = (Guid)jogoResult["Id"],
                    Nome = (string)jogoResult["Nome"],
                    Produtora = (string)jogoResult["Produtora"],
                    Preco = (double)jogoResult["Preco"]
                });
            }

            await sqlConnection.CloseAsync();

            return jogos;
        }

        public async Task<Jogo> Obter(Guid id)
        {
            Jogo jogo = null;
            var comando = "[dbo].[ObterJogosPorId]";
            await sqlConnection.OpenAsync();
            SqlCommand queryDb = new SqlCommand(comando, sqlConnection);
            queryDb.CommandType = CommandType.StoredProcedure;
            queryDb.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader jogoResult = await queryDb.ExecuteReaderAsync();

            while(jogoResult.Read())
            {
                jogo = new Jogo
                {
                    Id = (Guid)jogoResult["Id"],
                    Nome = (string)jogoResult["Nome"],
                    Produtora = (string)jogoResult["Produtora"],
                    Preco = (double)jogoResult["Preco"]
                };
            }
            
            await sqlConnection.CloseAsync();

            return jogo;
        }

        public async Task Remover(Guid id)
        {
            var comando = "[dbo].[RemoverJogo]";

            await sqlConnection.OpenAsync();
            SqlCommand queryDb = new SqlCommand(comando, sqlConnection);
            queryDb.CommandType = CommandType.StoredProcedure;
            queryDb.Parameters.Add(new SqlParameter("@Id", id));
            await queryDb.ExecuteReaderAsync();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
