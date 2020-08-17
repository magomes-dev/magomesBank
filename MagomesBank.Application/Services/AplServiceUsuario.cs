using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Application.Interfaces;
using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Services
{
    public class AplServiceUsuario : IAplServiceUsuario
    {
        private readonly IMapper _mapper;
        private readonly IServiceUsuario _serviceUsuario;

        public AplServiceUsuario(IMapper mapper, IServiceUsuario serviceUsuario)
        {
            _mapper = mapper;
            _serviceUsuario = serviceUsuario;
        }

        public ResultadoValidacao Add(CreateUsuarioDTO dto)
        {
            var entidade = _mapper.Map<Usuario>(dto);
            return _serviceUsuario.Add(entidade, dto.Password);
        }

        public UsuarioDTO Login(LoginUsarioDTO dto)
        {
            return _mapper.Map<UsuarioDTO>(_serviceUsuario.Login(dto.Username, dto.Password));
        }
    }
}
