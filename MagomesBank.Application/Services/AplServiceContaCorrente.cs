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
    public class AplServiceContaCorrente: IAplServiceContaCorrente
    {
        private readonly IMapper _mapper;
        private readonly IServiceContaCorrente _serviceContaCorrente;

        public AplServiceContaCorrente(IMapper mapper, IServiceContaCorrente serviceContaCorrente)
        {
            _mapper = mapper;
            _serviceContaCorrente = serviceContaCorrente;
        }

        public ContaCorrenteDTO GetById(int id)
        {
            return _mapper.Map<ContaCorrenteDTO>(_serviceContaCorrente.GetById(id));
        }

        public ContaCorrenteDTO GetByUsuario(int usuarioId)
        {
            return _mapper.Map<ContaCorrenteDTO>(_serviceContaCorrente.GetByUsuario(usuarioId));
        }

        public ResultadoValidacao Depositar(TransacaoDTO dto)
        {
            return _serviceContaCorrente.Depositar(dto.ContaCorrenteId, dto.Valor);
        }

        public ResultadoValidacao Pagar(TransacaoDTO dto)
        {
            return _serviceContaCorrente.Pagar(dto.ContaCorrenteId, dto.Valor);
        }

        public ResultadoValidacao Resgatar(TransacaoDTO dto)
        {
            return _serviceContaCorrente.Resgatar(dto.ContaCorrenteId, dto.Valor);
        }
    }
}
