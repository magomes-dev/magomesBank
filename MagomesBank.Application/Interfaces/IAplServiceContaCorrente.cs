using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Interfaces
{
    public interface IAplServiceContaCorrente
    {
        ContaCorrenteDTO GetById(int id);
        ContaCorrenteDTO GetByUsuario(int usuarioId);
        ResultadoValidacao Depositar(TransacaoDTO dto);
        ResultadoValidacao Resgatar(TransacaoDTO dto);
        ResultadoValidacao Pagar(TransacaoDTO dto);
    }
}
