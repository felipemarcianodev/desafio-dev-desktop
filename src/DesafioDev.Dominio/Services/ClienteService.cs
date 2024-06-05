using DesafioDev.Dominio.Entities;
using DesafioDev.Dominio.Repositories;
using System.Collections.Generic;

namespace DesafioDev.Dominio.Services
{
    public class ClienteService
    {
        #region Public Constructors

        public ClienteService()
        {
            ClienteRepository = new ClienteRepository();
        }

        #endregion Public Constructors

        #region Private Properties

        private ClienteRepository ClienteRepository { get; }

        #endregion Private Properties

        #region Public Methods

        public void Adicionar(Cliente cliente)
        {
            if (cliente == null)
            {
                return;
            }

            var usuarioCadastrado = ClienteRepository.VerificarDuplicidade(0, cliente.Nome, cliente.Cpf);
            if (usuarioCadastrado)
            {
                return;
            }

            ClienteRepository.Insert(cliente);

            return;
        }

        public void Editar(Cliente cliente)
        {
            if (cliente == null)
            {
                return;
            }

            var usuarioCadastrado = ClienteRepository.VerificarDuplicidade(cliente.Id, cliente.Nome, cliente.Cpf);
            if (usuarioCadastrado)
            {
                return;
            }

            ClienteRepository.Update(cliente);

            return;
        }

        public void Excluir(int id)
        {
            if (id == 0)
            {
                return;
            }

            var cliente = ClienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return;
            }

            ClienteRepository.Delete(id);

            return;
        }

        public Cliente ObterPorId(int id)
        {
            if (id == 0)
            {
                return null;
            }

            var cliente = ClienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            var clientes = ClienteRepository.ObterTodos();

            return clientes;
        }

        #endregion Public Methods
    }
}