using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private ResultadoValidacao _resultadoValidacao;

        public ServiceUsuario(IRepositoryUsuario RepositoryUsuario)
            : base(RepositoryUsuario)
        {
            _repositoryUsuario = RepositoryUsuario;
        }

        public Usuario Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _repositoryUsuario.SingleOrDefault(username);

            // Verifica se usuário existe
            if (user == null)
                return null;

            // Verifica se senha está correta
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public ResultadoValidacao Add(Usuario usuario, string password)
        {
            _resultadoValidacao = new ResultadoValidacao();

            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                _resultadoValidacao.Erros.Append("Senha é requerida");
                return _resultadoValidacao;
            }

            if (_repositoryUsuario.ExisteUsername(usuario.UserName))
            {
                _resultadoValidacao.Erros.Append("Username \"" + usuario.UserName + "\" já existe");
                return _resultadoValidacao;
            }                

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            _repositoryUsuario.Add(usuario);

            return _resultadoValidacao;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("A senha não pode ter espaços em branco.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("A senha não pode ter espaços em branco.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Tamanho inválido para o hash da senha (esperado 64 bytes).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Tamanho inválido para o salt da senha (esperado 128 bytes).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
