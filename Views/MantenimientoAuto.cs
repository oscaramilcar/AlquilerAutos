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
    public partial class MantenimientoAuto : Mantenimiento
    {
        private IAutoRepository _autoRepository { get; }

        public MantenimientoAuto()
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

        private void Limpiar()
        {
            this.txtCod_auto.Text = string.Empty;
            this.txtPlaca_auto.Text = string.Empty;
            this.txtColor_auto.Text = string.Empty;
            this.txtPrecio_auto.Text = string.Empty;
            this.txtAnio_auto.Text = string.Empty;
        }

      

        public override bool Guardar()
        {
            try
            {
                string res = "";
                if (this.txtCod_auto.Text == string.Empty || this.txtAnio_auto.Text == string.Empty || this.txtPlaca_auto.Text == string.Empty || this.txtColor_auto.Text == string.Empty || this.txtPrecio_auto.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorAuto.SetError(this.txtCod_auto, "requerido");
                    errorAuto.SetError(this.txtAnio_auto, "requerido");
                    errorAuto.SetError(this.txtPlaca_auto, "requerido");
                    errorAuto.SetError(this.txtPrecio_auto, "requerido");
                    errorAuto.SetError(this.txtColor_auto, "requerido");
                }
                else
                {
                    res = _autoRepository.Insertar(Convert.ToInt32(this.txtCod_auto.Text.Trim()), this.txtPlaca_auto.Text.Trim(), "act", Convert.ToInt32(this.txtAnio_auto.Text.Trim()), this.txtColor_auto.Text.Trim(), Convert.ToDecimal(this.txtPrecio_auto.Text.Trim()), this.cmbModel_auto.SelectedValue.ToString());

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se inserto correctamente" + res);
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
                if (this.txtCod_auto.Text == string.Empty || this.txtAnio_auto.Text == string.Empty || this.txtPlaca_auto.Text == string.Empty ||  this.txtColor_auto.Text == string.Empty || this.txtPrecio_auto.Text == string.Empty)
                {
                    Message(0, "Falta ingresar datos");
                    errorAuto.SetError(this.txtCod_auto, "requerido");
                    errorAuto.SetError(this.txtAnio_auto, "requerido");
                    errorAuto.SetError(this.txtPlaca_auto, "requerido");
                    errorAuto.SetError(this.txtPrecio_auto, "requerido");
                    errorAuto.SetError(this.txtColor_auto, "requerido");
                }
                else
                {
                    res = _autoRepository.Editar(Convert.ToInt32(this.txtCod_auto.Text.Trim()), this.txtPlaca_auto.Text.Trim(), "act", Convert.ToInt32(this.txtAnio_auto.Text.Trim()), this.txtColor_auto.Text.Trim(), Convert.ToDecimal(this.txtPrecio_auto.Text.Trim()), this.cmbModel_auto.SelectedValue.ToString());

                    if (res.Equals("Exito"))
                    {
                        Message(1, "El registro se actualizó");
                    }
                    else

                        Message(0, "Error al intentar editar el registro");
                    }                    {
                }
                this.Mostrar();
                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void Consultar()
        {
            this.txtCod_auto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtPlaca_auto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtAnio_auto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtColor_auto.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.cmbModel_auto.SelectedValue = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            this.txtPrecio_auto.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            this.cmbModel_auto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

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

                    res = _autoRepository.Eliminar(Convert.ToInt32(this.txtCod_auto.Text.Trim()));

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
            this.dataGridView1.DataSource = _autoRepository.Mostrar();
        }

        private void cmbModel_auto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MantenimientoAuto_Load_1(object sender, EventArgs e)
        {
            this.Mostrar();
            this.cmbModel_auto.DataSource = _autoRepository.MostrarModelos();
            this.cmbModel_auto.DisplayMember = "nombre_modelo";
            this.cmbModel_auto.ValueMember = "cod_modelo";
        }
    }
}
