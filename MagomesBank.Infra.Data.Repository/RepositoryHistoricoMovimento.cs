using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Infra.Data.Context.Context;
using MagomesBank.Infra.Data.Context.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Infra.Data.Repository
{
    public class RepositoryHistoricoMovimento : RepositoryBase<HistoricoMovimento>, IRepositoryHistoricoMovimento
    {
        private readonly DataContext _context;
        public RepositoryHistoricoMovimento(DataContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
