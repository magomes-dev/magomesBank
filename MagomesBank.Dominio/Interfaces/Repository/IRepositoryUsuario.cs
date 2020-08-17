using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        bool ExisteUsername(string userName);
        public Usuario SingleOrDefault(string userName);
    }
}
