using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Interfaces
{
    public interface IAplServiceUsuario
    {
        ResultadoValidacao Add(CreateUsuarioDTO dto);
        UsuarioDTO Login(LoginUsarioDTO dto);
    }
}
