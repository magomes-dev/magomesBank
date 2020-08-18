using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Domain.Models.Validacoes
{
    public class ResultadoValidacao
    {
        public List<string> Erros { get; set; }
        public bool Valido => Erros.Count() > 0 ? false : true;
        public ResultadoValidacao()
        {
            Erros = new List<string>();
        }

        public ResultadoValidacao Adiciona(string msg)
        {
            Erros.Add(msg);
            return this;
        }


    }
}
