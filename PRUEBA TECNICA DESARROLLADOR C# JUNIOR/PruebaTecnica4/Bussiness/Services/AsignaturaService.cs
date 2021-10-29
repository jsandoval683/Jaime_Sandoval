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
    public class AsignaturaService : IAsignaturaService
    {
        private SqlConnection con;

        private void Conectar()
        {
            string cadenaConexion = "Server=localhost;Database=notasEstudiantes;Trusted_Connection=True;";
            con = new SqlConnection(cadenaConexion);
        }
        public async Task<Asignatura> AddAsignatura(Asignatura asignatura)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("insert into asignatura(nombre) values (@nombre)", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = asignatura.Nombre;
                con.Open();
                var i = await comando.ExecuteNonQueryAsync();
                con.Close();

                return asignatura;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsignatura(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from asignatura where id=@id", con);
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

        public async Task<List<Asignatura>> GetAsignaturas()
        {
            try
            {
                Conectar();
                List<Asignatura> asignaturas = new List<Asignatura>();

                SqlCommand com = new SqlCommand("select id,nombre from asignatura", con);
                con.Open();
                SqlDataReader registros = await com.ExecuteReaderAsync();
                while (registros.Read())
                {
                    Asignatura asi = new Asignatura
                    {
                        Id = int.Parse(registros["id"].ToString()),
                        Nombre = registros["nombre"].ToString()
                    };
                    asignaturas.Add(asi);
                }
                con.Close();
                return asignaturas;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Asignatura> GetAsignaturaById(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("select id,nombre from asignatura where id=@id", con);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                con.Open();
                SqlDataReader registros = await comando.ExecuteReaderAsync();
                Asignatura asignatura = new Asignatura();
                if (registros.Read())
                {
                    asignatura.Id = int.Parse(registros["id"].ToString());
                    asignatura.Nombre = registros["nombre"].ToString();
                }
                con.Close();
                if (asignatura.Id != 0)
                {
                    return asignatura;
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

        public async Task<bool> UpdateAsignatura(Asignatura asignatura)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("update asignatura set nombre=@nombre where id=@id", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = asignatura.Nombre;
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = asignatura.Id;
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
