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
    public partial class Mantenimiento : FormBase
    {
        public Mantenimiento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eliminar();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Consultar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}