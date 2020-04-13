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
        public string Insertar(string codCliente, string nombre, string apellido, DateTime fechaNac, string telefono, string dui, string direccion, string correo, string licencia)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "ps_insertar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codCliente", SqlDbType.VarChar,10).Value = codCliente;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                cmd.Parameters.Add("@fechaNac", SqlDbType.VarChar, 50).Value = fechaNac;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = telefono;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 25).Value = dui;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 250).Value = direccion;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 25).Value = correo;
                cmd.Parameters.Add("@licencia", SqlDbType.VarChar, 50).Value = licencia;

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
            DataTable dataTable = new DataTable("Cliente");
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
        public string Editar(string codCliente, string nombre, string apellido, DateTime fechaNac, string telefono, string dui, string direccion, string correo, string licencia)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "ps_editar_cliente";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@codCliente", SqlDbType.VarChar, 10).Value = codCliente;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 30).Value = nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 30).Value = apellido;
                cmd.Parameters.Add("@fechaNac", SqlDbType.VarChar, 50).Value = fechaNac;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 10).Value = telefono;
                cmd.Parameters.Add("@dui", SqlDbType.VarChar, 25).Value = dui;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 250).Value = direccion;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 25).Value = correo;
                cmd.Parameters.Add("@licencia", SqlDbType.VarChar, 50).Value = licencia;

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

        public string Eliminar(string id)
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

                cmd.Parameters.Add("@codCliente", SqlDbType.VarChar, 10).Value = id;

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
