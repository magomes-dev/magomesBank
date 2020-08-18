using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IServiceRendimentoDiario
    {
        abstract void Rentabilizar(int contaCorrenteId);
        public void RentabilizarContasCorrentes();
    }
}
