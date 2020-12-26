using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ajhs.Domain.Interfaces;
using Ajhs.Api.Models.Usuario;
using Ajhs.Domain.Models;

namespace Ajhs.Api.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("{login}")]
        public async Task<IActionResult> Get(string login)
        {
            var usuario = await _usuarioRepository.Obter(login);

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IncluirUsuarioModel model)
        {
            var usuario = new Usuario(model.Nome, model.Login, model.Email, model.Senha);

            await _usuarioRepository.Incluir(usuario);

            return Created($"usuarios/{usuario.Login}", usuario);
        }
    }
}