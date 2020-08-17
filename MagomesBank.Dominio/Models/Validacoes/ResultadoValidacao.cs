using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Domain.Models.Validacoes
{
    public class ResultadoValidacao
    {
        public IEnumerable<string> Erros { get; }
        public bool Valido => Erros.Count() > 0 ? false : true;
        public ResultadoValidacao()
        {
            Erros = new List<string>();
        }


    }
}
