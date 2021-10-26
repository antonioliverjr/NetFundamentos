using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.api.Models
{
    public class ValidaCampoViewModelOutput
    {
        public IEnumerable<string> Erros { get; private set; }
        public ValidaCampoViewModelOutput(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
