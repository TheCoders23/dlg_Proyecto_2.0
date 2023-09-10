using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dlg_Proyecto_2._0
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 Login = new Form1();
            Login.ShowDialog();

            Principal principal = new Principal();
            if (Login.blogcorrecto)
            {
                principal.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Tiene Acceso a la DB");
            }
        }
    }
}
