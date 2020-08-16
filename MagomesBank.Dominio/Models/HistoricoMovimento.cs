using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Models
{
    public class HistoricoMovimento : Base
    {
        public int IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal ValorMovimento { get; set; }
        public TpOperacaoFinanceira TipoMovimento { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }

    }
}
