using Entidades;
using System;
using System.Windows.Forms;

namespace FormGimnasio
{
    public partial class FrmInformes : Form
    {
        #region Atributos
        private Gimnasio gimnasio;
        private Informes informes;
        public delegate void ManejarInformes();
        public event ManejarInformes invocarInformes;
        #endregion

        #region Constructores
        public FrmInformes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Un Constructor que toma como parametro un objeto Gimnasio.
        /// </summary>
        /// <param name="gimnasio"></param>
        public FrmInformes(Gimnasio gimnasio) : this()
        {
            this.gimnasio = gimnasio;
            this.informes = new Informes(this.gimnasio.lista);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Esta Función se Utiliza para Cargar el Formulario y Mostrar la Información en las Etiquetas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="EventArgs"></param>
        private void FrmInformes_Load(object sender, EventArgs e)
        {
            this.invocarInformes += this.MostrarSociosPorGenero;
            this.invocarInformes += this.MostrarSociosPorPase;
            this.invocarInformes += this.MostrarSociosPorTipoPago;
            this.invocarInformes += this.MostrarSociosPorEstatus;
            this.invocarInformes += this.MostrarSociosActivosFormaDePago;
            this.invocarInformes += this.MostrarSociosActivosTiposDePase;
            this.invocarInformes += this.MostrarTotalPorTipoPase;
            this.invocarInformes.Invoke();
        }

        /// <summary>
        /// Esta Metodo se utiliza para Darse de Baja de los Eventos a los que se Suscribio en el
        /// Constructor del Formulario.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="FormClosingEventArgs"></param>
        private void FrmInformes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.invocarInformes -= this.MostrarSociosPorGenero;
            this.invocarInformes -= this.MostrarSociosPorPase;
            this.invocarInformes -= this.MostrarSociosPorTipoPago;
            this.invocarInformes -= this.MostrarSociosPorEstatus;
            this.invocarInformes -= this.MostrarSociosActivosFormaDePago;
            this.invocarInformes -= this.MostrarSociosActivosTiposDePase;
            this.invocarInformes -= this.MostrarTotalPorTipoPase;
        }

        /// <summary>
        /// Devuelve una Cadena con el Numero de Membresías Activas de Cada Tipo de Membresía.
        /// </summary>
        public void MostrarSociosActivosTiposDePase()
        {
            this.lblSociosActivosPase.Text = informes.SociosActivosTipoDePase();
        }

        /// <summary>
        /// Devuelve el Número de Socios Activos que Pagan en Efectivo.
        /// </summary>
        public void MostrarSociosActivosFormaDePago()
        {
            this.lblActivosEfectivo.Text = informes.SociosActivosFormaDePago();
        }

        /// <summary>
        /// Muestra el Número de Miembros que Tienen un Determinado Tipo de Pase.
        /// </summary>
        public void MostrarSociosPorPase()
        {
            this.lblPase.Text = informes.SociosPorPase();
        }

        /// <summary>
        /// Devuelve una Cadena con el Número de Miembros por Estado.
        /// </summary>
        public void MostrarSociosPorEstatus()
        {
            this.lblEstatus.Text = informes.SociosPorEstatus();
        }

        /// <summary>
        /// Este Metodo Muestra el Número de Miembros Masculinos y Femeninos en el Gimnasio.
        /// </summary>
        public void MostrarSociosPorGenero()
        {
            this.lblSociosGenero.Text = informes.SociosPorGenero();
        }

        /// <summary>
        /// Muestra el Número de Miembros que han Pagado sus Cuotas de Membresía.
        /// </summary>
        public void MostrarSociosPorTipoPago()
        {
            this.lblSociosPago.Text = informes.SociosPorTipoPago();
        }

        /// <summary>
        /// Muestra la Cantidad Total de Dinero que el Gimnasio ha ganado con Cada Tipo de Pase.
        /// </summary>
        public void MostrarTotalPorTipoPase()
        {
            this.lblTotalPorPase.Text = informes.TotalPorTipoDePase();
        }
        #endregion
    }
}
