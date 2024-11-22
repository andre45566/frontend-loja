using LojaApi.Models;
using LojaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class produtosController : ControllerBase
    {
        private readonly produtosRepository _produtoRepository;

        public produtosController(produtosRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarProduto([FromBody] produtos produto)
        {
            var produtoId = await _produtoRepository.Cadastrarproduto(produto);

            return Ok(new { mensagem = "Produto cadastrado!", produtoId });
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listarprodutos()
        {
            var produtos = await _produtoRepository.Listarprodutos();

            return Ok(produtos);
        }

        [HttpPut("atualizar{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] produtos produto)
        {
            produto.Id = id;
            await _produtoRepository.Atualizarproduto(produto);

            return Ok(new { mensagem = "Produto atualizado!" });
        }

        [HttpDelete("exclui{id}")]
        public async Task<IActionResult> Excluirproduto(int id)
        {
            try
            {
                await _produtoRepository.Excluirproduto(id);

                return Ok(new { mensagem = "Produto excluído!" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("buscarfiltro")]
        public async Task<IActionResult> BuscarporFiltro([FromQuery] string? nome, [FromQuery] string? descricao, [FromQuery] decimal? precoMin, [FromQuery] decimal? precoMax)
        {
            var produtos = await _produtoRepository.BuscarporFiltro(nome, descricao, precoMin, precoMax);

            return Ok(produtos);
        }
    }
}