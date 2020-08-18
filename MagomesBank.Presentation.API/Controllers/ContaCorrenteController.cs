using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Application.DTO.Response;
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
        private readonly IAplServiceContaCorrente _serviceContaCorrente;
        private readonly AppSettings _appSettings;

        public ContaCorrenteController(
            IAplServiceContaCorrente serviceUsuario,
            IOptions<AppSettings> appSettings)
        {
            _serviceContaCorrente = serviceUsuario;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{id}/consultaPorUsuario")]
        public ContaCorrenteDTO ConsultaPorUsuario(int id)
        {
            return _serviceContaCorrente.GetByUsuario(id);
        }

        [HttpPost("{id}/depositar")]
        public IActionResult Depositar(int id, TransacaoDTO dto)
        {
            dto.ContaCorrenteId = id;
            try
            {
                var resultadoValidacao = _serviceContaCorrente.Depositar(dto);

                return Ok(new ResponseDTO
                {
                    Success = resultadoValidacao.Valido,
                    Message = resultadoValidacao.Erros
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/resgatar")]
        public IActionResult Resgatar(int id, TransacaoDTO dto)
        {
            dto.ContaCorrenteId = id;
            try
            {
                var resultadoValidacao = _serviceContaCorrente.Resgatar(dto);

                return Ok(new ResponseDTO
                {
                    Success = resultadoValidacao.Valido,
                    Message = resultadoValidacao.Erros
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/pagar")]
        public IActionResult Pagar(int id, TransacaoDTO dto)
        {
            dto.ContaCorrenteId = id;
            try
            {
                var resultadoValidacao = _serviceContaCorrente.Pagar(dto);

                return Ok(new ResponseDTO
                {
                    Success = resultadoValidacao.Valido,
                    Message = resultadoValidacao.Erros
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
