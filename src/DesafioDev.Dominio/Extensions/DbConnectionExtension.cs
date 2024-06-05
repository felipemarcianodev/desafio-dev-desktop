using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DesafioDev.Dominio.Extensions
{
    public static class DbConnectionExtension
    {
        #region Public Methods

        public static DbConnection NewConnection(this DbConnection connection)
        {
            var novaConexao = new SqlConnection(connection.ConnectionString);
            return novaConexao;
        }

        #endregion Public Methods
    }
}