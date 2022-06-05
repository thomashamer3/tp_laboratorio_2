using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGimnasio
{
    public partial class FrmInformes : Form
    {
        #region Atributos
        private Gimnasio gimnasio;
        private Informes informes;
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


        /// <summary>
        /// Esta Función se Utiliza para Cargar el Formulario y Mostrar la Información en las Etiquetas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="EventArgs"></param>
        private void FrmInformes_Load(object sender, EventArgs e)
        {
            this.lblSociosGenero.Text = informes.SociosPorGenero();
            this.lblSociosPago.Text = informes.SociosPorTipoPago();
            this.lblEstatus.Text = informes.SociosPorEstatus();
            this.lblPase.Text = informes.SociosPorPase();
            this.lblActivosEfectivo.Text = informes.SociosActivosFormaDePago();
            this.lblSociosActivosPase.Text = informes.SociosActivosTipoDePase();

        }
    }
}
