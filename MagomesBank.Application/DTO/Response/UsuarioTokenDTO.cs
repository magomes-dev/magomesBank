using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.DTO.Response
{
    public class UsuarioTokenDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
