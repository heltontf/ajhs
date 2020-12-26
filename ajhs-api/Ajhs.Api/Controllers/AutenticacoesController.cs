using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ajhs.Domain.Interfaces;

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Teste");
        }
    }
}