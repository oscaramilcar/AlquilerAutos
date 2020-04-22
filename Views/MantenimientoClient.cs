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
    public partial class MantenimientoCliente : Mantenimiento
    {
        private IClienteRepository _clienteRepository { get; }

        public MantenimientoCliente()
        {
            _clienteRepository = new ClienteRepository();
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
            this.txtCod_client.Text = string.Empty;
            this.txtUser_client.Text = string.Empty;
            this.txtPass_client.Text = string.Empty;
            this.txtCod_user_client.Text = string.Empty;
            this.txtDui_client.Text = string.Empty;
            this.txtName_client.Text = string.Empty;
            this.txtApe_client.Text = string.Empty;
            this.txtTel_client.Text = string.Empty;
            this.txtCorreo_client.Text = string.Empty;
            this.txtDir_client.Text = string.Empty;
            this.txtLic_client.Text = string.Empty;
        }

        public override bool Guardar()
        {
            try
            {
                string res = "";
                if (this.txtCod_client.Text == string.Empty || this.txtUser_client.Text == string.Empty || this.txtPass_client.Text == string.Empty || this.txtCod_user_client.Text == string.Empty || this.txtDui_client.Text == string.Empty || this.txtName_client.Text == string.Empty || this.txtApe_client.Text == string.Empty || this.txtTel_client.Text == string.Empty || this.txtCorreo_client.Text == string.Empty || this.txtDir_client.Text == string.Empty || this.txtLic_client.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtCod_client, "requerido");
                    errorControles.SetError(this.txtUser_client, "requerido");
                    errorControles.SetError(this.txtPass_client, "requerido");
                    errorControles.SetError(this.txtCod_user_client, "requerido");
                    errorControles.SetError(this.txtDui_client, "requerido");
                    errorControles.SetError(this.txtName_client, "requerido");
                    errorControles.SetError(this.txtApe_client, "requerido");
                    errorControles.SetError(this.txtTel_client, "requerido");
                    errorControles.SetError(this.txtDir_client, "requerido");
                    errorControles.SetError(this.txtCorreo_client, "requerido");
                    errorControles.SetError(this.txtLic_client, "requerido");
                }
                else
                {
                    res = _clienteRepository.Insertar(Convert.ToInt32(this.txtCod_user_client.Text.Trim()), this.txtUser_client.Text.Trim(), this.txtPass_client.Text.Trim(), Convert.ToInt32(this.txtCod_client.Text.Trim()), this.txtDui_client.Text.Trim(), txtName_client.Text.Trim(), this.txtApe_client.Text.Trim(), this.txtTel_client.Text.Trim(), this.txtCorreo_client.Text.Trim(), this.txtDir_client.Text.Trim(), this.txtLic_client.Text.Trim(), 3);

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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public override void Editar()
        {
            try
            {
                string res = "";
                if (this.txtCod_client.Text == string.Empty || this.txtUser_client.Text == string.Empty || this.txtPass_client.Text == string.Empty || this.txtCod_user_client.Text == string.Empty || this.txtDui_client.Text == string.Empty || this.txtName_client.Text == string.Empty || this.txtApe_client.Text == string.Empty || this.txtTel_client.Text == string.Empty || this.txtCorreo_client.Text == string.Empty || this.txtDir_client.Text == string.Empty || this.txtLic_client.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtCod_client, "requerido");
                    errorControles.SetError(this.txtUser_client, "requerido");
                    errorControles.SetError(this.txtPass_client, "requerido");
                    errorControles.SetError(this.txtCod_user_client, "requerido");
                    errorControles.SetError(this.txtDui_client, "requerido");
                    errorControles.SetError(this.txtName_client, "requerido");
                    errorControles.SetError(this.txtApe_client, "requerido");
                    errorControles.SetError(this.txtTel_client, "requerido");
                    errorControles.SetError(this.txtDir_client, "requerido");
                    errorControles.SetError(this.txtCorreo_client, "requerido");
                    errorControles.SetError(this.txtLic_client, "requerido");
                }
                else
                {
                    res = _clienteRepository.Editar(Convert.ToInt32(this.txtCod_client.Text.Trim()), this.txtUser_client.Text.Trim(), this.txtPass_client.Text.Trim(), Convert.ToInt32(this.txtCod_user_client.Text.Trim()), this.txtDui_client.Text.Trim(), txtName_client.Text.Trim(), this.txtApe_client.Text.Trim(), this.txtTel_client.Text.Trim(), this.txtCorreo_client.Text.Trim(), this.txtDir_client.Text.Trim(), this.txtLic_client.Text.Trim());

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
                    usuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                    res = _clienteRepository.Eliminar(empleado, usuario);

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

        public override void Mostrar()
        {
            this.dataGridView1.DataSource = _clienteRepository.Mostrar();
        }

        private void MantenimientoCliente_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        public override void Consultar()
        {
            this.txtCod_user_client.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtDui_client.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtName_client.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtApe_client.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.txtLic_client.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.txtTel_client.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.txtDir_client.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            this.txtCorreo_client.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            this.txtCod_client.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            this.txtUser_client.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            this.txtPass_client.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        public override void Cancelar()
        {
            this.Limpiar();
        }
    }
}