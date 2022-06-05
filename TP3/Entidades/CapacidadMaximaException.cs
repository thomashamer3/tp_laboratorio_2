﻿using System;

namespace Entidades
{
    public class CapacidadMaximaException : Exception
    {
        #region Constructores
        /// <summary>
        /// Crea un Mensaje con la Excepcion.
        /// </summary>
        /// <param name="mensaje"></param>
        public CapacidadMaximaException(String mensaje) : this(mensaje, null)
        {

        }

        /// <summary>
        /// Crea un Mensaje con la Excepcion y la Inner Exception.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public CapacidadMaximaException(String mensaje, Exception inner) : base(mensaje, inner)
        {

        }
        #endregion

    }
}
