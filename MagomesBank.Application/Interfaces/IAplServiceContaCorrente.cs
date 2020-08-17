using MagomesBank.Application.DTO;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Interfaces
{
    public interface IAplServiceContaCorrente
    {
        ResultadoValidacao Add(ContaCorrenteDTO dto);
        ContaCorrenteDTO GetById(int id);
        IEnumerable<ContaCorrenteDTO> GetAll();
        ResultadoValidacao Update(ContaCorrenteDTO dto);
        ResultadoValidacao Remove(ContaCorrenteDTO dto);
        void Dispose();
    }
}
