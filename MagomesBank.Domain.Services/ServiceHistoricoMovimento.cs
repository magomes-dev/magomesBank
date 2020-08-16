using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceHistoricoMovimento : ServiceBase<HistoricoMovimento>, IRepositoryHistoricoMovimento
    {
        private readonly IRepositoryHistoricoMovimento _repositoryHistoricoMovimento;

        public ServiceHistoricoMovimento(IRepositoryHistoricoMovimento RepositoryHistoricoMovimento)
            : base(RepositoryHistoricoMovimento)
        {
            _repositoryHistoricoMovimento = RepositoryHistoricoMovimento;
        }
    }
}
