using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MagomesBank.Domain.Models;
using System.Linq;
using MagomesBank.Domain.Services;

namespace MagomesBank.Test
{
    [CollectionDefinition(nameof(UsuariosTestcollection))]
    public class UsuariosTestcollection : ICollectionFixture<UsuariosTestFixture>
    { }
    public class UsuariosTestFixture : IDisposable
    {

        public Usuario GeraUsuarioInsercao()
        {
            return new Usuario
            {
                Nome = "Matheus",
                Sobrenome = "Gomes",
                UserName = "magomes",
            };
        }


        public Usuario GetUsername(string username)
        {
            var contas = GerarUsuarios();
            return contas.Where(x => x.UserName == username).FirstOrDefault();
        }

        public IEnumerable<Usuario> GerarUsuarios()
        {
            byte[] passwordHash, passwordSalt;
            ServiceUsuario.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

            var usuarios = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    Nome = "Matheus",
                    Sobrenome = "Gomes",
                    UserName = "magomes",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt

                },

                new Usuario
                {
                    Id = 2,
                    Nome = "Warren",
                    Sobrenome = "Brasil",
                    UserName = "wabrasil",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt

                }
            };

            return usuarios;
        }

        public void Dispose()
        {            
        }
    }
    

}
