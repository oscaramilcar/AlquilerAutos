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
        string Insertar(int codUser_client, string Username, string Password, int codClient, string dui,  string nombre, string apellido,  string telefono, string correo, string direccion,string licencia, int rol);
        DataTable Mostrar();
        DataTable BuscarPorNombre(string nombre);
        DataTable BuscarPorDui(string dui);
        DataTable BuscarPorCodigo(string codigo);
        string Editar(int codUser_client, string Username, string Password, int codClient, string dui, string nombre, string apellido, string telefono, string correo, string direccion, string licencia);
        string Eliminar(int id, int id_user);
    }
}
