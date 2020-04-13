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
    public partial class Cliente : Form
    {
        public IClienteRepository _clienteRepository;
        public Cliente()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
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
            this.dtCliente.DataSource = _clienteRepository.Mostrar();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.btnEliminar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Mostrar();
        }

        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.dtFechaNac.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDui.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtLicencia.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                if (this.txtCodigo.Text == string.Empty || this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.dtFechaNac.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.txtDui.Text == string.Empty || this.txtDireccion.Text == string.Empty || this.txtCorreo.Text == string.Empty || this.txtLicencia.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtNombre, "requerido");
                    errorControles.SetError(this.txtApellido, "requerido");
                    errorControles.SetError(this.dtFechaNac, "requerido");
                    errorControles.SetError(this.txtTelefono, "requerido");
                    errorControles.SetError(this.txtDui, "requerido");
                    errorControles.SetError(this.txtDireccion, "requerido");
                    errorControles.SetError(this.txtCorreo, "requerido");
                    errorControles.SetError(this.txtLicencia, "requerido");
                }
                else
                {
                    res = _clienteRepository.Insertar(this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim(), this.txtApellido.Text.Trim(), this.dtFechaNac.Value, this.txtTelefono.Text.Trim(), this.txtDui.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtCorreo.Text.Trim(), this.txtLicencia.Text.Trim());

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                if (this.txtCodigo.Text == string.Empty || this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty || this.dtFechaNac.Text == string.Empty || this.txtTelefono.Text == string.Empty || this.txtDui.Text == string.Empty || this.txtDireccion.Text == string.Empty || this.txtCorreo.Text == string.Empty || this.txtLicencia.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtNombre, "requerido");
                    errorControles.SetError(this.txtApellido, "requerido");
                    errorControles.SetError(this.dtFechaNac, "requerido");
                    errorControles.SetError(this.txtTelefono, "requerido");
                    errorControles.SetError(this.txtDui, "requerido");
                    errorControles.SetError(this.txtDireccion, "requerido");
                    errorControles.SetError(this.txtCorreo, "requerido");
                    errorControles.SetError(this.txtLicencia, "requerido");
                }
                else
                {
                    res = _clienteRepository.Editar(this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim(), this.txtApellido.Text.Trim(), this.dtFechaNac.Value, this.txtTelefono.Text.Trim(), this.txtDui.Text.Trim(), this.txtDireccion.Text.Trim(), this.txtCorreo.Text.Trim(), this.txtLicencia.Text.Trim());

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro actualizo");
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

        private void dtCliente_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = dtCliente.CurrentRow.Cells[0].Value.ToString();
            this.txtNombre.Text = dtCliente.CurrentRow.Cells[1].Value.ToString();
            this.txtApellido.Text = dtCliente.CurrentRow.Cells[2].Value.ToString();
            this.dtFechaNac.Value = Convert.ToDateTime(dtCliente.CurrentRow.Cells[3].Value);
            this.txtTelefono.Text = dtCliente.CurrentRow.Cells[4].Value.ToString();
            this.txtDui.Text = dtCliente.CurrentRow.Cells[5].Value.ToString();
            this.txtDireccion.Text = dtCliente.CurrentRow.Cells[6].Value.ToString();
            this.txtCorreo.Text = dtCliente.CurrentRow.Cells[7].Value.ToString();
            this.txtLicencia.Text = dtCliente.CurrentRow.Cells[8].Value.ToString();
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.txtCodigo.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string id;
                    string res = "";

                    id = dtCliente.CurrentRow.Cells[0].Value.ToString();
                    res = _clienteRepository.Eliminar(id);

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
               dtCliente.DataSource = _clienteRepository.BuscarPorCodigo(this.txtBuscarCliente.Text.Trim());
            }else if (cbBuscar.Text.Equals("DUI"))
            {
                dtCliente.DataSource = _clienteRepository.BuscarPorDui(this.txtBuscarCliente.Text.Trim());
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                dtCliente.DataSource = _clienteRepository.BuscarPorNombre(this.txtBuscarCliente.Text.Trim());
            }
        }
    }
}
