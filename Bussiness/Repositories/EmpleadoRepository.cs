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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public EmpleadoRepository()
        {

        }
        public string Insertar(int cod_emp, string nombres, string apellidos, string correo, string dui, int user_emp, string username, string pass, int rol)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_insertar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_emp", SqlDbType.Int).Value = cod_emp;
                cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = nombres;
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value = apellidos;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 30).Value = correo;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = dui;
                cmd.Parameters.Add("@user_emp", SqlDbType.Int).Value = user_emp;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 15).Value = username;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 15).Value = pass;
                cmd.Parameters.Add("@rol", SqlDbType.Int).Value = rol;

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

        public DataTable Mostrar()
        {
            DataTable dataTable = new DataTable("empleado");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_mostrar_empleados";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            DataTable dataTable = new DataTable("Empleado");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public DataTable Login(string user,string pass)
        {
            DataTable dataTable = new DataTable("usuarios");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_login";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 15).Value = user;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 15).Value = pass;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);

            }
            catch(Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public string Eliminar(int id, int id_user)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_eliminar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;

                res = cmd.ExecuteNonQuery() == 1 ? "Exito" : "No se pudo eliminar el registro";
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

        public string Editar(int cod_emp, string nombres, string apellidos, string correo, string dui, int user_emp, string username, string pass)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_editar_empleado";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_emp", SqlDbType.Int).Value = cod_emp;
                cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = nombres;
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value = apellidos;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 30).Value = correo;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = dui;
                cmd.Parameters.Add("@user_emp", SqlDbType.Int).Value = user_emp;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 15).Value = username;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 15).Value = pass;

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
    }
}
