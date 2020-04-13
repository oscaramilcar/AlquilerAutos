using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bussiness.Interfaces;
using Bussiness.Repositories;

namespace Views
{
    public partial class MantenimientoEmpleado : Mantenimiento
    {

        private IEmpleadoRepository _empleadoRepository { get; }
        public MantenimientoEmpleado()
        {
            _empleadoRepository = new EmpleadoRepository();
            InitializeComponent();
        }

        public void Message(int indice, String message)
        {
            if (indice == 1)
            {
                MessageBox.Show(message, "Sistema de alquiler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (indice == 0)
            {
                MessageBox.Show(message, "Sistema de alquiler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Limpiar()
        {
            this.txtUser_emp.Text = string.Empty;
            this.txtCod_emp.Text = string.Empty;
            this.txtName_emp.Text = string.Empty;
            this.txtApe_emp.Text = string.Empty;
            this.txtDui_emp.Text = string.Empty;
            this.txtCorreo_emp.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        public override bool Guardar()
        {
            try
            {
                string res = "";
                if (this.txtName_emp.Text == string.Empty || this.txtApe_emp.Text == string.Empty || this.txtCorreo_emp.Text == string.Empty || this.txtDui_emp.Text == string.Empty || this.txtUser_emp.Text == string.Empty || this.txtCod_emp.Text == string.Empty || this.txtUserName.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorEmpleado.SetError(this.txtCod_emp, "requerido");
                    errorEmpleado.SetError(this.txtName_emp, "requerido");
                    errorEmpleado.SetError(this.txtApe_emp, "requerido");
                    errorEmpleado.SetError(this.txtCorreo_emp, "requerido");
                    errorEmpleado.SetError(this.txtDui_emp, "requerido");
                    errorEmpleado.SetError(this.txtUser_emp, "requerido");
                    errorEmpleado.SetError(this.txtUserName, "requerido");
                    errorEmpleado.SetError(this.txtPassword, "requerido");
                }
                else
                {
                    int rol_id = 2;
                    res = _empleadoRepository.Insertar(Convert.ToInt32(this.txtCod_emp.Text.Trim()), this.txtName_emp.Text.Trim(), this.txtApe_emp.Text.Trim(), txtCorreo_emp.Text.Trim(), this.txtDui_emp.Text.Trim(), Convert.ToInt32(this.txtUser_emp.Text.Trim()), this.txtUserName.Text, this.txtPassword.Text, rol_id);

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se inserto correctamente");
                    }
                    else
                    {
                        Message(0, "Error al intentar ingresar el registro");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override void Mostrar()
        {
            this.dataGridView1.DataSource = _empleadoRepository.Mostrar();
        }

        public override void Editar()
        {
            try
            {
                string res = "";
                if (this.txtName_emp.Text == string.Empty || this.txtApe_emp.Text == string.Empty || this.txtCorreo_emp.Text == string.Empty || this.txtDui_emp.Text == string.Empty || this.txtUser_emp.Text == string.Empty || this.txtCod_emp.Text == string.Empty || this.txtUserName.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorEmpleado.SetError(this.txtCod_emp, "requerido");
                    errorEmpleado.SetError(this.txtName_emp, "requerido");
                    errorEmpleado.SetError(this.txtApe_emp, "requerido");
                    errorEmpleado.SetError(this.txtCorreo_emp, "requerido");
                    errorEmpleado.SetError(this.txtDui_emp, "requerido");
                    errorEmpleado.SetError(this.txtUser_emp, "requerido");
                    errorEmpleado.SetError(this.txtUserName, "requerido");
                    errorEmpleado.SetError(this.txtPassword, "requerido");
                }
                else
                {
                    res = _empleadoRepository.Editar(Convert.ToInt32(this.txtCod_emp.Text.Trim()), this.txtName_emp.Text.Trim(), this.txtApe_emp.Text.Trim(), txtCorreo_emp.Text.Trim(), this.txtDui_emp.Text.Trim(), Convert.ToInt32(this.txtUser_emp.Text.Trim()), this.txtUserName.Text, this.txtPassword.Text);

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se actualizó");
                    }
                    else
                    {
                        Message(0, "Error al intentar editar el registro");
                    }
                }
                this.Mostrar();
                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Eliminar()
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string res = "";
                    int empleado = 0;
                    int usuario = 0;

                    empleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    usuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    res = _empleadoRepository.Eliminar(empleado, usuario);

                    if (res.Equals("Exito"))
                    {
                        this.Message(1, "Se elimino el registro");
                    }
                    else
                    {
                        this.Message(0, res);
                    }
                }
                this.Limpiar();
                this.Mostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        public override void Consultar()
        {
            this.txtCod_emp.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtUser_emp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtName_emp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtApe_emp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtDui_emp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtCorreo_emp.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.txtUserName.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            this.txtPassword.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        public override void Cancelar()
        {
            this.Limpiar();
        }
    }
}
