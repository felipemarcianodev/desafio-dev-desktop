using System;

namespace DesafioDev.Dominio.Entities
{
    public class Cliente
    {
        #region Public Properties

        public string Cpf { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime DataInclusao { get; set; }

        public string Email { get; set; }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        #endregion Public Properties
    }
}