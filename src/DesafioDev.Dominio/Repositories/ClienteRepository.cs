using Dapper;
using DesafioDev.Dominio.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DesafioDev.Dominio.Repositories
{
    public class ClienteRepository
    {
        #region Public Methods

        public int Delete(int id)
        {
            var query = @"DELETE * CLIENTE WHERE Id=@Id;";
            using (var conn = new DesafioDevConnection())
                return conn.Connection.Execute(query, new { id });
        }

        public int Insert(Cliente cliente)
        {
            var query = @"INSERT INTO CLIENTE([Nome], [Cpf], [Email], [Telefone], [DataInclusao])
                          VALUES(@Nome, @Cpf, @Email, @Telefone, @DataInclusao);";
            using (var conn = new DesafioDevConnection())
                return conn.Connection.Execute(query, cliente);
        }

        public Cliente ObterPorId(int id)
        {
            var query = @"SELECT
                                Id,
                                Cpf,
                                Nome,
                                Email,
                                Telefone,
                                DataInclusao,
                                DataAlteracao
                          FROM Cliente
                          WHERE Id = @id";
            using (var conn = new DesafioDevConnection())
                return conn.Connection.QuerySingleOrDefault<Cliente>(query, new { id });
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var query = @"SELECT
                                Id,
                                Cpf,
                                Nome,
                                Email,
                                Telefone,
                                DataInclusao,
                                DataAlteracao
                          FROM Cliente";
            using (var conn = new DesafioDevConnection())
                return conn.Connection.Query<Cliente>(query);
        }

        public int Update(Cliente cliente)
        {
            var query = @"UPDATE CLIENTE SET
                                        [Nome]=@Nome,
                                        [Cpf]=@Cpf,
                                        [Email]=@Email,
                                        [Telefone]=@Telefone,
                                        [DataAlteracao]=@DataAlteracao
                          WHERE Id=@Id;";
            using (var conn = new DesafioDevConnection())
                return conn.Connection.Execute(query, cliente);
        }

        public bool VerificarDuplicidade(int id, string nome, string cpf)
        {
            var query = @"SELECT
                                Id
                          FROM Cliente
                          WHERE Id <> @id AND
                                (Nome = @nome OR
                                 Cpf = @cpf
                                )";

            using (var conn = new DesafioDevConnection())
            {
                var result = conn.Connection.Query<Cliente>(query, new { id, nome, cpf });

                return result.Any();
            }
        }

        #endregion Public Methods
    }
}