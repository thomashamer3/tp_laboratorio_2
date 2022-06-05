using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FormGimnasio
{
    public partial class FrmGym : Form
    {

        #region Atributos
        private Gimnasio gimnasio;
        private Gimnasio gimnasioFiltrado;
        private Serializacion<List<Socio>> serializador;
        private string rutaArchivo;
        #endregion

        #region Propiedades
        public int Capacidad { get; }

        #endregion

        #region Constructores
        public FrmGym()
        {
            InitializeComponent();
        }
        #endregion


        #region Metodos
        /// <summary>
        /// Carga el Listado y Actualiza el Listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGym_Load(object sender, EventArgs e)
        {

            serializador = new Serializacion<List<Socio>>();
            rutaArchivo = Environment.CurrentDirectory + @"\Socios.xml";
            gimnasio = new Gimnasio(this.EstablecerCapacidad(Capacidad));

            try
            {

                if (File.Exists(rutaArchivo))
                {
                    serializador.Importar(rutaArchivo, out this.gimnasio.lista);
                    this.ActualizarListBox();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            this.ActualizarDatos();
            this.lblCapacidadSocios.Text += gimnasio.Capacidad.ToString();

        }

        /// <summary>
        /// Agrega un nuevo Socio al Listado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSocio_Click(object sender, EventArgs e)
        {

            FrmAltaSocio frmSocio = new FrmAltaSocio();
            Socio socio;

            frmSocio.StartPosition = FormStartPosition.CenterScreen;

            DialogResult rta = frmSocio.ShowDialog();

            if (rta == DialogResult.OK)
            {
                socio = frmSocio.AgregarSocio();
                try
                {
                    if (gimnasio.Agregar(socio))
                    {

                        this.ActualizarListBox();
                        this.ActualizarDatos();

                    }
                    else
                    {
                        MessageBox.Show("El Socio ya se Encuentra Ingresado", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (CapacidadMaximaException ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        /// <summary>
        /// Establece la Capacidad del Gimnasio.
        /// </summary>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        private int EstablecerCapacidad(int capacidad)
        {

            FrmCapacidad frmCapacidad = new FrmCapacidad();
            frmCapacidad.StartPosition = FormStartPosition.CenterScreen;

            DialogResult rta = frmCapacidad.ShowDialog();

            if (rta == DialogResult.OK)
            {
                capacidad = frmCapacidad.CapacidadGimnasio;

            }

            return capacidad;

        }

        /// <summary>
        /// Guarda el Listado en Formato .txt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarListadoTxt_Click_1(object sender, EventArgs e)
        {
            if (this.lstSocios.Items.Count > 0)
            {
                 if (this.lstSocios.Items.Count != this.gimnasio.lista.Count)
                 {
                    if (MessageBox.Show("El Listado Se Guardara Tal Como Figura en Pantalla!",
                      "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                     {
                          this.ExportTxt();
                     }

                 }
                else
                {
                  this.ExportTxt();
                }

            }
            else
            {
                MessageBox.Show("El Listado Esta Vacio!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Guarda un Archivo en el Escritorio con el Nombre "Listado Socios" y la Extensión .txt.
        /// </código>
        /// </summary>
        private void ExportTxt()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "TXT files|*.txt",
                Title = "Guardar Archivo",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "txt",
                CheckPathExists = true,
                CheckFileExists = false,
                FileName = "Listado socios"

            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    sw.WriteLine("Listado Generado El:  " + this.lblFecha.Text + "\n\n");

                    foreach (var item in lstSocios.Items)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.WriteLine("\n\nTotal Facturado: " + this.lblTotalFacturado.Text);
                    sw.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Guarda el Listado en Formato .XML este Filtrado o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarListadoXml_Click(object sender, EventArgs e)
        {

            if (this.lstSocios.Items.Count > 0)
            {
                if (this.lstSocios.Items.Count != this.gimnasio.lista.Count)
                {
                    if (MessageBox.Show("El Listado se Guardara Tal Como Figura en Pantalla!",
                        "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        this.ExportXml();
                    }
                    
                }
                else
                {
                    this.ExportXml();
                }
            }
            else
            {
                MessageBox.Show("El Listado Esta Vacio!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exporta una Lista de Objetos a un Archivo XML.
        /// </summary>
        private void ExportXml()
        {
            serializador = new Serializacion<List<Socio>>();
            try
            {
                if (!string.IsNullOrEmpty(this.txtFiltro.Text))
                {

                    this.gimnasio.lista = new List<Socio>(this.gimnasioFiltrado.lista);

                }

                if (serializador.Exportar(this.gimnasio.lista))
                {
                    MessageBox.Show("El Archivo ha Sido Generado con Exito." +
                                  " El Mismo se Encuentra en el Escritorio.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Actualiza el Listbox.
        /// </summary>
        private void ActualizarListBox()
        {
            this.lstSocios.DataSource = null;
            this.lstSocios.DataSource = this.gimnasio.lista;
        }

        /// <summary>
        /// Elimina un Socio del Listado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstSocios.Items.Count == 0)
            {
                MessageBox.Show("Debe Cargar a Un Socio para Eliminarlo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Socio socio = this.lstSocios.SelectedItem as Socio;
                if (socio is not null)
                {

                    if (MessageBox.Show("Estas Seguro que Deseas Eliminar al Socio Actual?",
                         "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        if (this.gimnasio.Remover(socio))
                        {
                            this.ActualizarDatos();
                            this.ActualizarListBox();
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Actualza los Labels Cada Vez que se Agrega o Elimina un Socio.
        /// </summary>
        private void ActualizarDatos()
        {
            this.lblNumLibres.Text = gimnasio.LugaresLibres.ToString();
            this.lblTotalFacturado.Text = "$ " + this.gimnasio.TotalFacturado().ToString();
        }

        /// <summary>
        /// Filtra el Listbox en Base a la Palabra que se le Escriba.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            int dni;
            gimnasioFiltrado = new Gimnasio();
            if (!string.IsNullOrEmpty(this.txtFiltro.Text))
            {

                this.lstSocios.DataSource = null;
                this.lstSocios.Items.Clear();
                int.TryParse(this.txtFiltro.Text, out dni);
                foreach (Socio socio in this.gimnasio.lista)
                {
                    if (socio.Apellido.StartsWith(this.txtFiltro.Text, StringComparison.InvariantCultureIgnoreCase) ||
                        socio.Nombre.StartsWith(this.txtFiltro.Text, StringComparison.InvariantCultureIgnoreCase) ||
                        socio.Status.ToString().StartsWith(this.txtFiltro.Text,StringComparison.InvariantCultureIgnoreCase)||
                        socio.Pase.ToString().StartsWith(this.txtFiltro.Text, StringComparison.InvariantCultureIgnoreCase))
                     {
                        this.lstSocios.Items.Add(socio);
                        this.gimnasioFiltrado.Agregar(socio);
                    }
                }
            }
            else
            {
                this.ActualizarListBox();
            }
        }

        /// <summary>
        /// Establece La Hora y Dia Actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmHora_Tick(object sender, EventArgs e)
        {
            this.lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            this.lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// Abre la Ventana de Informes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInformes_Click(object sender, EventArgs e)
        {
            if (this.gimnasio.lista.Count > 0)
            {
                FrmInformes frmInformes = new FrmInformes(this.gimnasio);
                frmInformes.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Hay Socios Ingresados!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Edita un Socio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.lstSocios.Items.Count == 0)
            {
                MessageBox.Show("Debe Cargar a Un Socio para Editar sus Datos.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Socio socio = this.lstSocios.SelectedItem as Socio;

                FrmAltaSocio frmSocio = new FrmAltaSocio(socio);

                frmSocio.StartPosition = FormStartPosition.CenterScreen;

                DialogResult rta = frmSocio.ShowDialog();

                if (rta == DialogResult.OK)
                {
                    socio = frmSocio.AgregarSocio();
                    try
                    {
                        if (gimnasio.Agregar(socio))
                        {

                            this.ActualizarListBox();
                            this.ActualizarDatos();

                        }
                        else
                        {
                            MessageBox.Show("El Socio ya se Encuentra Ingresado.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (CapacidadMaximaException ex)
                    {
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            

        }

        /// <summary>
        /// Si el Usuario Hace Clic en el Boton "No", el Formulario No se Cerrara.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="FormClosingEventArgs">La clase FormClosingEventArgs contiene datos relacionados
        /// con un evento FormClosing.</param>
        private void FrmGym_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro Que Desea Salir?", "Cerrar", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }


    #endregion


}


