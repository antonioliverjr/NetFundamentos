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
    public class CreateProductCommand : IRequest<bool>
    {
        public string Descricao { get; set; }
        public int[] IdCategorias { get; set; }
        [JsonIgnore]
        public ValidationResult Validation;

        public CreateProductCommand(string descricao, int[] idCategorias)
        {
            Descricao = descricao;
            IdCategorias = idCategorias;
            var validator = new CreateProductCommandValidation();
            Validation = validator.Validate(this);
        }
    }
}
