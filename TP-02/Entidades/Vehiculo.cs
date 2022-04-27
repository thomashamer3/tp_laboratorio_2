using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enums
        /// <summary>
        /// Enumerado con las Marcas de los Vehiculos.
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        /// <summary>
        /// Enumerado con los Tamanios de los Vehiculos.
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Campos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Propiedad
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get;}

        #endregion

        #region Metodo
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Operador
        /// <summary>
        /// Castea un Objecto de Tipo Vehiculo e Impreme su Informacion.
        /// </summary>
        /// <param name="p">Instancia Tipo Vehiculo.
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            if(!(p is null))
            {

              sb.AppendLine($"{p.GetType().Name.ToUpper()}");
              sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
              sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
              sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
              sb.AppendLine("---------------------");
              sb.AppendFormat("TAMAÑO : {0} ", p.Tamanio);

            }
            

            return sb.ToString();
        }

        

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if( !(v1 is null) && !(v2 is null))
            {
                return String.Compare(v1.chasis, v2.chasis) == 0;
            }

            return false;
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Construtor de Un Vehiculo con sus Datos.
        /// </summary>
        /// <param name="chasis">Chasis del Vehiculo.
        /// <param name="marca">Marca del Vehiculo.
        /// <param name="color">Color del Vehiculo.
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion
    }
}
