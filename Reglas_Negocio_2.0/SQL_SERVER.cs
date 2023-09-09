using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas_Negocio_2._0
{
    public class SQL_SERVER
    {
        public String sLastError = string.Empty;
        SqlConnection Connection { get; set; }



        public Boolean SiHayconexion(string sServer, string sUsuario, string sContrasena)
        {
            Boolean bAllOK = false;

            //conexion a la base de datos

            string sCadenaConexion = $"Server={sServer};Database=master;User Id={sUsuario};Password={sContrasena};";

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


        public void LlenarTreeView(TreeView treeView)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT name, database_id, create_date FROM sys.databases";
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dbName = reader["name"].ToString();
                            int dbId = (int)reader["database_id"];
                            DateTime createDate = (DateTime)reader["create_date"];

                            // Agrega un nodo para la base de datos
                            TreeNode dbNode = new TreeNode($"{dbName} (ID: {dbId}) - Created on {createDate.ToShortDateString()}");
                            treeView.Nodes.Add(dbNode);

                            // Obtén y agrega las tablas de la base de datos como nodos secundarios
                            DataTable tables = connection.GetSchema("Tables", new[] { null, dbName, null, "BASE TABLE" });
                            foreach (DataRow table in tables.Rows)
                            {
                                string tableName = table["TABLE_NAME"].ToString();
                                TreeNode tableNode = new TreeNode(tableName);
                                dbNode.Nodes.Add(tableNode);
                            }
                        }
                    }
                }
            }
        }
    }
}
