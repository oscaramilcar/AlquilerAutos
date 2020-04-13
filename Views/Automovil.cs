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
    public partial class Automovil : Form
    {
        public IAutoRepository _autoRepository { get; }
        public Automovil()
        {
            _autoRepository = new AutoRepository();
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
            this.dtAuto.DataSource = _autoRepository.Mostrar();
        }

        private void Limpiar()
        {
            this.txtPlaca.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtAnio.Text = string.Empty;
            this.txtColor.Text = string.Empty;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            this.btnEliminar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Mostrar();
        }

        private void Automovil_Load(object sender, EventArgs e)
        {
            this.btnEliminar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                if (this.txtPlaca.Text == string.Empty || this.txtModelo.Text == string.Empty || this.txtAnio.Text == string.Empty || this.txtColor.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtPlaca, "requerido");
                    errorControles.SetError(this.txtModelo, "requerido");
                    errorControles.SetError(this.txtAnio, "requerido");
                    errorControles.SetError(this.txtColor, "requerido");
                }
                else
                {
                    res = _autoRepository.Insertar(this.txtPlaca.Text.Trim(), this.txtModelo.Text.Trim(), Convert.ToInt32(this.txtAnio.Text.Trim()), this.txtColor.Text.Trim());

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
                if (this.txtPlaca.Text == string.Empty || this.txtModelo.Text == string.Empty || this.txtAnio.Text == string.Empty || this.txtColor.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorControles.SetError(this.txtPlaca, "requerido");
                    errorControles.SetError(this.txtModelo, "requerido");
                    errorControles.SetError(this.txtAnio, "requerido");
                    errorControles.SetError(this.txtColor, "requerido");
                }
                else
                {
                    res = _autoRepository.Editar(this.txtPlaca.Text.Trim(), this.txtModelo.Text.Trim(), Convert.ToInt32(this.txtAnio.Text.Trim()), this.txtColor.Text.Trim());

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se actualizo el registro");
                    }
                    else
                    {
                        Message(0, "Error al intentar editar registro");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult;
                dialogResult = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    string placa;
                    string res = "";

                    placa = dtAuto.CurrentRow.Cells[0].Value.ToString();
                    res = _autoRepository.Eliminar(placa);

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
            this.txtPlaca.Enabled = true;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnEditar.Enabled = false;
            this.Limpiar();
        }

        private void dtAuto_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dtAuto_DoubleClick_1(object sender, EventArgs e)
        {
            this.txtPlaca.Text = dtAuto.CurrentRow.Cells[0].Value.ToString();
            this.txtModelo.Text = dtAuto.CurrentRow.Cells[1].Value.ToString();
            this.txtAnio.Text = dtAuto.CurrentRow.Cells[2].Value.ToString();
            this.txtColor.Text = dtAuto.CurrentRow.Cells[3].Value.ToString();
            this.btnCancelar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnGuardar.Enabled = false;
            this.txtPlaca.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Placa"))
            {
                dtAuto.DataSource = _autoRepository.BuscarPorPlaca(this.txtrBuscar.Text.Trim());
            }
            else if (cbBuscar.Text.Equals("Modelo"))
            {
                dtAuto.DataSource = _autoRepository.BuscarProModelo(this.txtrBuscar.Text.Trim());
            }
        }
    }
}
