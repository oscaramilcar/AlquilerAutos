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
    public partial class Reserva : Form
    {
        public Reserva()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SeleccionarVehiculo seleccionarVehiculo = new SeleccionarVehiculo();
            seleccionarVehiculo.MdiParent = this.ParentForm;
            seleccionarVehiculo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeleccionarVehiculo vehiculo = new SeleccionarVehiculo();
            vehiculo.MdiParent = this.ParentForm;
            vehiculo.Show();
        }
    }
}
