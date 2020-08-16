using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Domain.Models
{
    public class Usuario: Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
