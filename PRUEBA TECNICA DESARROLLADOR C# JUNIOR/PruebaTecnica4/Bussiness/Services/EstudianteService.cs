using DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services
{
    public class EstudianteService : IEstudianteService
    {
        private SqlConnection con;

        private void Conectar()
        {
            string cadenaConexion = "Server=localhost;Database=notasEstudiantes;Trusted_Connection=True;";
            con = new SqlConnection(cadenaConexion);
        }
        public async Task<Estudiante> AddEstudiante(Estudiante estudiante)
        {

            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("insert into estudiante(nombre,codigo) values (@nombre,@codigo)", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@codigo", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = estudiante.Nombre;
                comando.Parameters["@codigo"].Value = estudiante.Codigo;
                con.Open();
                var i = await comando.ExecuteNonQueryAsync();
                con.Close();
                
                return estudiante;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteEstudiante(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from estudiante where id=@id", con);
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

        public async Task<Estudiante> GetEstudianteById(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("select id,nombre,codigo from estudiante where id=@id", con);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                con.Open();
                SqlDataReader registros = await comando.ExecuteReaderAsync();
                Estudiante estudiante = new Estudiante();
                if (registros.Read())
                {
                    estudiante.Id = int.Parse(registros["id"].ToString());
                    estudiante.Nombre = registros["nombre"].ToString();
                    estudiante.Codigo = registros["codigo"].ToString();
                }
                con.Close();
                if(estudiante.Id != 0)
                {
                    return estudiante;
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

        public async Task<List<Estudiante>> GetEstudiantes()
        {
            try
            {
                Conectar();
                List<Estudiante> estudiantes = new List<Estudiante>();

                SqlCommand com = new SqlCommand("select id,nombre,codigo from estudiante", con);
                con.Open();
                SqlDataReader registros = await com.ExecuteReaderAsync();
                while (registros.Read())
                {
                    Estudiante est = new Estudiante
                    {
                        Id = int.Parse(registros["id"].ToString()),
                        Nombre = registros["nombre"].ToString(),
                        Codigo = registros["codigo"].ToString()
                    };
                    estudiantes.Add(est);
                }
                con.Close();
                return estudiantes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateEstudiante(Estudiante estudiante)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("update estudiante set nombre=@nombre,codigo=@codigo where id=@id", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = estudiante.Nombre;
                comando.Parameters.Add("@codigo", SqlDbType.VarChar);
                comando.Parameters["@codigo"].Value = estudiante.Codigo;
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = estudiante.Id;
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
