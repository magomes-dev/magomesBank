using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IServiceContaCorrente : IServiceBase<ContaCorrente>
    {
        ResultadoValidacao AbrirContaCorrente(int idUsuario);
        ContaCorrente GetByUsuario(int usuarioId);
        ResultadoValidacao Depositar(int ContaCorrenteId, decimal valor);
        ResultadoValidacao Resgatar(int ContaCorrenteId, decimal valor);
        ResultadoValidacao Pagar(int ContaCorrenteId, decimal valor);
    }
}
