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
    [Collection(nameof(ContaCorrenteCollection))]
    public class ServiceContaCorrenteTest
    {
        readonly ContaCorrenteTestFixture _contaCorrenteTestFixture;

        public ServiceContaCorrenteTest(ContaCorrenteTestFixture contaCorrenteTestFixture)
        {
            _contaCorrenteTestFixture = contaCorrenteTestFixture;
        }


        [Fact(DisplayName = "Adicionar Conta Corrente")]
        [Trait("Categoria", "Conta Corrente Service Tests")]
        public void ContaCorrenteService_AbrirContaCorrente_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            // Act
            var resultado = clienteService.AbrirContaCorrente(1);

            //Assert
            Assert.True(resultado.Valido);
        }
        
        [Fact(DisplayName = "Buscar Conta Corrente Por Usuario")]
        [Trait("Categoria", "Conta Corrente Service Tests")]
        public void ContaCorrenteService_GetByUsuario_DeveRetornaContaCorrente()
        {
            // Arrange
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetByUsuario(1))
                .Returns(_contaCorrenteTestFixture.GetContaById(1));

            // Act
            var resultado = clienteService.GetByUsuario(1);

            //Assert
            Assert.NotNull(resultado);
        }

        [Fact(DisplayName = "Depositar Valor com Sucesso")]
        [Trait("Categoria", "Deposito - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Depositar_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            clienteService.Depositar(1, 1000);

            //Assert
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Once);
        }

        [Fact(DisplayName = "Depositar Valor Invalido")]
        [Trait("Categoria", "Deposito - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Depositar_DeveFalharValorInvalido()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Depositar(1, -1);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Depositar em Conta Inexistente")]
        [Trait("Categoria", "Deposito - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Depositar_DeveFalharContaInexistente()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(999);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(999))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Depositar(999, 10);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Resgatar Valor com Sucesso")]
        [Trait("Categoria", "Resgate - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Resgatar_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Resgatar(1, 10);

            //Assert
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Once);
        }

        [Fact(DisplayName = "Resgatar Valor Invalido")]
        [Trait("Categoria", "Resgate - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Resgatar_DeveFalharValorInvalido()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Resgatar(1, -1);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Resgatar em Conta Inexistente")]
        [Trait("Categoria", "Resgate - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Resgatar_DeveFalharContaInexistente()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(999);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(999))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Resgatar(999, 10);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Pagar Valor com Sucesso")]
        [Trait("Categoria", "Pagar - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Pagar_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Pagar(1, 10);

            //Assert
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Once);
        }

        [Fact(DisplayName = "Pagar Valor Invalido")]
        [Trait("Categoria", "Pagar - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Pagar_DeveFalharValorInvalido()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Pagar(1, -1);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Pagar em Conta Inexistente")]
        [Trait("Categoria", "Pagar - Conta Corrente Service Tests")]
        public void ContaCorrenteService_Pagar_DeveFalharContaInexistente()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(999);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(999))
                .Returns(contaCorrente);

            // Act
            var resultado = clienteService.Pagar(999, 10);

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Never);
        }

        [Fact(DisplayName = "Depositar Rentabilização com Sucesso")]
        [Trait("Categoria", "Deposito - Conta Corrente Service Tests")]
        public void ContaCorrenteService_DepositarRentabilizacao_DeveExecutarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var contaCorrente = _contaCorrenteTestFixture.GetContaById(1);
            var clienteService = mocker.CreateInstance<ServiceContaCorrente>();

            mocker.GetMock<IRepositoryContaCorrente>().Setup(c => c.GetById(1))
                .Returns(contaCorrente);

            // Act
            clienteService.DepositarRentabilizacao(1, 1000);

            //Assert
            mocker.GetMock<IRepositoryContaCorrente>().Verify(r => r.Update(contaCorrente), Times.Once);
        }

    }
}
