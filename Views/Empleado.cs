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
    public partial class Empleado : Form
    {
        private IEmpleadoRepository _empleadoRepository { get; }
        public Empleado()
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

        private void Mostrar()
        {
            this.dtEmpleado.DataSource = _empleadoRepository.Mostrar();
        }

        private void BuscarPorNombre()
        {
            this.dtEmpleado.DataSource = _empleadoRepository.BuscarPorNombre(this.txtBuscarEmpleado.Text.Trim());
        }

        private void Limpiar()
        {
            this.txtId.Text = string.Empty;
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtDui.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.cbRol.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                if (this.txtNombres.Text == string.Empty || this.txtApellidos.Text == string.Empty || this.txtCorreo.Text == string.Empty || this.txtDui.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.cbRol.Text == string.Empty || this.txtUserName.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorEmpleado.SetError(this.txtNombres, "requerido");
                    errorEmpleado.SetError(this.txtApellidos, "requerido");
                    errorEmpleado.SetError(this.txtCorreo, "requerido");
                    errorEmpleado.SetError(this.txtDui, "requerido");
                    errorEmpleado.SetError(this.txtTelefono, "requerido");
                    errorEmpleado.SetError(this.cbRol, "requerido");
                    errorEmpleado.SetError(this.txtUserName, "requerido");
                    errorEmpleado.SetError(this.txtPassword, "requerido");
                }
                else
                {
                    res = _empleadoRepository.Insertar(this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), txtCorreo.Text.Trim(), this.txtDui.Text.Trim(), this.txtTelefono.Text.Trim(), this.cbRol.Text, this.txtUserName.Text, this.txtPassword.Text, 2);

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se inserto correctamente");
                    }
                    else
                    {
                        Message(0, "Error al intentar ingresar el registro");
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

        private void Empleado_Load(object sender, EventArgs e)
        {
            this.txtId.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Mostrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Limpiar();
        }

        private void dtEmpleado_DoubleClick(object sender, EventArgs e)
        {
            this.txtId.Text = dtEmpleado.CurrentRow.Cells[0].Value.ToString();
            this.txtNombres.Text = dtEmpleado.CurrentRow.Cells[1].Value.ToString();
            this.txtApellidos.Text = dtEmpleado.CurrentRow.Cells[2].Value.ToString();
            this.txtCorreo.Text = dtEmpleado.CurrentRow.Cells[3].Value.ToString();
            this.txtDui.Text = dtEmpleado.CurrentRow.Cells[4].Value.ToString();
            this.txtTelefono.Text = dtEmpleado.CurrentRow.Cells[5].Value.ToString();
            this.cbRol.Text = dtEmpleado.CurrentRow.Cells[6].Value.ToString();
            this.txtUserName.Text = dtEmpleado.CurrentRow.Cells[7].Value.ToString();
            this.txtPassword.Text = dtEmpleado.CurrentRow.Cells[8].Value.ToString();
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnGuardar.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPorNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarPorNombre();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.OK)
                {
                    int id;
                    string res = "";

                    id = Convert.ToInt32(dtEmpleado.CurrentRow.Cells[0].Value);
                    res = _empleadoRepository.Eliminar(id);

                    if (res.Equals("Exito"))
                    {
                        this.Message(1, "Se elimino el registro");
                    }
                    else
                    {
                        this.Message(0, res);
                    }
                }
                this.Mostrar();
                this.Limpiar();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                if (this.txtNombres.Text == string.Empty || this.txtApellidos.Text == string.Empty || this.txtCorreo.Text == string.Empty || this.txtDui.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.cbRol.Text == string.Empty || this.txtUserName.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorEmpleado.SetError(this.txtNombres, "requerido");
                    errorEmpleado.SetError(this.txtApellidos, "requerido");
                    errorEmpleado.SetError(this.txtCorreo, "requerido");
                    errorEmpleado.SetError(this.txtDui, "requerido");
                    errorEmpleado.SetError(this.txtTelefono, "requerido");
                    errorEmpleado.SetError(this.cbRol, "requerido");
                    errorEmpleado.SetError(this.txtUserName, "requerido");
                    errorEmpleado.SetError(this.txtPassword, "requerido");
                }
                else
                {
                    res = _empleadoRepository.Editar(Convert.ToInt32(this.txtId.Text), this.txtNombres.Text.Trim(), this.txtApellidos.Text.Trim(), txtCorreo.Text.Trim(), this.txtDui.Text.Trim(), this.txtTelefono.Text.Trim(), this.cbRol.Text, this.txtUserName.Text, this.txtPassword.Text);

                    if (res.Equals("Exito"))
                    {
                        Message(1, "Registro actualizado");
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
    }
}
