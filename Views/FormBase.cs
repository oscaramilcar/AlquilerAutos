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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public virtual void Eliminar()
        {

        }

        public virtual void Editar()
        {

        }

        public virtual Boolean Guardar()
        {
            return false;
        }

        public virtual void Mostrar()
        {

        }

        public virtual void Consultar()
        {

        }

        public virtual void Cancelar()
        {

        }

        public virtual void Buscar()
        {

        }
    }
}
