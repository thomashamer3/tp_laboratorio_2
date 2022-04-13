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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Inicializa los Componentes
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
            CenterToParent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Da Opciones al Usuario para elegir la Operacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Carga el Form de la Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza la Operacion Selecionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text))
            {
                MessageBox.Show("Error, Ingrese un Numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!Double.TryParse(txtNumero1.Text, out double numeroError) || !Double.TryParse(txtNumero2.Text, out numeroError) || Double.IsNaN(numeroError))
                {
                    MessageBox.Show("Error, Ingrese un Numero Valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

                    if (resultado == double.MinValue)
                    {
                        IstOperaciones.Items.Add(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + " = syntax error");
                        lblResultado.Text = "No se puede dividir por 0";
                        this.btnConvertirABinario.Enabled = false;
                        this.btnConvertirADecimal.Enabled = false;
                    }
                    else
                    {
                        lblResultado.Text = resultado.ToString();
                        IstOperaciones.Items.Add(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + " = " + resultado);
                        this.btnConvertirABinario.Enabled = true;
                        this.btnConvertirADecimal.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Recibe Dos Numeros y un Operador ademas Realiza una la Operacion con el Operador Seleccionado. 
        /// </summary>
        /// <param name="numero1">Primer Numero en Formato string a Operar.
        /// <param name="numero2">Segundo Numero en Formato string a Operar.
        /// <param name="operador">Operador en Formato string a Operar.
        /// <returns>El Resultado de la Operacion.
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            char operadorNum = '+';

            foreach (char ope in operador)
            {
                operadorNum = ope;
            }

            return Calculadora.Operar(num1, num2, operadorNum);
        }

        /// <summary>
        /// Convierte un Numero Double a Formato Binario y lo Muestra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();

            this.lblResultado.Text = numero.DecimalBinario(Convert.ToDouble(lblResultado.Text));
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Convierte un String de Formato Binario a un Numero Double y lo Muestra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando numero = new Operando();
            this.lblResultado.Text = numero.BinarioDecimal(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = false;
            btnConvertirABinario.Enabled = true;
        }

        /// <summary>
        /// Limpia Todos los Campos del Form.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Limpia el Form Completamente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Cierra el Form en caso que el Usuario quiera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro de querer Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        /// <summary>
        /// Muestra el Resultado de una Operacion o Una Conversion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Advierte al Usuario por si quiere salir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?", "Cerrar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void IstOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}
