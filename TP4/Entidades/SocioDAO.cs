using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public class SocioDAO : ICrud
    {
        #region Atributos
        private static SqlConnection connection;
        private static SqlCommand command;
        private static string connectionString;
        #endregion

        #region Constructor
        static SocioDAO()
        {
            command = new SqlCommand();
            connectionString = "Server = .; Database=GimnasioMetroFlex ; Trusted_Connection=true";
            connection = new SqlConnection(connectionString);
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Busca un Socio por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve al Socio Correspondiente</returns>
        public Socio BuscarPorID(int id)
        {
            Socio socio = new Socio();
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM sociosGym WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    socio.Id = Convert.ToInt32(sqlDataReader["id"]);
                    socio.Nombre = sqlDataReader["nombre"].ToString();
                    socio.Apellido = sqlDataReader["apellido"].ToString();
                    socio.Sexo = sqlDataReader["sexo"].ToString();
                    socio.Pase = (Socio.EPase)Enum.Parse(typeof(Socio.EPase), sqlDataReader["pase"].ToString());
                    socio.Pago = (Socio.EPago)Enum.Parse(typeof(Socio.EPago), sqlDataReader["pago"].ToString());
                    socio.Status = (Socio.EStatus)Enum.Parse(typeof(Socio.EStatus), sqlDataReader["estatus"].ToString());
                    socio.FechaIngreso = Convert.ToDateTime(sqlDataReader["fecha_ingreso"]);
                    socio.Dni = Convert.ToInt32(sqlDataReader["dni"]);
                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return socio;
        }
        /// <summary>
        /// Edita al Socio Pasado por Parametro.
        /// </summary>
        /// <param name="socio"></param>
        /// <returns>Retorna true si pudo y false sino</returns>
        public bool EditarSocio(Socio socio)
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = $"UPDATE sociosGym SET nombre = @nombre, apellido = @apellido, sexo = @sexo, pago = @pago, pase = @pase, estatus = @estatus, fecha_ingreso = @fecha_ingreso, dni = @dni WHERE id = @id";

                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@sexo", socio.Sexo);
                command.Parameters.AddWithValue("@pase", socio.Pase);
                command.Parameters.AddWithValue("@pago", socio.Pago);
                command.Parameters.AddWithValue("@estatus", socio.Status);
                command.Parameters.AddWithValue("@fecha_ingreso", socio.FechaIngreso);
                command.Parameters.AddWithValue("@dni", socio.Dni);
                command.Parameters.AddWithValue("@id", socio.Id);
                connection.Open();
                command.ExecuteNonQuery();

                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Elimina un Socio por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EliminarSocio(int id)
        {
            bool retorno = false;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM sociosGym WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Guarda el Socio en la bbdd Pasado por parametro.
        /// </summary>
        /// <param name="socio"></param>
        /// <returns></returns>
        public bool GuardarSocio(Socio socio)
        {
            bool retorno = false;
            try
            {
                command = new SqlCommand();
                connection = new SqlConnection(connectionString);
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "INSERT INTO sociosGym (nombre,apellido,sexo,pase,pago,estatus,fecha_ingreso,dni) " +
                    " VALUES (@nombre,@apellido,@sexo,@pase,@pago,@estatus,@fecha_ingreso,@dni)";

                command.Parameters.AddWithValue("@nombre", socio.Nombre);
                command.Parameters.AddWithValue("@apellido", socio.Apellido);
                command.Parameters.AddWithValue("@sexo", socio.Sexo);
                command.Parameters.AddWithValue("@pase", socio.Pase);
                command.Parameters.AddWithValue("@pago", socio.Pago);
                command.Parameters.AddWithValue("@estatus", socio.Status);
                command.Parameters.AddWithValue("@fecha_ingreso", socio.FechaIngreso);
                command.Parameters.AddWithValue("@dni", socio.Dni);
                connection.Open();
                command.ExecuteNonQuery();

                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Rescata Todos los Socios de la bbdd.
        /// </summary>
        /// <returns>Devuele un listado de socios de la bbdd</returns>
        public List<Socio> ListarSocios()
        {
            List<Socio> socios = new List<Socio>();

            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"SELECT * FROM sociosGym";
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Socio socio = new Socio();
                    socio.Id = Convert.ToInt32(sqlDataReader["id"]);
                    socio.Nombre = sqlDataReader["nombre"].ToString();
                    socio.Apellido = sqlDataReader["apellido"].ToString();
                    socio.Sexo = sqlDataReader["sexo"].ToString();
                    socio.Pase = (Socio.EPase)Enum.Parse(typeof(Socio.EPase), sqlDataReader["pase"].ToString());
                    socio.Pago = (Socio.EPago)Enum.Parse(typeof(Socio.EPago), sqlDataReader["pago"].ToString());
                    socio.Status = (Socio.EStatus)Enum.Parse(typeof(Socio.EStatus), sqlDataReader["estatus"].ToString());
                    socio.FechaIngreso = Convert.ToDateTime(sqlDataReader["fecha_ingreso"]);
                    socio.Dni = Convert.ToInt32(sqlDataReader["dni"]);

                    socios.Add(socio);
                }
                sqlDataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return socios;
        }
        #endregion
    }
}

