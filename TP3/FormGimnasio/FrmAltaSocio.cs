using Entidades;
using System;
using System.Windows.Forms;

namespace FormGimnasio
{
    public partial class FrmAltaSocio : Form
    {
        private Socio socio;

        public FrmAltaSocio()
        {
            InitializeComponent();
        }

        public FrmAltaSocio(Socio socio) : this()
        {
            this.socio = socio;
            this.AgregarDatosDeUsuario();
        }

        /// <summary>
        /// Se Encarga de Cargar el Combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSocio_Load(object sender, EventArgs e)
        {
            this.cmbPase.DataSource = Enum.GetValues(typeof(Socio.EPase));
            this.cmbStatus.DataSource = Enum.GetValues(typeof(Socio.EStatus));
            this.cmbPago.DataSource = Enum.GetValues(typeof(Socio.EPago));
            this.cmbPase.SelectedItem = Socio.EPase.Libre;
            this.cmbPago.SelectedItem = Socio.EPago.Efectivo;
            this.cmbStatus.SelectedItem = Socio.EStatus.Activo;
            this.cmbPase.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPago.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            if (this.socio is null)
            {
                this.txtFechaIngreso.Visible = false;
                this.lblFecha.Visible = false;
            }
            else
            {
                this.txtFechaIngreso.Visible = true;
                this.lblFecha.Visible = true;
            }

        }

        /// <summary>
        /// Agrega los Datos Del Usuario al Modificar.
        /// </summary>
        private void AgregarDatosDeUsuario()
        {
            this.txtNombre.Text = socio.Nombre;
            this.txtApellido.Text = socio.Apellido;
            this.txtDni.Text = socio.Dni.ToString();
            this.cmbPago.SelectedItem = socio.Pago;
            this.cmbPase.SelectedItem = socio.Pase;
            this.cmbStatus.SelectedItem = socio.Status;
            this.btnAceptar.Text = "Modficar";
            this.txtFechaIngreso.Text = socio.FechaIngreso.ToString();
            this.Text = "Modificar Usuario";

        }

        #region Metodos
        /// <summary>
        /// Devuelve un Socio.
        /// </summary>
        /// <returns>Un objeto tipo socio</returns>
        public Socio AgregarSocio() => this.socio;

        /// <summary>
        /// Se Encarga de Dar de Alta un Nuevo Socio o Modficarlo Si Ya Existe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtNombre.Text) || String.IsNullOrWhiteSpace(this.txtApellido.Text) ||
                String.IsNullOrWhiteSpace(this.txtDni.Text))
            {
                MessageBox.Show("Debes completar todos los campos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (!int.TryParse(txtDni.Text, out int numeroError))
                {
                    MessageBox.Show("El DNI Ingresado Es Invalido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else

                if (socio is null)
                {
                    socio = new Socio(this.txtNombre.Text,
                                      this.txtApellido.Text,
                                      this.GetGender(),
                                      int.Parse(this.txtDni.Text),
                                      (Socio.EPase)this.cmbPase.SelectedItem,
                                      (Socio.EStatus)this.cmbStatus.SelectedItem,
                                      (Socio.EPago)this.cmbPase.SelectedItem);
                }
                else
                {
                    socio.Apellido = this.txtApellido.Text;
                    socio.Nombre = this.txtNombre.Text;
                    socio.Pago = (Socio.EPago)this.cmbPase.SelectedItem;
                    socio.Pase = (Socio.EPase)this.cmbPase.SelectedItem;
                    socio.Sexo = this.GetGender();
                    socio.Status = (Socio.EStatus)this.cmbStatus.SelectedItem;
                    socio.Dni = int.Parse(this.txtDni.Text);

                }
                this.DialogResult = DialogResult.OK;

            }
        }

        /// <summary>
        /// Se Encarga de Establecer el Sexo Del Socio.
        /// </summary>
        /// <returns>El sexo del socio</returns>
        private string GetGender() => this.rbtnFemenino.Checked ? "FEMENINO" : "MASCULINO";

        private void btnCancelar_Click(object sender, EventArgs e) => this.Close();

        private void FrmSocio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Cancel)
            {
                if (MessageBox.Show("Deseas Cerrar La Ventana?", "Salir",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Dispose();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Es una Funcion que Solo Permite Ingresar Letras en un Cuadro de Texto.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="KeyPressEventArgs">La clase KeyPressEventArgs contiene información sobre la
        /// pulsación de tecla, como la tecla que se presionó y las teclas modificadoras (CTRL, ALT y
        /// SHIFT) que se presionaron al mismo tiempo.</param>
        /// <returns>
        /// El Metodo Devuelve un Valor Booleano.
        /// </returns>
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se Permiten Letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Comprueba si la Tecla Presionada es una Letra, si no lo es.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="KeyPressEventArgs">La clase KeyPressEventArgs contiene información sobre la
        /// pulsación de tecla, como la tecla que se presionó y las teclas modificadoras (CTRL, ALT y
        /// SHIFT) que se presionaron al mismo tiempo.</param>
        /// <returns>
        /// El Metodo Devuelve un Valor Booleano.
        /// </returns>
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se Permiten Letras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Es una Funcion que Solo Permite Ingresar Numeros En un Cuadro de Texto.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="KeyPressEventArgs">La clase KeyPressEventArgs contiene información sobre la
        /// pulsación de tecla, como la tecla que se presionó y las teclas modificadoras (CTRL, ALT y
        /// SHIFT) que se presionaron al mismo tiempo.</param>
        /// <returns>
        /// El Metodo Devuelve un Valor Booleano.
        /// </returns>
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo Se permiten Numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
