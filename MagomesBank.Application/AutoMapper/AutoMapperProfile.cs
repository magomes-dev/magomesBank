using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Application.DTO.Response;
using MagomesBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContaCorrente, ContaCorrenteDTO>();
            CreateMap<ContaCorrenteDTO, ContaCorrente>();

            CreateMap<HistoricoMovimento, HistoricoMovimentoDTO>();
            CreateMap<HistoricoMovimentoDTO, HistoricoMovimento>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Usuario, UsuarioTokenDTO>();
            CreateMap<UsuarioTokenDTO, Usuario>();

            CreateMap<Usuario, CreateUsuarioDTO>();
            CreateMap<CreateUsuarioDTO, Usuario>();          


        }
    }
}
