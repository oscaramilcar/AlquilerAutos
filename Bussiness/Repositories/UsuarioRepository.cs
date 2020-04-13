using Bussiness.Interfaces;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        public UsuarioRepository()
        {
        }

        public string Editar(string name, string pass)
        {
            throw new NotImplementedException();
        }

        public string Insertar(string username,string pass)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_insertar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = username;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = pass;

                res = cmd.ExecuteNonQuery() == 1 ? "Exito" : "No se ingreso el registro";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return res;
        }
        /*
public string Editar(Usuario usuario)
{

}

public string Eliminar(Usuario usuario)
{

}
public DataTable Mostrar()
{

}
public DataTable Buscar(string nombre)
{

}*/
    }
}
