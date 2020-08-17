using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.DTO
{
    public class HistoricoMovimentoDTO
    {
        public int? Id { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal ValorMovimento { get; set; }
        public int TipoMovimento { get; set; }

    }
}
