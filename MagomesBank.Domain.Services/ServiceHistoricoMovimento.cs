using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Services
{
    public class ServiceHistoricoMovimento : IServiceHistoricoMovimento
    {
        private readonly IRepositoryHistoricoMovimento _repositoryHistoricoMovimento;
        private ResultadoValidacao ResultadoValidacao;

        public ServiceHistoricoMovimento(IRepositoryHistoricoMovimento RepositoryHistoricoMovimento)
        {
            _repositoryHistoricoMovimento = RepositoryHistoricoMovimento;
            ResultadoValidacao = new ResultadoValidacao();
        }

        public ResultadoValidacao Add(HistoricoMovimento obj)
        {
            obj.DataMovimento = DateTime.Now;
            _repositoryHistoricoMovimento.Add(obj);
            return ResultadoValidacao;
        }
    }
}
