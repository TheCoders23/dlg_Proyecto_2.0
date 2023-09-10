using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            //SQL_SERVER sQL_SERVER = new SQL_SERVER();
            //TreeView treeView = sQL_SERVER.LlenarTreeView(sQL_SERVER.sCadenaConexion);

            //panel1.Controls.Add(treeView); // Corregido para usar "treeView" en lugar de "treeView1"

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public String sLastError = string.Empty;
        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            
            String connectionString = $"Server={sServer};Integrated Security=True;";

            TreeView treeView = new TreeView();

            using (SqlConnection connection = new SqlConnection(SQL_SERVER.sCadenaConexion))
            {
                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string dbName = reader["name"].ToString();
                        TreeNode databaseNode = new TreeNode(dbName);
                        treeView.Nodes.Add(databaseNode);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    sLastError = ex.Message;
                }
            }
        }
    }
}
