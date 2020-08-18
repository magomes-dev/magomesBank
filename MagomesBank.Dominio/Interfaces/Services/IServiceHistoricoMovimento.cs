using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Interfaces
{
    public interface IServiceHistoricoMovimento 
    {
        ResultadoValidacao Add(HistoricoMovimento obj);
    }
}
