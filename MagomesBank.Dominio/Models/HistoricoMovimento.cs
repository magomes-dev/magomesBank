using System;

namespace MagomesBank.Domain.Models
{
    public class HistoricoMovimento : Base
    {
        public int ContaCorrenteId { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal ValorMovimento { get; set; }
        public TpOperacaoFinanceira TipoMovimento { get; set; }

        public virtual ContaCorrente ContaCorrente { get; set; }

    }
}
