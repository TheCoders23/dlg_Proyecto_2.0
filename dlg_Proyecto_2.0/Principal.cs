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

            // Inicializa la instancia de SQL_SERVER
            sQL_SERVER = new SQL_SERVER();

            // Configura el Timer para actualizarse cada 5 segundos (5000 milisegundos)
            updateTimer = new Timer();
            updateTimer.Interval = 5000;
            updateTimer.Tick += UpdateTimer_Tick;

            // Inicia el Timer
            updateTimer.Start();

        }


        private SQL_SERVER sQL_SERVER;
        private Timer updateTimer;
        SQL_SERVER SQL_SERVER = new SQL_SERVER();

        private void Principal_Load(object sender, EventArgs e)
        {
            // Inicialmente, llena el TreeView
            LlenarTreeView();

        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // Cuando se activa el Timer, actualiza el TreeView
            LlenarTreeView();
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

            //String connectionString = SQL_SERVER.sCadenaConexion;

            //TreeView treeView = new TreeView();

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {

            //        connection.Open();
            //        SqlCommand command = new SqlCommand("SELECT name FROM sys.databases", connection);
            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            string dbName = reader["name"].ToString();
            //            TreeNode databaseNode = new TreeNode(dbName);
            //            treeView1.Nodes.Add(databaseNode);
            //        }
            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        sLastError = ex.Message;
            //    }
            //}
        }


        private void LlenarTreeView()
        {
            SQL_SERVER instancia = new SQL_SERVER();

            string cadenaConexion = instancia.sCadenaConexion;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
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
                        treeView1.Nodes.Add(databaseNode);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    
                    MessageBox.Show("Sucedio un error al llenar el treeview", ex.Message);
                }
            }

            // Reemplaza el TreeView anterior con el nuevo TreeView
            panel1.Controls.Clear();
            panel1.Controls.Add(treeView1);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
