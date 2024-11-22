using LojaApi.Models;
using LojaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly usuariosRepository _usuarioRepository;

        public usuariosController(usuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<IActionResult> Cadastrarusuario([FromBody] usuarios usuario)
        {
            var usuarioId = await _usuarioRepository.Cadastrarusuario(usuario);

            return Ok(new { mensagem = "Seu Usuario existe !", usuarioId });
        }

        [HttpGet("listar-usuarios")]
        public async Task<IActionResult> ListarTodososusuarios()
        {
            var usuarios = await _usuarioRepository.ListarTodososusuarios();


            return Ok(usuarios);
        }
    }
}