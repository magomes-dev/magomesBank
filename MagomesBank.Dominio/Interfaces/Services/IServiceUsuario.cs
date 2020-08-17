using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        public ResultadoValidacao Add(Usuario usuario, string password);
        public Usuario Login(string username, string password);
    }
}
