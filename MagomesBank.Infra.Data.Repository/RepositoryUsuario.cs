using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Infra.Data.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Infra.Data.Repository
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly DataContext _context;
        public RepositoryUsuario(DataContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public bool ExisteUsername(string userName)
        {
            return _context.Usuarios.Any(x => x.UserName == userName);
        }

        public Usuario SingleOrDefault(string userName)
        {
            return _context.Usuarios.SingleOrDefault(x => x.UserName == userName);
        }
    }
}

