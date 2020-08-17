using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.Interfaces;
using MagomesBank.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MagomesBank.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private IAplServiceContaCorrente _serviceContaCorrente;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ContaCorrenteController(
            IAplServiceContaCorrente serviceUsuario,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _serviceContaCorrente = serviceUsuario;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet("consultaPorUsuario/{id}")]
        public ContaCorrenteDTO consultaPorUsuario(int id)
        {
            return _serviceContaCorrente.GetByUsuario(id);
        }

    }
}
