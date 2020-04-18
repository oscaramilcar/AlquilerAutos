using Bussiness.Interfaces;
using Bussiness.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Views
{
    public partial class Login : Form
    {
        public bool isNuevo = false;
        public bool isEditar = false;
        private IEmpleadoRepository _empleadoRepository { get; }
        public Login()
        {
            _empleadoRepository = new EmpleadoRepository();
            InitializeComponent();
        }

        public void Message(int indice, String message)
        {
            if(indice == 1)
            {
                MessageBox.Show(message, "Sistema de alquiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(indice == 0)
            {
                MessageBox.Show(message, "Sistema de alquiler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Limpiar()
        {
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable data = _empleadoRepository.Login(this.txtUsuario.Text.Trim(),this.txtPassword.Text.Trim());

            if(data.Rows.Count == 0) 
            {
                Message(0, "No puedes acceder al sistema");
            }
            else
            {
                int tipo = Convert.ToInt32(data.Rows[0]["rol"]);

                if(tipo == 1 || tipo == 2)
                {
                    Principal principal = new Principal();
                    var th = new Thread(() => Application.Run(principal));
                    principal.idEmpleado = data.Rows[0][0].ToString();
                    principal.username = data.Rows[0][1].ToString();
                    principal.rol = data.Rows[0][2].ToString();
                    th.SetApartmentState(ApartmentState.STA);
                
                    th.Start();
                    this.Close();
                }
                else
                {
                    Message(0, "No tienes los permisos para ingresar al sistema");
                }
            }
        }

    }
}
