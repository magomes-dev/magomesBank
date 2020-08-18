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
    [Collection(nameof(UsuariosTestcollection))]
    public class ServiceUsuarioTest
    {

        readonly UsuariosTestFixture _usuarioTestFixture;

        public ServiceUsuarioTest(UsuariosTestFixture usuarioTestFixture)
        {
            _usuarioTestFixture = usuarioTestFixture;
        }

        [Fact(DisplayName = "Adicionar Usuario Valido")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Add_DeveExecutarComSucesso()
        {
            // Arrange
            var usuario = _usuarioTestFixture.GeraUsuarioInsercao();
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();

            // Act
            var resultado = usuarioService.Add(usuario, "123456");

            //Assert
            mocker.GetMock<IRepositoryUsuario>().Verify(r => r.Add(usuario), Times.Once);            
        }

        [Fact(DisplayName = "Adicionar Usuario Senha Nao Informada")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Add_DeveFalharSenhaNaoInformada()
        {
            // Arrange
            var usuario = _usuarioTestFixture.GeraUsuarioInsercao();
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();

            // Act
            var resultado = usuarioService.Add(usuario, "");

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryUsuario>().Verify(r => r.Add(usuario), Times.Never);

        }

        [Fact(DisplayName = "Adicionar Usuario Username Repetido")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Add_DeveFalharUsernameRepetido()
        {
            // Arrange
            var usuario = _usuarioTestFixture.GeraUsuarioInsercao();
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();
            mocker.GetMock<IRepositoryUsuario>().Setup(c => c.ExisteUsername(usuario.UserName))
                .Returns(true);

            // Act
            var resultado = usuarioService.Add(usuario, "136456");

            //Assert
            Assert.False(resultado.Valido);
            mocker.GetMock<IRepositoryUsuario>().Verify(r => r.Add(usuario), Times.Never);

        }

        [Fact(DisplayName = "Login Com Sucesso")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Login_DeveLogarComSucesso()
        {
            // Arrange
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();
            mocker.GetMock<IRepositoryUsuario>().Setup(c => c.SingleOrDefault("magomes"))
                .Returns(_usuarioTestFixture.GetUsername("magomes"));

            // Act
            var resultado = usuarioService.Login("magomes", "123456");

            //Assert
            Assert.NotNull(resultado);
        }

        [Fact(DisplayName = "Login Com Falha Username/Senha Nao Informado")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Login_DeveFalharUsernameSenhaNaoInformado()
        {
            // Arrange
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();

            // Act
            var resultado = usuarioService.Login("magomes", "");

            //Assert
            Assert.Null(resultado);
            mocker.GetMock<IRepositoryUsuario>().Verify(r => r.SingleOrDefault("magomes"), Times.Never);
        }

        [Fact(DisplayName = "Login Com Falha Usuario Inexistente")]
        [Trait("Categoria", "Usuario Service Tests")]
        public void UsuarioService_Login_DeveFalharUsuarioInexistente()
        {
            // Arrange
            var mocker = new AutoMocker();
            var usuarioService = mocker.CreateInstance<ServiceUsuario>();
            mocker.GetMock<IRepositoryUsuario>().Setup(c => c.SingleOrDefault("magomesteste"))
                .Returns(_usuarioTestFixture.GetUsername("magomesteste"));

            // Act
            var resultado = usuarioService.Login("magomes", "123456");

            //Assert
            Assert.Null(resultado);
            mocker.GetMock<IRepositoryUsuario>().Verify(r => r.SingleOrDefault("magomes"), Times.Once);
        }
    }
}
