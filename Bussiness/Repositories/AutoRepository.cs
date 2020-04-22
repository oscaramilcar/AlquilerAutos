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

        public DataTable MostrarModelos()
        {
            DataTable dataTable = new DataTable("modelos");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_cbmodels";
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

        public string Editar(int codAuto, string placaAuto, string estadoAuto, int anioAuto, string colorAuto, decimal precioAuto, string modelo)
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

                cmd.Parameters.Add("@codAuto", SqlDbType.Int).Value = codAuto;
                cmd.Parameters.Add("@placaAuto", SqlDbType.VarChar, 10).Value = placaAuto;
                cmd.Parameters.Add("@estadoAuto", SqlDbType.VarChar, 5).Value = estadoAuto;
                cmd.Parameters.Add("@anioAuto", SqlDbType.Int).Value = anioAuto;
                cmd.Parameters.Add("@colorAuto", SqlDbType.VarChar, 15).Value = colorAuto;
                cmd.Parameters.Add("@precioAuto", SqlDbType.Decimal).Value = precioAuto;
                cmd.Parameters.Add("@modelo", SqlDbType.Int).Value = Convert.ToInt32(modelo);

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

        public string Eliminar(int codigo)
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

                cmd.Parameters.Add("@codAuto", SqlDbType.Int).Value = codigo;

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

        public string Insertar(int codAuto, string placaAuto, string estadoAuto, int anioAuto, string colorAuto, decimal precioAuto, string modelo)
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

                cmd.Parameters.Add("@codAuto", SqlDbType.Int).Value = codAuto;
                cmd.Parameters.Add("@placaAuto", SqlDbType.VarChar, 10).Value = placaAuto;
                cmd.Parameters.Add("@estadoAuto", SqlDbType.VarChar, 5).Value = estadoAuto;
                cmd.Parameters.Add("@anioAuto", SqlDbType.Int).Value = anioAuto;
                cmd.Parameters.Add("@colorAuto", SqlDbType.VarChar, 15).Value = colorAuto;
                cmd.Parameters.Add("@precioAuto", SqlDbType.Decimal).Value = precioAuto;
                cmd.Parameters.Add("@modelo", SqlDbType.Int).Value = Convert.ToInt32(modelo);

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
            DataTable dataTable = new DataTable("vehiculo");
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
