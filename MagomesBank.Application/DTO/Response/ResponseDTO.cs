using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.DTO.Response
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Message { get; set; }
    }
}
