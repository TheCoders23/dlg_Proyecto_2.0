using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reglas_Negocio_2;

namespace Reglas_Negocio_2._0
{
    public class SQL_SERVER
    {
        public String sLastError = string.Empty;
        //public string sCadenaConexion = string.Empty;
       
            
            public String sCadenaConexion { get; set; } // Propiedad pública
            public void SetMiVariable(string servidor)
            {
               sCadenaConexion = servidor;
            }
       

        public Boolean SiHayconexion( String sServer, string sUsuario, string sContrasena)
        {
            Boolean bAllOK = false;

            //conexion a la base de datos

            sCadenaConexion = $"Server={sServer};Database=master;User Id={sUsuario};Password={sContrasena};";

            try
            {
                using (SqlConnection conexion = new SqlConnection(sCadenaConexion))
                {
                    conexion.Open();
                    conexion.Close();
                    // Si la conexión se abre con éxito, establece bAllOK en true
                    bAllOK = true;
                }
            }
            catch (Exception ex)
            {
                bAllOK = false;
                sLastError = ex.Message;
            }

            return bAllOK;
        }

        public TreeView LlenarTreeView(String sServer)
        {
            String connectionString = $"Server={sServer};Integrated Security=True;";

            TreeView treeView = new TreeView();

            using (SqlConnection connection = new SqlConnection(connectionString))
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

            return treeView;
        }
    }
}
