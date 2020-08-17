using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Models
{
    public class ContaCorrente : Base
    {
        public int UsuarioId { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual IEnumerable<HistoricoMovimento> Movimentos { get; set; }
    }
}
