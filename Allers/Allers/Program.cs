using System;
using System.Collections.Generic;
using static Allers.FuercitaBruta;
using System.Diagnostics;
using System.Threading;

namespace Allers
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [MTAThread]
        public static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //escoger nucleo del pc
            //Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(3);
            //dar prioridad alta al nucleo

            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;
            //analisisFuerzaBruta();
            analisisClustering();

            
            
        }
        public static void analisisClustering()
        {
            FuercitaBruta principal = new FuercitaBruta();
            principal.cargarDatos();
            Clustering clustering = new Clustering(principal.clientes, 5);
            Cluster[] clusters = clustering.clusters;
            for (int i = 0; i < clusters.Length; i++)
            {
                Console.Write("{");
                foreach(Cliente actual in clusters[i].elementos)
                {
                    Console.Write(actual.CardCode + ",");
                }
                Console.WriteLine("}");

            }
        }
        public static void analisisFuerzaBruta()
        {
            FuercitaBruta principal = new FuercitaBruta();
            principal.cargarDatos();
            int i = 0;
            while (i < 20)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                principal.cleanData(0.0002, 1.33959370123042E-05);
                IEnumerable<IEnumerable<Articulo>> combinaciones = principal.GetPowerSet(principal.articulos);
                /*Console.Write("ITEMSETS RESULTANTES");
                combinaciones.OrderBy(x => x.Count()).ToList().ForEach(i =>
                {
                    Console.Write("{");
                    i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                    Console.WriteLine("}");
                });*/
                List<transWithSupp> listaFinal = principal.frequentItemSet(combinaciones, 0.1);
                //Console.Write("ITEMSETS FRECUENTES: " + listaFinal.Count() + "\n");
                /* listaFinal.OrderBy(x => x.getItemSet().Count()).ToList().ForEach(i =>
                 {
                     Console.Write("{");
                     i.getItemSet().ToList().ForEach(j => Console.Write(j.itemName + ","));
                     Console.WriteLine("}");
                 });*/
                principal.generateRules(listaFinal);
                /* Console.WriteLine("REGLAS GENERADAS");
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

                 });*/
                principal.checkRules(0.5);
                /*  Console.WriteLine("REGLAS QUE SUPERAN EL UMBRAL");
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

                  });*/
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                i++;
            }
          
           
        }
    }
}

