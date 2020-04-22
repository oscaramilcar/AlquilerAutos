using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IAlquilarRepository
    {
        string AlquilarAuto(int cod_alquiler, int cod_emple, int cod_cliente, int cod_vehiculo,DateTime fecha_entrada, DateTime fecha_salida, int dias, decimal total);

        DataTable MostrarAutosDisponibles();

        string ActualizarEstadoAuto(int cod_vehiculo, string estado);
    }
}
