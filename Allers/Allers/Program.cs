using System;
using System.Collections.Generic;
using static Allers.BruteForce;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Windows.Forms;

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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            //escoger nucleo del pc
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            //dar prioridad alta al nucleo

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            //clusterAnalysis();
            
            
			Application.Run(new PanelInicio());
			/*
			Context ctx = new Context();
			ctx.runApriori(2,50);
			Console.WriteLine(ctx.apriori.highUtility(ctx.listSales, ctx.listItems));
            */



            /*
            Context contexto = new Context();
            contexto.loadDataClustering(4000);

            Clustering clustering = new Clustering(contexto.listClients, 3, 0);
            Console.WriteLine("Termino");
            */




            //escoger nucleo del pc
           // Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(3);
            //dar prioridad alta al nucleo

            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;
            //analisisFuerzaBruta();
           // ClusteringAnalysis(4,0);
            
        }
        //public static void ClusteringAnalysis(int clustersNumber, int botTHSales)
        //{
            
            
        //    //main.cleanData(0, 0, 100);           
        //    Clustering clustering = new Clustering(clustersNumber, botTHSales);
        //    Cluster[] clusters = clustering.clusters;
        //    Console.WriteLine("CLUSTERS:");
        //    for (int i = 0; i < clusters.Length; i++)
        //    {
        //        Console.Write("{");
        //        foreach(Client actual in clusters[i].itemsCluster)
        //        {
        //            Console.Write(actual.CardCode + ",");
        //        }
        //        Console.WriteLine("}");
        //        Console.WriteLine("Elementos: " + clusters[i].itemsCluster.Count());
        //        Console.WriteLine("CENTROIDE:");
        //        for(int j = 0; j < clusters[i].centroid.Count(); j++)
        //        {
        //            if(clusters[i].centroid[j] != 0)
        //            {
        //                Console.WriteLine(clustering.main.listItems.ElementAt(j).itemName);
        //            }
        //        }
        //    }
        //    Console.WriteLine("CLIENTES EXISTENTES:");
        //    Console.WriteLine(clustering.main.listClients.Count());
        //    Console.WriteLine("CLIENTES ASIGNADOS A CLUSTERS:");
        //    Console.WriteLine(clustering.clusters.Sum(i => i.itemsCluster.Count()));
        //}

        public static void clusterAnalysis()
        {

            Context contexto = new Context();
            contexto.loadDataClustering(4000);
            
            for(int j = 0; j < 20; j++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Clustering cluster = new Clustering(contexto.listClients, 3, 1);
                sw.Stop();
                String tiempoPartido = sw.Elapsed.TotalMilliseconds.ToString();
                Console.WriteLine(tiempoPartido);
            }

            Console.WriteLine("Finalizo Beycker");

            //Clustering cluster = new Clustering();
        }

        public static void bruteForceAnalysis()
        {
            BruteForce mainBF = new BruteForce();
            //mainBF.getContext().loadData();
            int i = 0;
            while (i < 20)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
               // mainBF.cleanData(0.0002, 1.33959370123042E-05);
                IEnumerable<IEnumerable<Item>> combinaciones = mainBF.GetPowerSet(mainBF.getContext().listItems);
                /*Console.Write("ITEMSETS RESULTANTES");
                combinaciones.OrderBy(x => x.Count()).ToList().ForEach(i =>
                {
                    Console.Write("{");
                    i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                    Console.WriteLine("}");
                });*/
                List<transWithSupp> listaFinal = mainBF.frequentItemSet(combinaciones, 0.1);
                //Console.Write("ITEMSETS FRECUENTES: " + listaFinal.Count() + "\n");
                /* listaFinal.OrderBy(x => x.getItemSet().Count()).ToList().ForEach(i =>
                 {
                     Console.Write("{");
                     i.getItemSet().ToList().ForEach(j => Console.Write(j.itemName + ","));
                     Console.WriteLine("}");
                 });*/
                mainBF.generateRules(listaFinal);
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
                mainBF.checkRules(0.5);
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

