using LojaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/carrinho")]
    [ApiController]
    public class CarrinhoCompras : ControllerBase
    {
        private readonly carrinhoRepository _carrinhoRepository;

        public CarrinhoCompras(carrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarProduto(int usuarioId, int produtoId, int quantidade)
        {
            await _carrinhoRepository.AdicionarProduto(usuarioId, produtoId, quantidade);

            return Ok(new { mensagem = "Produto colocado ao carrinho!" });
        }

        [HttpDelete("remover")]
        public async Task<IActionResult> RemoverProduto(int usuarioId, int produtoId)
        {
            await _carrinhoRepository.RemoverProduto(usuarioId, produtoId);

            return Ok(new { mensagem = "Produto removido do carrinho!" });
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarCarrinho(int usuarioId)
        {
            var itens = await _carrinhoRepository.ConsultarCarrinho(usuarioId);

            var valorTotal = await _carrinhoRepository.CalcularValorCarrinho(usuarioId);

            return Ok(new { itens, valorTotal });
        }
    }
}