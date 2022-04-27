using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor con sus Datos.
        /// </summary>
        /// <param name="marca">Marca del Ciclomotor.
        /// <param name="chasis">Chasis del Ciclomotor.
        /// <param name="color">Color del Ciclomotor.
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color): base(chasis,marca,color)
        {

        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Obtiene los Datos y los Muestra.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());                     
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
