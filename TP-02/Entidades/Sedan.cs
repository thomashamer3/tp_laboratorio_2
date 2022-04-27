using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region Enum
        public enum ETipo { CuatroPuertas, CincoPuertas }
        #endregion

        #region Campo
        private ETipo tipo;
        #endregion

        #region Constructor
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del Sedan.
        /// <param name="chasis">Chasis del Sedan.
        /// <param name="color">Color del Sedan.
        public Sedan(EMarca marca, string chasis, ConsoleColor color): this(marca, chasis,color, ETipo.CuatroPuertas)
        {
           
        }
        /// <summary>
        /// Constructor de Sedan con sus Datos.
        /// </summary>
        /// <param name="marca">Marca del Sedan.
        /// <param name="chasis">Chasis del Sedan.
        /// <param name="color">Color del Sedan.
        /// <param name="tipo">Tipo del Sedan.
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo): base(chasis,marca,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Obtiene los Datos y los Muestra.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine(base.Mostrar());           
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
