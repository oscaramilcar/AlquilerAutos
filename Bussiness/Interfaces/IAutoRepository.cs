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
        string Insertar(int codAuto, string placaAuto, string estadoAuto, int anioAuto, string colorAuto, decimal precioAuto, string modelo);

        string Editar(int codAuto, string placaAuto, string estadoAuto, int anioAuto, string colorAuto, decimal precioAuto, string modelo);

        string Eliminar(int codigo);
        DataTable Mostrar();
        DataTable BuscarPorPlaca(string placa);
        DataTable BuscarProModelo(string modelo);

        DataTable MostrarModelos();
    }
}
