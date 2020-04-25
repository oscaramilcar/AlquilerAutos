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
    public partial class Reserva : Form
    {
        private static Reserva _instancia;
        double precio;
        public int codEmpleado;
        public IAlquilarRepository _alquilarRepository { get; }
        public Reserva()
        {
            _alquilarRepository = new AlquilarRepository();
            InitializeComponent();
        }

        public void Mostrar()
        {
            this.dtReserva.DataSource = _alquilarRepository.MostrarAutosDisponibles();
            this.dtDevolucion.DataSource = _alquilarRepository.MostrarAutosOcupados();
        }


        private void Reserva_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.txtCodigo.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtApellido.Enabled = false;
            this.txtTiempo.Enabled = false;
        }

        public static Reserva GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new Reserva();
            }
            return _instancia;
        }
        public int getDiasReserva(DateTime date1, DateTime date2)
        {
            if (date2.Day == date1.Day) return 1;

            int dateReserva = (date2.Date - date1.Date).Days;
            return dateReserva;
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
        public void SetCliente(string codigo, string nombre, string apellido)
        {
            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarCliente seleccionarCliente = new SeleccionarCliente();
            seleccionarCliente.MdiParent = this.ParentForm;
            seleccionarCliente.Show();
        }

        private void Reserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnRentar_Click(object sender, EventArgs e)
        {
            int cod_vehiculo = (int)dtReserva.SelectedRows[0].Cells[0].Value;
            string placa = (string)dtReserva.SelectedRows[0].Cells[1].Value;
            int modelo = (int)dtReserva.SelectedRows[0].Cells[7].Value;
            

            DialogResult dialogReserva = MessageBox.Show("¿Estas seguro de rentar el automovil " + modelo + " con placa "+placa + "?", "Autos", MessageBoxButtons.YesNo);


            if (dialogReserva == DialogResult.Yes)
            {
                try
                {
                    string res = "";

                    if (txtCodigo.Text == string.Empty)
                    {
                        Message(0, "falta ingresar algunos datos");
                        errorAlquiler.SetError(txtNombre, "Ingrese el codigo del cliente");
                    }
                    else if (txtNombre.Text == string.Empty)
                    {
                        Message(0, "falta ingresar algunos datos");
                        errorAlquiler.SetError(txtApellido, "Ingrese el nombre del cliente");
                    }
                    else if (txtApellido.Text == string.Empty)
                    {
                        Message(0, "falta ingresar algunos datos");
                        errorAlquiler.SetError(txtApellido, "Ingrese el apellido del cliente");
                    }
                    else if (txtCodigoAlquiler.Text == string.Empty)
                    {
                        Message(0, "falta ingresar algunos datos");
                        errorAlquiler.SetError(txtApellido, "Ingrese el codigo de alquiler");
                    }
                    else
                    {
                       res = _alquilarRepository.AlquilarAuto(Convert.ToInt32(this.txtCodigoAlquiler.Text.Trim()), codEmpleado, Convert.ToInt32(this.txtCodigo.Text.Trim()), cod_vehiculo, dtInicio.Value, dtFin.Value, Convert.ToInt32(txtTiempo.Text.Trim()), Convert.ToDecimal(lblTotal.Text.Trim()));

                        if (res.Equals("Exito"))
                        {
                            if(res.Equals("Exito"))
                            {
                                res = _alquilarRepository.ActualizarEstadoAuto(cod_vehiculo, "alq");
                                MessageBox.Show("¡Vehiculo alquilado con Exito!", "Alquiler", MessageBoxButtons.OK);
                                this.Mostrar();
                                borrar();
                            }
                            else
                            {
                                Message(0, "Error al intentar ingresar el registro");
                            }
                        }
                        else
                        {
                            Message(0, "Error al intentar ingresar el registro");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }

        public void borrar()
        {
            this.txtCodigo.Text = "";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.txtCodigoAlquiler.Text = "";
            this.txtTiempo.Text = "0";
            this.lblTotal.Text = "0";
            this.txtCodigoDevolucion.Text = "";
            this.cbEstadoDevolucion.SelectedIndex = -1;
            this.txtObservaciones.Text = "";
            this.txtCostoAdicional.Text = "";
        }

        private void dtInicio_ValueChanged(object sender, EventArgs e)
        {
            this.txtTiempo.Text = getDiasReserva(dtInicio.Value, dtFin.Value).ToString();
        }

        private void dtFin_ValueChanged(object sender, EventArgs e)
        {
            this.txtTiempo.Text = getDiasReserva(dtInicio.Value, dtFin.Value).ToString();
        }

        private void txtTiempo_TextChanged(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(this.txtTiempo.Text) * precio;
            this.lblTotal.Text = total.ToString();
        }

        private void dtReserva_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            precio = Convert.ToDouble(dtReserva.SelectedRows[0].Cells[8].Value.ToString());
            double t = 0.0;
            if (this.txtTiempo.Text != "")
            {
                t = Convert.ToDouble(this.txtTiempo.Text) * precio;
            }
            this.lblTotal.Text = t.ToString();
        }

        private void btnRetornar_Click(object sender, EventArgs e)
        {
            int cod_vehiculo = (int)dtDevolucion.SelectedRows[0].Cells[0].Value;

            try
            {
                string res = "";

                string alquiler = "";
                string miestado = "";

                if(cbEstadoDevolucion.SelectedIndex == 0)
                {
                    miestado = "Bueno";
                }else if(cbEstadoDevolucion.SelectedIndex == 1)
                {
                    miestado = "Rayado";
                }
                else if (cbEstadoDevolucion.SelectedIndex == 2)
                {
                    miestado = "Golpe";
                }
                else
                {
                    miestado = "Choque";
                }

                alquiler = _alquilarRepository.DetalleAlquiler(cod_vehiculo);

                if (txtCodigoDevolucion.Text == string.Empty)
                {
                    Message(0, "falta ingresar algunos datos");
                    errorAlquiler.SetError(txtCodigoDevolucion, "Ingrese el codigo para la devolucion");
                }
                else if (cbEstadoDevolucion.SelectedIndex == -1)
                {
                    Message(0, "falta ingresar algunos datos");
                    errorAlquiler.SetError(cbEstadoDevolucion, "Seleccione un estado para a devolución");
                }else if (cbEstadoDevolucion.SelectedIndex == 1 || cbEstadoDevolucion.SelectedIndex == 2 || cbEstadoDevolucion.SelectedIndex == 3)
                {
                    Message(0, "Por favor ingresar el costo adicional");
                }
                
                res = _alquilarRepository.DevolverAuto(Convert.ToInt32(txtCodigoDevolucion.Text), miestado, Convert.ToDecimal(txtCostoAdicional.Text.Trim()), txtObservaciones.Text, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")), Convert.ToInt32(alquiler),cod_vehiculo);

                if (res.Equals("Exito"))
                {
                    res = _alquilarRepository.ActualizarEstadoAuto(cod_vehiculo, "act");
                    MessageBox.Show("¡La devolución se realizo con éxito!", "Devolucion", MessageBoxButtons.OK);
                    this.Mostrar();
                    borrar();
                }
                else
                {
                    Message(0, "Error al intentar ingresar el registro");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
