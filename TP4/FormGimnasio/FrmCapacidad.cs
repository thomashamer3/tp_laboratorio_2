using System;
using System.Windows.Forms;

namespace FormGimnasio
{
    public partial class FrmCapacidad : Form
    {
        public FrmCapacidad()
        {
            InitializeComponent();
        }

        public int CapacidadGimnasio { get; set; }

        /// <summary>
        /// Se Encarga de Establecer la Capacidad del Gimnasio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CapacidadGimnasio = (int)this.numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}




