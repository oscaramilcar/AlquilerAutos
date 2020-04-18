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
    public class ClienteRepository : IClienteRepository
    {
        public string Insertar(int codUser_client, string Username, string Password, int codClient, string dui, string nombre, string apellido, string telefono, string correo, string direccion, string licencia, int rol)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_insertar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_user_client", SqlDbType.Int).Value = codUser_client;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 15).Value = Username;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 15).Value = Password;
                cmd.Parameters.Add("@id_client", SqlDbType.Int).Value = codClient;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = dui;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 30).Value = apellido;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 12).Value = telefono;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 30).Value = correo;
                cmd.Parameters.Add("@licencia", SqlDbType.VarChar, 40).Value = licencia;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 60).Value = direccion;
                cmd.Parameters.Add("@rol", SqlDbType.Int).Value = rol;

                res = cmd.ExecuteNonQuery() == 2 ? "Exito" : "No se ingreso el registro";
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
            DataTable dataTable = new DataTable("cliente");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_mostrar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }
        public string Editar(int codUser_client, string Username, string Password, int codClient, string dui, string nombre, string apellido, string telefono, string correo, string direccion, string licencia)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_editar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_user_client", SqlDbType.Int).Value = codUser_client;
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 15).Value = Username;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 15).Value = Password;
                cmd.Parameters.Add("@id_client", SqlDbType.Int).Value = codClient;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 10).Value = dui;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 30).Value = apellido;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 12).Value = telefono;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 30).Value = correo;
                cmd.Parameters.Add("@licencia", SqlDbType.VarChar, 40).Value = licencia;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 60).Value = direccion;

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
                cmd.CommandText = "sp_eliminar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id_client", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@id_user_client", SqlDbType.Int).Value = id_user;

                res = cmd.ExecuteNonQuery() == 2 ? "Exito" : "No se pudo eliminar el registro";
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

        public DataTable BuscarPorNombre(string nombre)
        {
            DataTable dataTable = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_nombre_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public DataTable BuscarPorDui(string dui)
        {
            DataTable dataTable = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_dui_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 25).Value = dui;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public DataTable BuscarPorCodigo(string codigo)
        {
            DataTable dataTable = new DataTable("Cliente");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_codigo_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codCliente", SqlDbType.VarChar, 10).Value = codigo;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }
    }
}
