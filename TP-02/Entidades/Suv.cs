using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor de un Suv con sus Datos.
        /// </summary>
        /// <param name="marca">Marca del Suv.
        /// <param name="chasis">Chasis del Suv.
        /// <param name="color">Color del Sus.
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Obtiene los datos Del Suv y los Muestra.
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.Mostrar());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
