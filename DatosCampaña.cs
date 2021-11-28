using Control_Pagos.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Pagos.Presentacion
{
    public partial class DatosCampaña : Form
    {
        public DatosCampaña()
        {
            InitializeComponent();

        }
        public static int Numero;
        CampañasController CC = new CampañasController();
        private void DatosCampaña_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CC.Mostrarcampañas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            CargarDatos CD = new CargarDatos();
            Numero = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            this.Close();
            CD.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = CC.MostrarcampañasXID(textBox1.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
    }
}
