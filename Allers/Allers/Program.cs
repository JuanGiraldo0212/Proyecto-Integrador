using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Allers.FuercitaBruta;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            analisisFuerzaBruta();
        }
        public static void analisisFuerzaBruta()
        {
            FuercitaBruta principal = new FuercitaBruta();
            principal.cargarDatos();
            principal.cleanData(0.0002, 1.33959370123042E-05);
            IEnumerable<IEnumerable<Articulo>> combinaciones = principal.GetPowerSet(principal.articulos);
            Console.Write("ItemSets");
            combinaciones.OrderBy(x => x.Count()).AsParallel().ToList().ForEach(i =>
            {
                Console.Write("{");
                i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.WriteLine("}");
            });



            List<transWithSupp> listaFinal = principal.frequentItemSet(combinaciones, 0.25);
            principal.generateRules(listaFinal);
            Console.WriteLine("Reglas Generadas");
            principal.rules.ForEach(r =>
            {
                Console.Write("{");
                r.antecedente.ForEach(a => Console.Write(a.itemName + ","));
                Console.Write("-->");
                r.consecuente.ForEach(b => Console.Write(b.itemName + ","));
                Console.Write("}");
                Console.Write("Confidence count:" + r.getConf());
                Console.Write(" Support Count:" + r.getSupp());

                Console.Write("\n");

            });
            principal.checkRules(0.05);
            Console.WriteLine("Reglas que superan el umbral");
            principal.rules.ForEach(r =>
            {
                Console.Write("{");
                r.antecedente.ForEach(a => Console.Write(a.itemName + ","));
                Console.Write("-->");
                r.consecuente.ForEach(b => Console.Write(b.itemName + ","));
                Console.Write("}");
                Console.Write("Confidence count:" + r.getConf());
                Console.Write(" Support Count:" + r.getSupp());

                Console.Write("\n");

            });
        }
    }
}

