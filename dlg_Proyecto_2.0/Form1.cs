using Reglas_Negocio_2._0;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dlg_Proyecto_2._0
{
    public partial class Form1 : Form
    {
        public Boolean blogcorrecto = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL_SERVER acceso = new SQL_SERVER();

            if (acceso.SiHayconexion(tbservidor.Text, tbusuario.Text, tbcontrasena.Text))
            {
                MessageBox.Show(acceso.sLastError);
            }
            else
            {
                blogcorrecto = true;

                this.Close();

            }
        }

        private void tbservidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbcontrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
