using DesafioDev.Dominio.Entities;
using DesafioDev.Dominio.Services;
using System.Data;

namespace DesafioDev
{
    public partial class frmCadastroCliente : Form
    {
        #region Public Constructors

        public frmCadastroCliente()
        {
            InitializeComponent();
            ClienteService = new ClienteService();
        }

        #endregion Public Constructors

        #region Private Properties

        private ClienteService ClienteService { get; }

        #endregion Private Properties

        #region Private Methods

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = ObterDados();
            if (cliente == null)
            {
                return;
            }

            if (cliente.Id == 0)
            {
                cliente.DataInclusao = DateTime.Now;
                ClienteService.Adicionar(cliente);
                MessageBox.Show("Cliente registrado com sucesso!");
                return;
            }
            cliente.DataAlteracao = DateTime.Now;
            ClienteService.Editar(cliente);
            MessageBox.Show("Cadastro de cliente atualizado com sucesso!");
            return;
        }

        private void frmCadastroCliente_Load(object sender, EventArgs e)
        {
            this.ObterTodos();
        }

        private Cliente ObterDados()
        {
            var cliente = new Cliente();
            cliente.Id = Convert.ToInt32(string.IsNullOrEmpty(txtId.Text) ? "0" : txtId.Text);
            cliente.Nome = txtNome.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Email = txtEmail.Text;

            if (string.IsNullOrWhiteSpace(cliente.Nome) ||
                string.IsNullOrWhiteSpace(cliente.Cpf) ||
                string.IsNullOrWhiteSpace(cliente.Telefone) ||
                string.IsNullOrWhiteSpace(cliente.Email))
            {
                MessageBox.Show("Informe todos os campos do formulário!");
                return null;
            }

            return cliente;
        }


        private void ObterTodos()
        {
            var lista = ClienteService.ObterTodos();

            dgvClientes.DataSource = lista;
        }
        #endregion Private Methods
    }
}