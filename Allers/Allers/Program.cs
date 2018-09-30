using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Allers
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            FuercitaBruta principal = new FuercitaBruta();
            principal.cargarDatos();
            principal.cleanData(0.0002, 1.33959370123042E-05);
            principal.pruebaCombinaciones();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

    }
}

