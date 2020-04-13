using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IEmpleadoRepository // interfaz que implementa el repositorio para abstraer las clases
    {
        string Insertar(int cod_emp, string nombres, string apellidos, string correo, string dui, int user_emp, string username, string pass, int rol);

        DataTable Login(string user,string pass);
        DataTable Mostrar();
        DataTable BuscarPorNombre(string nombre);
        string Eliminar(int id, int id_user);
        string Editar(int cod_emp, string nombres, string apellidos, string correo, string dui, int user_emp, string username, string pass);
    }
}
