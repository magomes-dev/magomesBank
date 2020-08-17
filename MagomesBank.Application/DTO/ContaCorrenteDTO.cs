using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.DTO
{
    public class ContaCorrenteDTO
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public string NomeUsuario { get; set; }
        public IEnumerable<HistoricoMovimentoDTO> Movimentos { get; set; }

    }
}
