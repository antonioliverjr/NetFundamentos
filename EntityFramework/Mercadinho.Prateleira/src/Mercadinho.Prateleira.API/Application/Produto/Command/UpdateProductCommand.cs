using FluentValidation.Results;
using MediatR;
using Mercadinho.Prateleira.API.Application.Produto.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Produto.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int[] IdCategorias { get; set; }
        [JsonIgnore]
        public ValidationResult Validation;

        public UpdateProductCommand(int id, string descricao, int[] idCategorias)
        {
            Id = id;
            Descricao = descricao;
            IdCategorias = idCategorias;
            var validator = new UpdateProductCommandValidation();
            Validation = validator.Validate(this);
        }
    }
}
