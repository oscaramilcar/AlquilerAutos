using Bussiness.Interfaces;
using Bussiness.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class SeleccionarCliente : Form
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IClienteRepository _clienteRepository { get;  }
        public SeleccionarCliente()
        {
            _clienteRepository = new ClienteRepository();
            InitializeComponent();
        }

        private void SeleccionarCliente_Load(object sender, EventArgs e)
        {
            this.dtSeleccionarCliente.DataSource = _clienteRepository.Mostrar();
        }

        private void dtSeleccionarCliente_DoubleClick(object sender, EventArgs e)
        {
            var reserva = Reserva.GetInstancia();

            Codigo = this.dtSeleccionarCliente.CurrentRow.Cells[0].Value.ToString();
            Nombre = this.dtSeleccionarCliente.CurrentRow.Cells[2].Value.ToString();
            Apellido = this.dtSeleccionarCliente.CurrentRow.Cells[3].Value.ToString();

            reserva.SetCliente(Codigo, Nombre, Apellido);
            this.Hide();
        }
    }
}
