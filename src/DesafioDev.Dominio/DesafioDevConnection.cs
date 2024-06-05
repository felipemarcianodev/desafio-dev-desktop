using Microsoft.Data.SqlClient;
using System;
using System.Data.Common;

namespace DesafioDev.Dominio
{
    public class DesafioDevConnection : IDisposable
    {
        #region Private Fields

        private bool disposedValue;

        #endregion Private Fields

        #region Public Properties

        public DbConnection Connection => new SqlConnection(Runtime.ConnectionString);

        #endregion Public Properties

        #region Public Methods

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection?.Close();
                    Connection?.Dispose();
                }

                disposedValue = true;
            }
        }

        #endregion Protected Methods
    }
}