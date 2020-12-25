using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ajhs.Api.Controllers
{
    [ApiController]
    [Route("autenticacoes")]
    public class AutenticacoesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Teste");
        }
    }
}