using Dapper;
using System.Data;
using LojaApi.Models;
using MySql.Data.MySqlClient;

namespace LojaApi.Repositories
{
    public class produtosRepository
    {
        private readonly string _connectionString;

        public produtosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public async Task<int> Cadastrarproduto(produtos produto)
        {
            using (var conn = Connection)
            {
                var sql = "INSERT INTO Produtos (Nome, Descricao, Preco, QuantidadeEstoque) " +
                          "VALUES (@Nome, @Descricao, @Preco, @QuantidadeEstoque);" +
                          "SELECT LAST_INSERT_ID();";

                return await conn.ExecuteScalarAsync<int>(sql, produto);
            }
        }

        public async Task<IEnumerable<produtos>> Listarprodutos()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM Produtos";
                return await conn.QueryAsync<produtos>(sql);
            }
        }

        public async Task<int> Atualizarproduto(produtos produto)
        {
            using (var conn = Connection)
            {
                var sql = "UPDATE Produtos SET Nome = @Nome, Descricao = @Descricao, Preco = @Preco, " +
                          "QuantidadeEstoque = @QuantidadeEstoque WHERE Id = @Id";

                return await conn.ExecuteAsync(sql, produto);
            }
        }

        public async Task<int> Excluirproduto(int id)
        {
            using (var conn = Connection)
            {
                var sqlVerificarCarrinho = "SELECT COUNT(*) FROM Carrinho WHERE ProdutoId = @Id";
                var carrinhoCount = await conn.ExecuteScalarAsync<int>(sqlVerificarCarrinho, new { Id = id });

                if (carrinhoCount > 0)
                {
                    throw new InvalidOperationException("O produto está em um carrinho e não pode ser apagado");
                }

                var sqlPedidoAndamento = @"
                    SELECT COUNT(*)
                    FROM PedidoProdutos pp
                    JOIN Pedidos p ON pp.PedidoId = p.Id
                    WHERE pp.ProdutoId = @Id AND p.StatusPedido = 'Em andamento'";

                var pedidoExists = await conn.ExecuteScalarAsync<int>(sqlPedidoAndamento, new { Id = id });

                if (pedidoExists > 0)
                {
                    throw new InvalidOperationException("o produto ta andando e não pode ser excluído");
                }

                var sqlExcluirProduto = "DELETE FROM Produtos WHERE Id = @Id";
                return await conn.ExecuteAsync(sqlExcluirProduto, new { Id = id });
            }
        }

        public async Task<IEnumerable<produtos>> BuscarporFiltro(string? nome = null, string? descricao = null, decimal? precoMin = null, decimal? precoMax = null)
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM Produtos WHERE 1=1";

                if (!string.IsNullOrEmpty(nome))
                {
                    sql += " AND Nome LIKE @Nome";
                }
                if (!string.IsNullOrEmpty(descricao))
                {
                    sql += " AND Descricao LIKE @Descricao";
                }
                if (precoMin.HasValue)
                {
                    sql += " AND Preco >= @PrecoMin";
                }
                if (precoMax.HasValue)
                {
                    sql += " AND Preco <= @PrecoMax";
                }

                return await conn.QueryAsync<produtos>(sql, new
                {
                    Nome = $"%{nome}%",
                    Descricao = $"%{descricao}%",
                    PrecoMin = precoMin,
                    PrecoMax = precoMax
                });
            }
        }
    }
}