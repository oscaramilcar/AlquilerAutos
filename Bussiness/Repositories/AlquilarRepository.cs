﻿using Bussiness.Interfaces;
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
    public class AlquilarRepository : IAlquilarRepository
    {
        public string ActualizarEstadoAuto(int cod_vehiculo, string estado)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_estado_auto_alquiler";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_vehiculo", SqlDbType.Int).Value = cod_vehiculo;
                cmd.Parameters.Add("@estado", SqlDbType.VarChar,5).Value = estado;

                res = cmd.ExecuteNonQuery() == 1 ? "Exito" : "No se cambio el estado";
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

        public string AlquilarAuto(int cod_alquiler, int cod_emple, int cod_cliente, int cod_vehiculo, DateTime fecha_entrada, DateTime fecha_salida, int dias, decimal total)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_crear_reserva";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_alquiler", SqlDbType.Int).Value = cod_alquiler;
                cmd.Parameters.Add("@cod_emple", SqlDbType.Int).Value = cod_emple;
                cmd.Parameters.Add("@cod_cliente", SqlDbType.Int).Value = cod_cliente;
                cmd.Parameters.Add("@cod_vehiculo", SqlDbType.Int).Value = cod_vehiculo;
                cmd.Parameters.Add("@fecha_entrada", SqlDbType.Date).Value = fecha_entrada;
                cmd.Parameters.Add("@fecha_salida", SqlDbType.Date).Value = fecha_salida;
                cmd.Parameters.Add("@dias", SqlDbType.Int).Value = dias;
                cmd.Parameters.Add("@total", SqlDbType.Decimal).Value = total;

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

        public DataTable MostrarAutosDisponibles()
        {
            DataTable dataTable = new DataTable("vehiculo");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_mostrar_autos_activos";
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

        public DataTable MostrarAutosOcupados()
        {
            DataTable dataTable = new DataTable("vehiculo");
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_mostrar_autos_ocupados";
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

        public string DevolverAuto(int codDevolucion, string estadoAuto, decimal costoAdicional, string observacion, DateTime fecha_dev, int cod_alquiler, int cod_vehiculo)
        {
            string res = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandText = "sp_crear_devolucion";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cod_devolucion", SqlDbType.Int).Value = codDevolucion;
                cmd.Parameters.Add("@estado_auto", SqlDbType.VarChar, 20).Value = estadoAuto;
                cmd.Parameters.Add("@costo_adicional", SqlDbType.Decimal).Value = costoAdicional;
                cmd.Parameters.Add("@observacion", SqlDbType.VarChar, 60).Value = observacion;
                cmd.Parameters.Add("@fecha_dev", SqlDbType.Date).Value = fecha_dev;
                cmd.Parameters.Add("@cod_alquiler", SqlDbType.Int).Value = cod_alquiler;
                cmd.Parameters.Add("@cod_vehiculo", SqlDbType.Int).Value = cod_vehiculo;


                res = cmd.ExecuteNonQuery() == -1 ? "Exito" : "No se ingreso el registro";
                
            }
            catch (SqlException ex)
            {
                res = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return res;
        }

        public string DetalleAlquiler(int cod_vehiculo)
        {
            string res = "";

            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = Conexion.con;
                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("SELECT alquiler.* FROM vehiculo INNER JOIN Alquiler ON Alquiler.cod_vehiculo = @ID WHERE vehiculo.cod_vehiculo = @ID AND estado = 'alq'", sqlCon);
                cmd.Connection = sqlCon;
                cmd.Parameters.AddWithValue("@ID", cod_vehiculo);
                SqlDataReader registro = cmd.ExecuteReader();

                if(registro.Read())
                {
                    res = registro["cod_alquiler"].ToString();
                    
                }
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
