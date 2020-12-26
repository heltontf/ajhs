using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ajhs.Domain.Interfaces;
using Ajhs.Domain.Models;
using Ajhs.Api.Models.Autenticacao;

namespace Ajhs.Api.Controllers
{
    [ApiController]
    [Route("autenticacoes")]
    public class AutenticacoesController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacoesController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AutenticacaoModel model)
        {
            var usuario = await _usuarioRepository.Obter(model.Login);

            if (usuario == null)
                return BadRequest("Usuário inválido!");

            var senhaCriptografada = new Senha(model.Senha);

            if (usuario.Senha != senhaCriptografada.Valor)
                return BadRequest("Senha inválida!");

            return Ok("Ok");
        }
    }
}