using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceContaCorrente : ServiceBase<ContaCorrente>, IServiceContaCorrente
    {
        private readonly IRepositoryContaCorrente _repositoryContaCorrente;
        private ResultadoValidacao ResultadoValidacao;

        public ServiceContaCorrente(IRepositoryContaCorrente RepositoryContaCorrente)
            : base(RepositoryContaCorrente)
        {
            _repositoryContaCorrente = RepositoryContaCorrente;
            ResultadoValidacao = new ResultadoValidacao();
        }

        public ResultadoValidacao AbrirContaCorrente(int idUsuario)
        {         
            _repositoryContaCorrente.Add(new ContaCorrente
                {
                    Saldo = 0,
                    UsuarioId = idUsuario,
                    DataCriacao = DateTime.Now
                });

            return ResultadoValidacao;
        }

        public ResultadoValidacao Depositar(int ContaCorrenteId, decimal valor)
        {
            throw new NotImplementedException();
        }

        public ContaCorrente GetByUsuario(int usuarioId)
        {
            return _repositoryContaCorrente.GetByUsuario(usuarioId);
        }

        public ResultadoValidacao Pagar(int ContaCorrenteId, decimal valor)
        {
            throw new NotImplementedException();
        }

        public ResultadoValidacao Resgatar(int ContaCorrenteId, decimal valor)
        {
            throw new NotImplementedException();
        }
    }
}
