using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Services;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MagomesBank.Test
{
    public class ServiceRendimentoDiarioTest
    {
        [Fact(DisplayName = "Calcular Rendimento Diario Contas Correntes")]
        [Trait("Categoria", "Rendimento Diario Service Tests")]
        public void RendimentoDiarioService_RentabilizarContasCorrentes_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var rendimentoDiarioService = mocker.CreateInstance<ServiceRendimentoDiario>();

            // Act
            rendimentoDiarioService.RentabilizarContasCorrentes();

            //Assert
            mocker.GetMock<IServiceContaCorrente>().Verify(r => r.GetAll(), Times.Once);
        }
    }
}
