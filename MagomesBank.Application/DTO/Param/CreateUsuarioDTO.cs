using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.DTO.Param
{
    public class CreateUsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
