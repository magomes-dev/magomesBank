using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Models
{
    public enum TpOperacaoFinanceira
    {
        Deposito = 1,
        Resgate = 2,
        Pagamento = 3,
        Rentabilizacao = 4
    }
}
