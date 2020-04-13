using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IAutoRepository
    {
        string Insertar(string placa, string modelo, int anio, string color);

        string Editar(string placa, string modelo, int anio, string color);

        string Eliminar(string placa);
        DataTable Mostrar();
        DataTable BuscarPorPlaca(string placa);
        DataTable BuscarProModelo(string modelo);
    }
}
