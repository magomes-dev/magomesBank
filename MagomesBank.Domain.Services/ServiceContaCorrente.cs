﻿using MagomesBank.Domain.Interfaces;
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
        private readonly IServiceHistoricoMovimento _serviceHistoricoMovimento;
        private ResultadoValidacao ResultadoValidacao;

        public ServiceContaCorrente(
            IRepositoryContaCorrente RepositoryContaCorrente, 
            IServiceHistoricoMovimento ServiceHistoricoMovimento)
            : base(RepositoryContaCorrente)
        {
            _repositoryContaCorrente = RepositoryContaCorrente;
            _serviceHistoricoMovimento = ServiceHistoricoMovimento;
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

        public ResultadoValidacao Depositar(int contaCorrenteId, decimal valor)
        {
            var contaCorrente = _repositoryContaCorrente.GetById(contaCorrenteId);

            if (contaCorrente == null)
            {
                ResultadoValidacao.Erros.Append("Conta Corrente não encontrada");
                return ResultadoValidacao;
            }

            contaCorrente.Saldo += valor;

            _repositoryContaCorrente.Update(contaCorrente);

            ResultadoValidacao = _serviceHistoricoMovimento.Add(new HistoricoMovimento
            {
                TipoMovimento = TpOperacaoFinanceira.Deposito,
                ValorMovimento = valor,
                ContaCorrenteId = contaCorrenteId
            });

            return ResultadoValidacao;
        }

        public ContaCorrente GetByUsuario(int usuarioId)
        {
            return _repositoryContaCorrente.GetByUsuario(usuarioId);
        }

        public ResultadoValidacao Pagar(int contaCorrenteId, decimal valor)
        {
            var contaCorrente = _repositoryContaCorrente.GetById(contaCorrenteId);

            if (contaCorrente == null)
            {
                ResultadoValidacao.Erros.Append("Conta Corrente não encontrada");
                return ResultadoValidacao;
            }

            if (contaCorrente.Saldo < valor)
            {
                ResultadoValidacao.Erros.Append("Saldo insuficiente");
                return ResultadoValidacao;
            }

            contaCorrente.Saldo -= valor;

            _repositoryContaCorrente.Update(contaCorrente);

            ResultadoValidacao = _serviceHistoricoMovimento.Add(new HistoricoMovimento
            {
                TipoMovimento = TpOperacaoFinanceira.Pagamento,
                ValorMovimento = valor,
                ContaCorrenteId = contaCorrenteId
            });

            return ResultadoValidacao;
        }

        public ResultadoValidacao DepositarRentabilizacao(int contaCorrenteId, decimal valor)
        {
            var contaCorrente = _repositoryContaCorrente.GetById(contaCorrenteId);

            contaCorrente.Saldo += valor;

            _repositoryContaCorrente.Update(contaCorrente);

            ResultadoValidacao = _serviceHistoricoMovimento.Add(new HistoricoMovimento
            {
                TipoMovimento = TpOperacaoFinanceira.Rentabilizacao,
                ValorMovimento = valor,
                ContaCorrenteId = contaCorrenteId
            });

            return ResultadoValidacao;
        }

        public ResultadoValidacao Resgatar(int contaCorrenteId, decimal valor)
        {
            var contaCorrente = _repositoryContaCorrente.GetById(contaCorrenteId);

            if (contaCorrente == null)
            {
                ResultadoValidacao.Erros.Append("Conta Corrente não encontrada");
                return ResultadoValidacao;
            }

            if (contaCorrente.Saldo < valor)
            {
                ResultadoValidacao.Erros.Append("Saldo insuficiente");
                return ResultadoValidacao;
            }

            contaCorrente.Saldo -= valor;

            _repositoryContaCorrente.Update(contaCorrente);

            ResultadoValidacao = _serviceHistoricoMovimento.Add(new HistoricoMovimento
            {
                TipoMovimento = TpOperacaoFinanceira.Resgate,
                ValorMovimento = valor,
                ContaCorrenteId = contaCorrenteId
            });

            return ResultadoValidacao;
        }
    }
}
