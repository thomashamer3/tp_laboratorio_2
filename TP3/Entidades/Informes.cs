using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Informes
    {
        List<Socio> socios;

        #region Constructores
        /// <summary>
        /// Crea una Lista de Informes para Socios.
        /// </summary>
        /// <param name="socios"></param>
        public Informes(List<Socio> socios)
        {
            this.socios = socios;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Cuenta el Número de Socios Masculinos y Femeninos en el Gimnasio.
        /// </summary>
        /// <returns>
        /// El método está devolviendo una cadena.
        /// </returns>
        public String SociosPorGenero()
        {
            int masculino = 0;
            int femenino = 0;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Socio item in this.socios)
            {
                if (item.Sexo == "MASCULINO")
                {
                    masculino++;
                }
                else
                {
                    femenino++;
                }
            }

            stringBuilder.AppendLine("Cantidad Total de Socios: " + (masculino + femenino));
            stringBuilder.AppendLine("Cantidad de Socios Masculinos: " + masculino);
            stringBuilder.AppendLine("Cantidad de Socios Femeninos: " + femenino);

            return stringBuilder.ToString();

        }

        /// <summary>
        /// Cuenta el NUmero de Miembros con Cada Tipo de Membresia y Devuelve una Cadena con los Resultados.
        /// </summary>
        public string SociosPorPase()
        {
            int gympass = 0;
            int musculacion = 0;
            int libre = 0;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Socio item in this.socios)
            {
                switch (item.Pase)
                {
                    case Socio.EPase.Gympass:
                        gympass++;
                        break;
                    case Socio.EPase.Musculacion:
                        musculacion++;
                        break;
                    case Socio.EPase.Libre:
                        libre++;
                        break;

                }
            }

            stringBuilder.AppendLine("Cantidad de Socios con Pase Gympass: " + gympass.ToString());
            stringBuilder.AppendLine("Cantidad de Socios con Pase Musculacion: " + musculacion.ToString());
            stringBuilder.AppendLine("Cantidad de Socios con Pase Libre: " + libre.ToString());

            return stringBuilder.ToString();

        }

        /// <summary>
        /// Esta Funcion Cuenta el Numero de Miembros Activos e Inactivos en el Gimnasio.
        /// </summary>
        public string SociosPorEstatus()
        {
            int activo = 0;
            int inactivo = 0;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Socio item in this.socios)
            {
                if (item.Status == Socio.EStatus.Activo)
                {
                    activo++;
                }
                else
                {
                    inactivo++;
                }
            }
            stringBuilder.AppendLine("Cantidad de Socios Activos: " + activo);
            stringBuilder.AppendLine("Cantidad de socios Inactivos: " + inactivo);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Cuenta el Numero de Afiliados que Pagan con Debito, Credito o Efectivo.
        /// </summary>
        public string SociosPorTipoPago()
        {
            int debito = 0;
            int credito = 0;
            int efectivo = 0;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Socio item in this.socios)
            {
                switch (item.Pago)
                {
                    case Socio.EPago.Efectivo:
                        efectivo++;
                        break;
                    case Socio.EPago.Credito:
                        credito++;
                        break;
                    case Socio.EPago.Debito:
                        debito++;
                        break;
                }
            }
            stringBuilder.AppendLine("Cantidad de Socios que Abonan con Debito: " + debito.ToString());
            stringBuilder.AppendLine("Cantidad de Socios que Abonan con Credito: " + credito.ToString());
            stringBuilder.AppendLine("Cantidad de Socios que Abonan con Efectivo: " + efectivo.ToString());

            return stringBuilder.ToString();

        }


        /// <summary>
        /// Devuelve una Cadena Con el Numero de Miembros Activos que Pagan en Efectivo, Credito o Debito.
        /// </summary>
        public string SociosActivosFormaDePago()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalSociosEfectivo = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                            && element.Pago == Socio.EPago.Efectivo);

            int totalSociosCredito = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                          && element.Pago == Socio.EPago.Credito);

            int totalSociosDebito = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                          && element.Pago == Socio.EPago.Debito);

            stringBuilder.AppendLine("Socios Activos que Abonan con Efectivo : " + totalSociosEfectivo);
            stringBuilder.AppendLine("Socios Activos que Abonan con Credito : " + totalSociosCredito);
            stringBuilder.AppendLine("Socios Activos que Abonan con Debito : " + totalSociosDebito);

            return stringBuilder.ToString();

        }


        /// <summary>
        /// Devuelve una Cadena con el Numero de Miembros Activos Con Pase libre, Muscular y Gympass.
        /// </summary>
        public string SociosActivosTipoDePase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int totalSociosLibre = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                            && element.Pase == Socio.EPase.Libre);

            int totalSociosMusculacion = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                          && element.Pase == Socio.EPase.Musculacion);

            int totalSociosGympass = this.socios.Count(element => element.Status == Socio.EStatus.Activo
                                          && element.Pase == Socio.EPase.Gympass);

            stringBuilder.AppendLine("Socios Activos con Pase 'Libre' : " + totalSociosLibre);
            stringBuilder.AppendLine("Socios Activos con Pase 'Musculacion'  : " + totalSociosMusculacion);
            stringBuilder.AppendLine("Socios Activos con Pase 'Gympass'  : " + totalSociosGympass);

            return stringBuilder.ToString();
        }
        #endregion
    }
}
