using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Gimnasio
    {
        #region Atributos
        public List<Socio> lista;
        #endregion

        #region Constructores

        /// <summary>
        /// Establece la Capacidad por Defecto en 15.
        /// </summary>
        public Gimnasio()
        {
            this.lista = new List<Socio>();
            this.Capacidad = 15;
        }

        /// <summary>
        /// Establece la Capacidad Establecida por el Usuario Siempre y Cuando 
        /// Respete El Limite.
        /// </summary>
        /// <param name="capacidad"></param>
        public Gimnasio(int capacidad) : this()
        {
            if (capacidad >= 15 && capacidad <= 120)
            {
                this.Capacidad = capacidad;
            }
        }
        #endregion

        #region Propiedades
        public int LugaresLibres => this.ObtenerCantidadLugaresLibres();
        public int Capacidad { get; set; }
        #endregion

        #region Operadores

        /// <summary>
        /// Valida Si el Socio ya se Encuentra en La Lista.
        /// </summary>
        /// <param name="gimnasio"></param>
        /// <param name="socio"></param>
        /// <returns>Devuelve true si se encuentra, sino false</returns>
        public static bool operator ==(Gimnasio gimnasio, Socio socio)
        {
            bool retorno = false;
            foreach (Socio item in gimnasio.lista)
            {
                if (socio.Equals(item))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el Socio no Este en La Lista.
        /// </summary>
        /// <param name="gimnasio"></param>
        /// <param name="socio"></param>
        /// <returns></returns>
        public static bool operator !=(Gimnasio gimnasio, Socio socio) => !(gimnasio == socio);

        /// <summary>
        /// Agrega un Elemento Solo si hay Lugar y si El Elemento no se Encuentra en la Lista.
        /// </summary>
        /// <param name="gimnasio"></param>
        /// <param name="socio"></param>
        /// <returns>Devuelve true si pudo agregarlo y false caso contrario</returns>
        public static bool operator +(Gimnasio gimnasio, Socio socio)
        {
            bool retorno = false;
            int index;
            if (gimnasio.lista.Count < gimnasio.Capacidad)
            {
                if (!gimnasio.lista.Contains(socio))
                {
                    gimnasio.lista.Add(socio);
                }
                else
                {
                    index = gimnasio.lista.FindIndex(m => m.Id == socio.Id);
                    if (index >= 0)
                        gimnasio.lista[index] = socio;
                }
                retorno = true;
            }
            else
            {
                throw new CapacidadMaximaException("No Hay Mas Lugares Disponibles!!!");
            }
            return retorno;
        }

        /// <summary>
        /// Quita un Elemento de la Lista.
        /// </summary>
        /// <param name="gimnasio"></param>
        /// <param name="socio"></param>
        /// <returns>Devuelve true si pudo hacerlo, sino false</returns>
        public static bool operator -(Gimnasio gimnasio, Socio socio)
        {
            bool retorno = false;
            if (gimnasio.lista.Contains(socio))
            {
                gimnasio.lista.Remove(socio);
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega un Socio. 
        /// </summary>
        /// <param name="socio"></param>
        /// <returns>Devuelve true si pudo hacerlo, sino false</returns>
        public bool Agregar(Socio socio)
        {
            return this + socio;
        }

        /// <summary>
        /// Quita un Socio.
        /// </summary>
        /// <param name="socio"></param>
        /// <returns>Devuelve true si pudo hacerlo, sino false</returns>
        public bool Remover(Socio socio)
        {
            return this - socio;
        }

        /// <summary>
        /// Obtiene la Cantidad de Lugares Libres.
        /// </summary>
        /// <returns>Devuelve la cantidad de lugares libres</returns>
        private int ObtenerCantidadLugaresLibres() => this.Capacidad - this.lista.Count;

        /// <summary>
        /// Calcula el Total Facturado en Base al Valor de Cada Pase.
        /// </summary>
        /// <returns>Devuelve el total facturado</returns>
        public int TotalFacturado()
        {
            int total = 0;
            foreach (Socio socio in this.lista)
            {
                if (socio.Pase.Equals(Socio.EPase.Gympass))
                {
                    total += 2000;
                }
                else if (socio.Pase.Equals(Socio.EPase.Libre))
                {
                    total += 3200;
                }
                else
                {
                    total += 1500;
                }
            }
            return total;
        }

        /// <summary>
        /// Rescata la Informacion del Gimnasio.
        /// </summary>
        /// <returns>Devuelve dicha informacion como un string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Cantidad Maxima de Socios: " + this.Capacidad);
            sb.AppendLine();
            sb.Append("Cantidad de Socios: ");
            sb.AppendLine(this.lista.Count.ToString());
            sb.Append("Recaudacion: ");
            sb.AppendLine(this.TotalFacturado().ToString());
            sb.AppendLine();
            foreach (Socio socio in this.lista)
            {
                if (socio != null)
                {
                    sb.AppendLine(socio.ToString());
                }
            }
            return sb.ToString();
        }
    }
    #endregion
}



