using System;

namespace Entidades
{
    public static class Extension
    {
        /// <summary>
        /// /Obtiene la Diferencia de Tiempo Entre Dos Fechas.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTimeInicio"></param>
        /// <param name="dateTimeFin"></param>
        /// <returns>Retorna la diferencia de tiempo</returns>
        public static TimeSpan ObtenerTiempo(this DateTime dateTime, DateTime dateTimeInicio, DateTime dateTimeFin)
        {
            return dateTimeFin.Subtract(dateTimeInicio);
        }
    }
}
