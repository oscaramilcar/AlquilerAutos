using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IClienteRepository
    {
        string Insertar(string codCliente, string nombre, string apellido, DateTime fechaNac, string telefono, string dui, string direccion,string correo,string licencia);
        DataTable Mostrar();
        DataTable BuscarPorNombre(string nombre);
        DataTable BuscarPorDui(string dui);
        DataTable BuscarPorCodigo(string codigo);
        string Editar(string codCliente, string nombre, string apellido, DateTime fechaNac, string telefono, string dui, string direccion, string correo, string licencia);
        string Eliminar(string id);
    }
}
