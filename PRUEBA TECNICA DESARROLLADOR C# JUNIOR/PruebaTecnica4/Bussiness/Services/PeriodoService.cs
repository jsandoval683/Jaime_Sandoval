using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace Bussiness.Services
{
    public class PeriodoService : IPeriodoService
    {
        private SqlConnection con;

        private void Conectar()
        {
            string cadenaConexion = "Server=localhost;Database=notasEstudiantes;Trusted_Connection=True;";
            con = new SqlConnection(cadenaConexion);
        }
        public async Task<Periodo> AddPeriodo(Periodo periodo)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("insert into periodo(nombre, fechaInicio, fechaFinal) values (@nombre, @fechaInicio, @fechaFinal)", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@fechaInicio", SqlDbType.DateTime);
                comando.Parameters.Add("@fechaFinal", SqlDbType.DateTime);
                comando.Parameters["@nombre"].Value = periodo.Nombre;
                comando.Parameters["@fechaInicio"].Value = periodo.FechaInicio;
                comando.Parameters["@fechaFinal"].Value = periodo.FechaFinal;
                con.Open();
                var i = await comando.ExecuteNonQueryAsync();
                con.Close();

                return periodo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeletePeriodo(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from periodo where id=@id", con);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                con.Open();
                int i = await comando.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Periodo>> GetPeriodos()
        {
            try
            {
                Conectar();
                List<Periodo> periodos = new List<Periodo>();

                SqlCommand com = new SqlCommand("select id,nombre,fechaInicio,fechaFinal from periodo", con);
                con.Open();
                SqlDataReader registros = await com.ExecuteReaderAsync();
                while (registros.Read())
                {
                    Periodo periodo = new Periodo
                    {
                        Id = int.Parse(registros["id"].ToString()),
                        Nombre = registros["nombre"].ToString(),
                        FechaInicio = Convert.ToDateTime(registros["fechaInicio"].ToString()),
                        FechaFinal = Convert.ToDateTime(registros["fechaFinal"].ToString())
                    };
                    periodos.Add(periodo);
                }
                con.Close();
                return periodos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Periodo> GetPeriodoById(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("select id,nombre,fechaInicio,fechaFinal from periodo where id=@id", con);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                con.Open();
                SqlDataReader registros = await comando.ExecuteReaderAsync();
                Periodo periodo = new Periodo();
                if (registros.Read())
                {
                    periodo.Id = int.Parse(registros["id"].ToString());
                    periodo.Nombre = registros["nombre"].ToString();
                    periodo.FechaInicio = Convert.ToDateTime(registros["fechaInicio"].ToString());
                    periodo.FechaFinal = Convert.ToDateTime(registros["fechaFinal"].ToString());
                }
                con.Close();
                if (periodo.Id != 0)
                {
                    return periodo;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdatePeriodo(Periodo periodo)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("update periodo set nombre=@nombre,fechaInicio=@fechaInicio,fechaFinal=@fechaFinal where id=@id", con);
                
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = periodo.Nombre;

                comando.Parameters.Add("@fechaInicio", SqlDbType.DateTime);
                comando.Parameters["@fechaInicio"].Value = periodo.FechaInicio;

                comando.Parameters.Add("@fechaFinal", SqlDbType.DateTime);
                comando.Parameters["@fechaFinal"].Value = periodo.FechaFinal;

                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = periodo.Id;

                con.Open();
                int i = await comando.ExecuteNonQueryAsync();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
