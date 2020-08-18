using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Services;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MagomesBank.Test
{
    public class ServiceHistoricoMovimentoTest
    {
        [Fact(DisplayName = "Adicionar Historico de Movimento")]
        [Trait("Categoria", "Historico Movimento Service Tests")]
        public void RendimentoDiarioService_RentabilizarContasCorrentes_DeveExecutarComSucesso()
        {
            // Arrange
            var historicoMovimento = new HistoricoMovimento {
                ContaCorrenteId = 1,
                ValorMovimento = 1000,
                TipoMovimento = TpOperacaoFinanceira.Deposito
            };

            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ServiceHistoricoMovimento>();

            // Act
            clienteService.Add(historicoMovimento);

            //Assert
            mocker.GetMock<IRepositoryHistoricoMovimento>().Verify(r => r.Add(historicoMovimento), Times.Once);
        }
    }
}

