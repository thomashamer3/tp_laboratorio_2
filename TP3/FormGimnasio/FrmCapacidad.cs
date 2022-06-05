using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

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

        private void FrmCapacidad_Load(object sender, EventArgs e)
        {

        }
    }
}

    


