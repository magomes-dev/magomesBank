using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MagomesBank.Application.DTO;
using MagomesBank.Application.DTO.Param;
using MagomesBank.Application.DTO.Response;
using MagomesBank.Application.Interfaces;
using MagomesBank.Domain.Interfaces;
using MagomesBank.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MagomesBank.Presentation.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IAplServiceUsuario _serviceUsuario;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsuarioController(
            IAplServiceUsuario serviceUsuario,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] LoginUsarioDTO dto)
        {
            var usuario = _serviceUsuario.Login(dto);

            if (usuario == null)
                return BadRequest(new { message = "Username ou senha inválido!" });

            var usuarioTokenDto = _mapper.Map<UsuarioTokenDTO>(usuario);

            usuarioTokenDto.Token = GerarToken(usuario.Id);

            return Ok(usuarioTokenDto);
        }

        [AllowAnonymous]
        [HttpPost("cadastro")]
        public IActionResult Register([FromBody] CreateUsuarioDTO dto)
        {
            // map model to entity
            var user = _mapper.Map<Usuario>(dto);

            try
            {
                // create user
                var resultadoValidacao = _serviceUsuario.Add(dto);

                return Ok(new ResponseDTO { 
                    Success = resultadoValidacao.Valido,
                    Message = resultadoValidacao.Erros
                });
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        private string GerarToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
