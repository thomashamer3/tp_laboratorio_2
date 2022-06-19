using System;

namespace Entidades
{
    public class Socio
    {
        #region Enumerados
        public enum EPase
        {
            Gympass,
            Musculacion,
            Libre
        }
        public enum EStatus
        {
            Activo,
            Inactivo
        }
        public enum EPago
        {
            Efectivo,
            Credito,
            Debito
        }
        #endregion

        #region Constructores

        public Socio()
        {
        }

        /// <summary>
        /// Inicializa el Objeto con Los Datos Previstos y Establece al Id como AutoIncremental.
        /// </summary>
        /// <param name="fechaIngreso"></param>
        /// <param name="status"></param>
        public Socio(DateTime fechaIngreso) : this()
        {
            this.FechaIngreso = fechaIngreso;
        }
        /// <summary>
        /// Inicializa el Objeto con los Datos Provistos y Establece
        /// el Status en true y la Fecha en la del Momento de Creacion.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="sexo"></param>
        /// <param name="dni"></param>
        /// <param name="pase"></param>
        public Socio(string nombre, string apellido, string sexo, int dni, EPase pase, EStatus status, EPago pago)
            : this(DateTime.Now)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Dni = dni;
            this.Pase = pase;
            this.Status = status;
            this.Pago = pago;
        }
        #endregion

        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Dni { get; set; }
        public DateTime FechaIngreso { get; set; }
        public EPase Pase { get; set; }
        public EStatus Status { get; set; }
        public EPago Pago { get; set; }

        #endregion

        #region Operadores
        /// <summary>
        /// Valida si Dos Socios Son Iguales en Base al DNI.
        /// </summary>
        /// <param name="socio"></param>
        /// <param name="socio1"></param>
        /// <returns>Devuelve true si lo son, sino false</returns>
        public static bool operator ==(Socio socioA, Socio socioB)
        {
            return socioA is not null && socioB is not null && socioA.Dni == socioB.Dni;
        }
        /// <summary>
        /// </summary>
        /// <param name="socio"></param>
        /// <param name="socio1"></param>
        /// <returns></returns>
        public static bool operator !=(Socio socioA, Socio socioB) => !(socioA == socioB);
        #endregion

        #region Metodos
        /// <summary>
        /// Rescata la Informacion de Un Socio.
        /// </summary>
        /// <returns>Devuelve dicha informacion en formato String</returns>
        public override string ToString()
        {
            return "ID: " + this.Id + "│ Nombre: " + this.Nombre + "│ Apellido: " + this.Apellido
                + "│ Sexo: " + this.Sexo + "│ DNI: " + this.Dni + "│ Fecha de Ingreso: " + this.FechaIngreso.ToShortDateString()
                + "│ Estatus: " + this.Status + "│ Pase: " + this.Pase + "│ Pago: " + this.Pago;
        }

        /// <summary>
        /// Valida si El Objeto es Del Mismo Tipo de la Clase.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve true si lo es, sino false</returns>
        public override bool Equals(object obj)
        {
            Socio socio = obj as Socio;
            return socio != null && this == socio;
        }
        #endregion
    }
}
