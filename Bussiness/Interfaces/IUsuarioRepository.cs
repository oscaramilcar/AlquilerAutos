using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Interfaces
{
    public interface IUsuarioRepository
    {
        string Insertar(string name, string pass);
        string Editar(string name, string pass);
    }
}
