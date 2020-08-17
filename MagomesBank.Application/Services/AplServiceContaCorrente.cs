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
    public class AplServiceContaCorrente: IAplServiceContaCorrente
    {
        private readonly IMapper _mapper;
        private readonly IServiceContaCorrente _serviceContaCorrente;

        public AplServiceContaCorrente(IMapper mapper, IServiceContaCorrente serviceContaCorrente)
        {
            _mapper = mapper;
            _serviceContaCorrente = serviceContaCorrente;
        }


        public ResultadoValidacao Add(ContaCorrenteDTO obj)
        {
            var contaCorrente = _mapper.Map<ContaCorrenteDTO, ContaCorrente>(obj);
            return _serviceContaCorrente.Add(contaCorrente);        
        }

        public IEnumerable<ContaCorrenteDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ContaCorrenteDTO>>(_serviceContaCorrente.GetAll());
        }

        public ContaCorrenteDTO GetById(int id)
        {
            return _mapper.Map<ContaCorrenteDTO>(_serviceContaCorrente.GetById(id));
        }

        public ResultadoValidacao Remove(ContaCorrenteDTO obj)
        {
            var contaCorrente = _mapper.Map<ContaCorrenteDTO, ContaCorrente>(obj);
            return _serviceContaCorrente.Remove(contaCorrente);
        }

        public ResultadoValidacao Update(ContaCorrenteDTO obj)
        {
            var contaCorrente = _mapper.Map<ContaCorrenteDTO, ContaCorrente>(obj);
            return _serviceContaCorrente.Update(contaCorrente);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
