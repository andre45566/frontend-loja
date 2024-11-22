using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using LojaApi.Models;

namespace LojaApi.Repositories
{
    public class usuariosRepository
    {
        private readonly string _connectionString;

        public usuariosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new MySqlConnection(_connectionString);

        public async Task<int> Cadastrarusuario(usuarios usuario)
        {
            using (var conn = Connection)
            {
                var sql = "INSERT INTO Usuarios (Nome, Email, Endereco) " +
                          "VALUES (@Nome, @Email, @Endereco);" +
                          "SELECT LAST_INSERT_ID();";

                return await conn.ExecuteScalarAsync<int>(sql, usuario);
            }
        }

        public async Task<IEnumerable<usuarios>> ListarTodososusuarios()
        {
            using (var conn = Connection)
            {
                var sql = "SELECT * FROM Usuarios";
                return await conn.QueryAsync<usuarios>(sql);
            }
        }

    }
}

