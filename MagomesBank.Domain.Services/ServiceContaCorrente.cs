using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceContaCorrente : ServiceBase<ContaCorrente>, IServiceContaCorrente
    {
        private readonly IRepositoryContaCorrente _repositoryContaCorrente;

        public ServiceContaCorrente(IRepositoryContaCorrente RepositoryContaCorrente)
            : base(RepositoryContaCorrente)
        {
            _repositoryContaCorrente = RepositoryContaCorrente;
        }
    }
}
