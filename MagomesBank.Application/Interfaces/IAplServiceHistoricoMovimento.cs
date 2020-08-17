using MagomesBank.Application.DTO;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Interfaces
{
    public interface IAplServiceHistoricoMovimento
    {
        ResultadoValidacao Add(HistoricoMovimentoDTO dto);
        HistoricoMovimentoDTO GetById(int id);
        IEnumerable<HistoricoMovimentoDTO> GetAll();
        ResultadoValidacao Update(HistoricoMovimentoDTO dto);
        ResultadoValidacao Remove(HistoricoMovimentoDTO dto);
        void Dispose();
    }
}
