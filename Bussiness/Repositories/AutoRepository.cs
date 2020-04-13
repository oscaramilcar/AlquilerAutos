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
    public class AutoRepository : IAutoRepository
    {
        public DataTable BuscarPorPlaca(string placa)
        {
            DataTable dataTable = new DataTable("Automovil");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_placa_auto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@placa", SqlDbType.VarChar, 25).Value = placa;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public DataTable BuscarProModelo(string modelo)
        {
            DataTable dataTable = new DataTable("Automovil");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_buscar_modelo_auto";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 25).Value = modelo;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public string Editar(string placa, string modelo, int anio, string color)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_editar_automovil";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@placa", SqlDbType.VarChar, 25).Value = placa;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 25).Value = modelo;
                cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 25).Value = color;

                res = cmd.ExecuteNonQuery() == 1 ? "Exito" : "No se actualizo el registro";
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

        public string Eliminar(string placa)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_eliminar_automovil";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@placa", SqlDbType.VarChar,25).Value = placa;

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

        public string Insertar(string placa, string modelo, int anio, string color)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_insertar_automovil";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@placa", SqlDbType.VarChar, 25).Value = placa;
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar, 25).Value = modelo;
                cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                cmd.Parameters.Add("@color", SqlDbType.VarChar, 25).Value = color;
                
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
            DataTable dataTable = new DataTable("Automovil");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_mostrar_automovil";
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
    }
}
