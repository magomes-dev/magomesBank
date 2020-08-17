using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Infra.Data.Context.Context;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}

