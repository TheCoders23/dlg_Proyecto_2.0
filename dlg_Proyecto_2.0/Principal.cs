using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reglas_Negocio_2;
using Reglas_Negocio_2._0;

namespace dlg_Proyecto_2._0
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
       SQL_SERVER SQL_SERVER = new SQL_SERVER();
        private void Principal_Load(object sender, EventArgs e)
        {
            SQL_SERVER.LlenarTreeView(ToString());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
    }
}
