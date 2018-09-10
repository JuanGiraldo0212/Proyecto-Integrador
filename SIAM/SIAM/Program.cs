using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIAM
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        private static ModeloContainer ctx;
        private static List<Cliente> clientes;
        private static List<Producto> productos;
        private static List<Transaccion> transacciones;
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void lecturaDatos() {

            StringReader in = new StringReader();





        }
    }
}
