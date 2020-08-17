using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.Interfaces;
using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using MagomesBank.Domain.Models.Validacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagomesBank.Application.Services
{
    public class AplServiceHistoricoMovimento : IAplServiceHistoricoMovimento
    {
        private readonly IMapper _mapper;
        private readonly IServiceHistoricoMovimento _serviceHistoricoMovimento;

        public AplServiceHistoricoMovimento(IMapper mapper, IServiceHistoricoMovimento serviceHistoricoMovimento)
        {
            _mapper = mapper;
            _serviceHistoricoMovimento = serviceHistoricoMovimento;
        }


        public ResultadoValidacao Add(HistoricoMovimentoDTO obj)
        {
            var historicoMovimento = _mapper.Map<HistoricoMovimentoDTO, HistoricoMovimento>(obj);
            return _serviceHistoricoMovimento.Add(historicoMovimento);        
        }

        public IEnumerable<HistoricoMovimentoDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<HistoricoMovimentoDTO>>(_serviceHistoricoMovimento.GetAll());
        }

        public HistoricoMovimentoDTO GetById(int id)
        {
            return _mapper.Map<HistoricoMovimentoDTO>(_serviceHistoricoMovimento.GetById(id));
        }

        public ResultadoValidacao Remove(HistoricoMovimentoDTO obj)
        {
            var historicoMovimento = _mapper.Map<HistoricoMovimentoDTO, HistoricoMovimento>(obj);
            return _serviceHistoricoMovimento.Remove(historicoMovimento);
        }

        public ResultadoValidacao Update(HistoricoMovimentoDTO obj)
        {
            var historicoMovimento = _mapper.Map<HistoricoMovimentoDTO, HistoricoMovimento>(obj);
            return _serviceHistoricoMovimento.Update(historicoMovimento);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
