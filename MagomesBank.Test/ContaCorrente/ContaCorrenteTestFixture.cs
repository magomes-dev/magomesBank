using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MagomesBank.Domain.Models;
using System.Linq;

namespace MagomesBank.Test
{
    [CollectionDefinition(nameof(ContaCorrenteCollection))]
    public class ContaCorrenteCollection : ICollectionFixture<ContaCorrenteTestFixture>
    { }
    public class ContaCorrenteTestFixture : IDisposable
    {

        public ContaCorrente GetContaById(int id)
        {
            var contas = GerarContas();
            return contas.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<ContaCorrente> GerarContas()
        {
            var contas = new List<ContaCorrente>();
            contas.Add(new ContaCorrente
            {
                Id = 1,
                DataCriacao = DateTime.Now,
                Saldo = 900,
                UsuarioId = 1,
                Movimentos = new List<HistoricoMovimento> { 
                    new HistoricoMovimento { 
                        Id = 1, ContaCorrenteId = 1, 
                        DataMovimento = DateTime.Now,
                        TipoMovimento = TpOperacaoFinanceira.Deposito,
                        ValorMovimento = 1000                       
                    },
                    new HistoricoMovimento {
                        Id = 1, ContaCorrenteId = 1,
                        DataMovimento = DateTime.Now,
                        TipoMovimento = TpOperacaoFinanceira.Resgate,
                        ValorMovimento = 100
                    }
                }
            });

            contas.Add(new ContaCorrente
            {
                Id = 2,
                DataCriacao = DateTime.Now,
                Saldo = 0,
                UsuarioId = 2,                
            });

            return contas;
        }

        public void Dispose()
        {            
        }
    }
    

}
