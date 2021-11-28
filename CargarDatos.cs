using Control_Pagos.Controlador;
using Control_Pagos.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Pagos.Presentacion
{
    public partial class CargarDatos : Form
    {
        public CargarDatos()
        {
            InitializeComponent();
        }
        CRMBD DB = new CRMBD();
        CampañasController CC = new CampañasController();
        private void CargarDatos_Load(object sender, EventArgs e)
        {
            textBox1.Text = (DatosCampaña.Numero).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                MessageBox.Show("Verifica el Numero de Campaña Primero");
            }
            else
            {
                OpenFileDialog dlFicheroCSV = new OpenFileDialog();
                dlFicheroCSV.Title = "Abrir fichero CSV,txt o xlsx";
                //dlFicheroCSV.InitialDirectory = @"C:\";
                dlFicheroCSV.Filter = "Ficheros de texto y CSV (*.txt, *.csv)|*.txt;*.csv|" +
                    "Ficheros de texto (*.txt)|*.txt|" +
                    "Ficheros CSV (*.csv)|*.csv|" +
                    "Ficheros XLS (*.xlsx)|*.xlsx|" +
                    "Todos los ficheros (*.*)|*.*";
                dlFicheroCSV.FilterIndex = 1;
                dlFicheroCSV.RestoreDirectory = true;
                if (dlFicheroCSV.ShowDialog() == DialogResult.OK)
                {
                    txtFicheroCSV.Text = dlFicheroCSV.FileName;
                    button4.Enabled = true;
                }
            }
        }
        private void CargarDatosCSV(string ficheroCSV, char separador,
            bool primeraLineaTitulo, string separadorCampos)
        {
            dbTabla.DataSource = null;
            dbTabla.Rows.Clear();

            DataTable tablaDatos = new DataTable();
            string[] lineas = File.ReadAllLines(ficheroCSV, Encoding.Default);

            if (lineas.Length > 0)
            {
                //Si la primea línea contiene el título  
                string[] etiquetaTitulosFinal;
                if (primeraLineaTitulo)
                {
                    string primelaLinea = lineas[0];
                    string[] etiquetaTitulos = primelaLinea.Split(separador);
                    List<string> lista = new List<string>();
                    foreach (string campoActual in etiquetaTitulos)
                    {
                        string valor = campoActual;
                        // Quitamos el posible carácter de inicio y fin de valor
                        if (separadorCampos != "")
                        {
                            valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
                            valor = valor.TrimStart(Convert.ToChar(separadorCampos));
                        }
                        tablaDatos.Columns.Add(new DataColumn(valor));
                        lista.Add(valor);
                    }
                    etiquetaTitulosFinal = lista.ToArray();
                }
                else
                {
                    string primelaLinea = lineas[0];
                    string[] etiquetaTitulos = primelaLinea.Split(separador);
                    int numero = 0;
                    List<string> lista = new List<string>();
                    foreach (string campoActual in etiquetaTitulos)
                    {
                        string valor = "Columna" + Convert.ToString(numero);
                        // Quitamos el posible carácter de inicio y fin de valor
                        if (separadorCampos != "")
                        {
                            valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
                            valor = valor.TrimStart(Convert.ToChar(separadorCampos));
                        }

                        tablaDatos.Columns.Add(new DataColumn(valor));
                        lista.Add(valor);
                        numero++;
                    }
                    etiquetaTitulosFinal = lista.ToArray();
                }

                //Resto de filas de datos
                int inicioFila = 0;
                if (primeraLineaTitulo)
                    inicioFila = 1;

                for (int i = inicioFila; i < lineas.Length; i++)
                {
                    string[] filasDatos = lineas[i].Split(separador);
                    DataRow dataGridS = tablaDatos.NewRow();
                    int columnIndex = 0;
                    foreach (string campoActual in etiquetaTitulosFinal)
                    {
                        string valor = filasDatos[columnIndex++];
                        // Quitamos el posible carácter de inicio y fin de valor
                        if (separadorCampos != "")
                        {
                            valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
                            valor = valor.TrimStart(Convert.ToChar(separadorCampos));
                        }
                        dataGridS[campoActual] = valor;
                    }
                    tablaDatos.Rows.Add(dataGridS);
                }
            }
            if (tablaDatos.Rows.Count > 0)
            {
                dbTabla.DataSource = tablaDatos;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtFicheroCSV.Text))
            {
                try
                {
                    CargarDatosCSV(txtFicheroCSV.Text,
                        Convert.ToChar(txtSeparador.Text), opTitulos.Checked, txtSeparadorCampos.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error al leer CSV...",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe el fichero CSV seleccionado.",
                    "Fichero no encontrado...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatosCampaña Dt = new DatosCampaña();
            Dt.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if ((dbTabla.Rows.Count == 0))
                {
                    MessageBox.Show("Nada que guardar!", "Davincci");
                    return;
                }
                else
                {
                    if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && opTitulos.Checked == true)
                    {
                        string query = "SPGuardarDatosObligatorios";
                        SqlCommand cmd = new SqlCommand(query, DB.AbrirConexion());
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (DataGridViewRow row in dbTabla.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@NUMERO_CAMPAÑA", Convert.ToInt32(textBox1.Text));
                            cmd.Parameters.AddWithValue("@NOMBRE", Convert.ToString(row.Cells["NOMBRE"].Value));
                            cmd.Parameters.AddWithValue("@APELLIDOS", Convert.ToString(row.Cells["APELLIDOS"].Value));
                            cmd.Parameters.AddWithValue("@DIRECCION", Convert.ToString(row.Cells["DIRECCION"].Value));
                            cmd.Parameters.AddWithValue("@TELEFONO", Convert.ToString(row.Cells["TELEFONO"].Value));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Datos Agregados satisfactoriamente", "Davincci");
                        button4.Enabled = false;
                    }
                    else if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || opTitulos.Checked == false)
                    {
                        string query = "SPGuardarDatosObligatorios";
                        SqlCommand cmd = new SqlCommand(query, DB.AbrirConexion());
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (DataGridViewRow row in dbTabla.Rows)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@NUMERO_CAMPAÑA", Convert.ToInt32(textBox1.Text));
                            cmd.Parameters.AddWithValue("@NOMBRE", Convert.ToString(row.Cells["Columna0"].Value));
                            cmd.Parameters.AddWithValue("@APELLIDOS", Convert.ToString(row.Cells["Columna1"].Value));
                            cmd.Parameters.AddWithValue("@DIRECCION", Convert.ToString(row.Cells["Columna2"].Value));
                            cmd.Parameters.AddWithValue("@TELEFONO", Convert.ToString(row.Cells["Columna3"].Value));
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Datos Agregados satisfactoriamente", "Davincci");
                        button4.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione columnas a Guardar","Davincci");
                    }
                    }              
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            dbTabla.DataSource = CC.MostrarDatosCRM();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                CC.GuardarColumnasSinNombre(txtFicheroCSV.Text, char.Parse(txtSeparador.Text));
                MessageBox.Show("Guardado", "Davincci");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Davincci");
            }
        }
    }
}
