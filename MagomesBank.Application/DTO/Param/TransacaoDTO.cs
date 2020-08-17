using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MagomesBank.Application.DTO.Param
{
    public class TransacaoDTO
    {
        [JsonIgnore] //A chave(ID) é sempre passada na URL do método API.
        public int ContaCorrenteId { get; set; }
        public decimal Valor { get; set; }
    }
}
