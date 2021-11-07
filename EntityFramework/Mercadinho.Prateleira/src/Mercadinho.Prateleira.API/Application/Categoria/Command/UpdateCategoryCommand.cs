using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Mercadinho.Prateleira.API.Application.Categoria.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.API.Application.Categoria.Command
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [JsonIgnore]
        public ValidationResult Validation { get; }
        public UpdateCategoryCommand(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            var validator = new UpdateCategoryCommandValidator();
            Validation = validator.Validate(this);
        }
    }
}
