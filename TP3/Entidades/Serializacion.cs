using System;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializacion<T> : IAdministradorFiles<T>
        where T : class
    {
        private static string rutaArchivo;

        #region Metodos
        /// <summary>
        /// Arma la Ruta Donde se Guardara el Archivo.
        /// </summary>
        static Serializacion()
        {
            string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = "Socios.xml";
            rutaArchivo = Path.Combine(applicationData, nombreArchivo);
        }
        /// <summary>
        /// Exporta en XML Los Datos Pasados por Parametro.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Exportar(T datos)
        {
            bool retorno = false;
            try
            {

                if (rutaArchivo != null)
                {
                    using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(T));
                        nuevoXml.Serialize(streamWriter, datos);
                        retorno = true;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al Querer Guardar El Archivo: " + rutaArchivo);
            }
            return retorno;
        }
        /// <summary>
        /// Importa Los Datos en XML que Encuentra en la Ruta que Entra por Parametro.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Importar(string ruta, out T datos)
        {
            bool retorno = false;
            datos = default;

            try
            {
                if (ruta != null)
                {
                    using (StreamReader auxReader = new StreamReader(ruta))
                    {
                        XmlSerializer nuevoXml = new XmlSerializer(typeof(T));
                        datos = (T)nuevoXml.Deserialize(auxReader);
                        retorno = true;
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return retorno;
        }

        #endregion
    }
}
