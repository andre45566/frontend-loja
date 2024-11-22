using LojaApi.Repositories;
using LojaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class pedidoController : ControllerBase
    {
        private readonly pedidosRepository _pedidoRepository;

        public pedidoController(pedidosRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CriarPedido(int usuarioId)
        {
            try
            {
                var pedidoId = await _pedidoRepository.Criarpedido(usuarioId);

                return Ok(new { mensagem = "Pedido criado", pedidoId });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listarpedidosusuario(int usuarioId)
        {
            var pedidos = await _pedidoRepository.Listarpedidosusuario(usuarioId);

            return Ok(pedidos);
        }

        [HttpGet("consultar")]
        public async Task<IActionResult> Consultarpedidos(int pedidoId)
        {
            var status = await _pedidoRepository.Consultarpedidos(pedidoId);

            return Ok(new { pedidoId, status });
        }

        [HttpGet("historico")]
        public async Task<IActionResult> Consultarhistorico(int usuarioId)
        {
            var historicoPedidos = await _pedidoRepository.Consultarhistorico(usuarioId);

            return Ok(historicoPedidos);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizarpedido(int pedidoId, [FromBody] string novoStatus)
        {
            try
            {
                await _pedidoRepository.Atualizarpedido(pedidoId, novoStatus);

                return Ok(new { mensagem = "Status atualizado" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}