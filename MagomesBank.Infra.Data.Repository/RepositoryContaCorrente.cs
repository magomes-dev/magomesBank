using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using System.Linq;
using MagomesBank.Infra.Data.Context.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace MagomesBank.Infra.Data.Repository
{
    public class RepositoryContaCorrente : RepositoryBase<ContaCorrente>, IRepositoryContaCorrente
    {
        private readonly DataContext _context;
        public RepositoryContaCorrente(DataContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public ContaCorrente GetByUsuario(int UsuarioId)
        {
            return _context.ContasCorrentes.Include(x => x.Movimentos).FirstOrDefault(x => x.UsuarioId == UsuarioId);
        }
    }
}

