using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceRendimentoDiario : IServiceRendimentoDiario
    {
        private readonly IServiceContaCorrente _serviceContaCorrente;
        private const decimal SelicMes = 2.0M / 12;

        public ServiceRendimentoDiario(IServiceContaCorrente serviceContaCorrente)
        {
            _serviceContaCorrente = serviceContaCorrente;
        }

        private void Rentabilizar(int contaCorrenteId)
        {
            var contaCorrente = _serviceContaCorrente.GetById(contaCorrenteId);
            var rendimentoDiario = CalculaRendimentoDiario(contaCorrente.Saldo);
            _serviceContaCorrente.DepositarRentabilizacao(contaCorrenteId, rendimentoDiario);
        }

        private decimal CalculaRendimentoDiario(decimal saldo)
        {
            int totalDiasMes = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            var selicDiaria = (SelicMes / totalDiasMes) / 100;
            var rendimentoDiario = saldo * selicDiaria;
            return rendimentoDiario;
        }

        public void RentabilizarContasCorrentes()
        {
            var contas = _serviceContaCorrente.GetAll();

            foreach (var conta in contas)
            {
                if (conta.Saldo > 0) 
                    Rentabilizar(conta.Id);
            }
        }
    }
}
