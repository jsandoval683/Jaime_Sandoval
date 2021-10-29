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
    public class NotaService : INotaService
    {
        private SqlConnection con;

        private void Conectar()
        {
            string cadenaConexion = "Server=localhost;Database=notasEstudiantes;Trusted_Connection=True;";
            con = new SqlConnection(cadenaConexion);
        }
        public async Task<Notum> AddNotum(Notum notum)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("insert into nota(nota,idAsignatura,idEstudiante,idPeriodo) values (@nota,@idAsignatura,@idEstudiante,@idPeriodo)", con);
                comando.Parameters.Add("@nota", SqlDbType.Float);
                comando.Parameters["@nota"].Value = notum.Nota;
                comando.Parameters.Add("@idAsignatura", SqlDbType.Int);
                comando.Parameters["@idAsignatura"].Value = notum.IdAsignatura;
                comando.Parameters.Add("@idEstudiante", SqlDbType.Int);
                comando.Parameters["@idEstudiante"].Value = notum.IdEstudiante;
                comando.Parameters.Add("@idPeriodo", SqlDbType.Int);
                comando.Parameters["@idPeriodo"].Value = notum.IdPeriodo;
                con.Open();
                var i = await comando.ExecuteNonQueryAsync();
                con.Close();

                return notum;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteNotum(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from nota where id=@id", con);
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

        public async Task<List<Notum>> GetNotums()
        {
            try
            {
                Conectar();
                List<Notum> Notums = new List<Notum>();

                SqlCommand com = new SqlCommand("select id,nota,idAsignatura,idEstudiante,idPeriodo from nota", con);
                con.Open();
                SqlDataReader registros = await com.ExecuteReaderAsync();
                while (registros.Read())
                {
                    Notum nota = new Notum
                    {
                        Id = int.Parse(registros["id"].ToString()),
                        Nota = float.Parse(registros["nota"].ToString()),
                        IdAsignatura = int.Parse(registros["idAsignatura"].ToString()),
                        IdEstudiante = int.Parse(registros["idEstudiante"].ToString()),
                        IdPeriodo = int.Parse(registros["idPeriodo"].ToString())
                    };
                    Notums.Add(nota);
                }
                con.Close();
                return Notums;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Notum> GetNotumById(int id)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("select id,nota,idAsignatura,idEstudiante,idPeriodo from nota where id=@id", con);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                con.Open();
                SqlDataReader registros = await comando.ExecuteReaderAsync();
                Notum nota = new Notum();
                if (registros.Read())
                {
                    nota.Id = int.Parse(registros["id"].ToString());
                    nota.Nota = float.Parse(registros["nota"].ToString());
                    nota.IdAsignatura = int.Parse(registros["idAsignatura"].ToString());
                    nota.IdEstudiante = int.Parse(registros["idEstudiante"].ToString());
                    nota.IdPeriodo = int.Parse(registros["idPeriodo"].ToString());
                }
                con.Close();
                if (nota.Id != 0)
                {
                    return nota;
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

        public async Task<List<Notum>> GetNotumsByIds(int idEstudiante, int idAsignatura, int idPeriodo)
        {
            try
            {
                Conectar();
                List<Notum> Notums = new List<Notum>();

                SqlCommand comando = new SqlCommand("select id,nota,idAsignatura,idEstudiante,idPeriodo from nota where ((idEstudiante=@idEstudiante) AND (idAsignatura=@idAsignatura) AND (idPeriodo=@idPeriodo))", con);
                comando.Parameters.Add("@idEstudiante", SqlDbType.Int);
                comando.Parameters["@idEstudiante"].Value = idEstudiante;
                comando.Parameters.Add("@idAsignatura", SqlDbType.Int);
                comando.Parameters["@idAsignatura"].Value = idAsignatura;
                comando.Parameters.Add("@idPeriodo", SqlDbType.Int);
                comando.Parameters["@idPeriodo"].Value = idPeriodo;
                con.Open();
                SqlDataReader registros = await comando.ExecuteReaderAsync();

                while (registros.Read())
                {
                    Notum nota = new Notum
                    {
                        Id = int.Parse(registros["id"].ToString()),
                        Nota = float.Parse(registros["nota"].ToString()),
                        IdAsignatura = int.Parse(registros["idAsignatura"].ToString()),
                        IdEstudiante = int.Parse(registros["idEstudiante"].ToString()),
                        IdPeriodo = int.Parse(registros["idPeriodo"].ToString())
                    };
                    Notums.Add(nota);
                }

                //Notum nota = new Notum();
                //if (registros.Read())
                //{
                //    nota.Id = int.Parse(registros["id"].ToString());
                //    nota.Nota = float.Parse(registros["nombre"].ToString());
                //    nota.IdAsignatura = int.Parse(registros["idAsignatura"].ToString());
                //    nota.IdEstudiante = int.Parse(registros["idEstudiante"].ToString());
                //    nota.IdPeriodo = int.Parse(registros["idPeriodo"].ToString());
                //}
                con.Close();

                return Notums;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateNotum(Notum notum)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("update nota set nota=@nota where id=@id", con);
                comando.Parameters.Add("@nota", SqlDbType.Float);
                comando.Parameters["@nota"].Value = notum.Nota;
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = notum.Id;
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
