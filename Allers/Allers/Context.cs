using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace Allers
{
    public class Context
    {
        
        public List<Item> listItems = new List<Item>();
        public List<Sale> listSales = new List<Sale>();
        public List<Client> listClients = new List<Client>();
        public List<List<Item>> listTransactions = new List<List<Item>>();
        Cluster[] clusters = new Cluster[0];

        public APriori apriori;
        public Clustering clustering;

        //Cluster[] clusters;
        //public List<List<string>> transaccionesClust = new List<List<string>>();

        public void loadDataClustering(int botTHSales)
        {
            listClients.Clear();
            listItems.Clear();
            listSales.Clear();
            listTransactions.Clear();
            var dataClients = File.ReadLines("...\\...\\Clientes.csv");
            var dataItems = File.ReadLines("...\\...\\Articulos.csv");
            var dataSales = File.ReadLines("...\\...\\Ventas.csv");

            foreach (var s in dataSales)
            {
                String[] data = s.Split(';');
                if (!s.Equals("") && data[4] != "NULL" && data[4] != "ItemCode" && Convert.ToInt32(data[5]) > botTHSales)
                {

                    Sale newSale = new Sale();
                    newSale.cardCode = data[0];
                    newSale.docNum = (data[1]);
                    newSale.docDate = data[2];
                    newSale.docTotal = Convert.ToDouble(data[3]);
                    newSale.itemCode = data[4];
                    newSale.amount = Convert.ToInt32(data[5]);
                    newSale.price = Convert.ToDouble(data[6]);
                    newSale.totalLine = Convert.ToDouble(data[7]);
                    listSales.Add(newSale);

                }
            }

            foreach (var s in dataItems)
            {
                String[] datos = s.Split(';');
                if (datos.Length > 1)
                {
                    if (datos[1] != "****" && datos[1] != "ItemName" && listSales.Any(m => m.itemCode.Equals(datos[0])))
                    {

                        Item newItem = new Item();
                        newItem.itemCode = Convert.ToInt32(datos[0]);
                        newItem.itemName = datos[1];
                        listItems.Add(newItem);

                    }
                }
                else
                {
                    break;
                }

            }

            foreach (var s in dataClients)
            {
                String[] datos = s.Split(';');
                if (s.Equals(""))
                {
                    break;
                }
                if (!s.Equals("") && datos[2] != "NULL" && datos[3] != "NULL" && datos[1] != "GroupName")
                {
                    Client newClient = new Client();
                    newClient.CardCode = datos[0].Trim();
                    newClient.GroupName = datos[1].Trim();
                    newClient.City = datos[2].Trim();
                    newClient.Dpto = datos[3].Trim();
                    newClient.PymntGruoup = datos[4].Trim();
                    newClient.items = new double[listItems.Count()];
                    listClients.Add(newClient);
                }
            }

            //Console.WriteLine(articulos.Count());
            //Console.WriteLine(ventas.Count());
            for (int i = 0; i < listItems.Count(); i++)
            {
                foreach (Sale sale in listSales)
                {
                    if (sale.itemCode.Equals(listItems[i].itemCode + ""))
                    {
                        try
                        {
                            listClients.First(k => k.CardCode.Equals(sale.cardCode)).items[i] += 1;
                            //Console.WriteLine("holi");
                        }
                        catch { }
                    }
                }
            }
        }
        

        public void cargarTransaccionesClust(int cluster)
        {
            List<List<string>> transClust = new List<List<string>>();
            var cons = listSales.GroupBy(x => x.docNum);
            //cons.ToList().ForEach(x=>Console.WriteLine(x.Key));
            foreach (var z in clusters[cluster].itemsCluster)
            {
                foreach (var s in cons)
                {
                    List<string> temp = new List<string>();
                    foreach (var r in s)
                    {
                        try
                        {
                            
                            if (r.cardCode.Trim().Equals(z.CardCode.Trim()))
                            {
                                temp.Add(r.itemCode);
                            }
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(r.itemCode);
                        }

                    }
                    //Console.WriteLine(s.Key);
                    //Console.WriteLine(temp.ToSt ring());
                    if (temp.Any())
                    {
                        transClust.Add(temp);
                    }
                    
                }
            }

            transaccionesClust = transClust;

        }
        public String convertRules(ReglaAsociacion rule) {

			String line = "";
			
				var ant = rule.X;
				var con = rule.Y;
				ant.ForEach(x=>line+=listItems.First(p=>p.itemCode==Convert.ToInt32(x)).itemName+",");
				line += "-";
				con.ForEach(y=>line+=listItems.First(p=>p.itemCode==Convert.ToInt32(y)).itemName+",");
				
			return line;


		}

        public List<List<string>> transaccionesClust = new List<List<string>>();

        public List<ReglaAsociacion> runApriori(int supp, int trust)
        {
            loadData();
			Console.WriteLine("Se cargaron los datos");
			apriori = new APriori();
                //loadTransactions();
                Console.WriteLine("Se cargaron las transacciones");
                List<List<string>> op = apriori.ItemsFrecuentes(transacciones, supp);
                Console.WriteLine("Se procesaron los itemsets");
                List<ReglaAsociacion> reglas = apriori.ReglasAsociacion(transacciones, op, trust);
            
           
            return reglas;
        }

        public List<ReglaAsociacion> runClusterApriori(int supp, int trust, int clust, int clustersNumber, int botTHSales, int clusteringMethod)
        {
           
            Console.WriteLine("Calculando");
            if (clusters.Count()==0)
            {
                runClustering(clustersNumber, botTHSales, clusteringMethod);
            }

            cargarTransaccionesClust(clust);
            apriori = new APriori();
            //loadTransactions();
            Console.WriteLine("Se cargaron las transacciones");
            List<List<string>> op = apriori.ItemsFrecuentes(transaccionesClust, supp);
            Console.WriteLine("Se procesaron los itemsets");
            List<ReglaAsociacion> reglas = apriori.ReglasAsociacion(transaccionesClust, op, trust);

         

            return reglas;
        }
        public String runHighUtility(double min, double supp)
        {
            if (apriori == null)
            {
                apriori = new APriori();
            }
            loadData();
            Console.WriteLine("Se cargaron los datos");
            String line = "";
            List<List<string>> freq = apriori.ItemsFrecuentes(transacciones, supp).Where(x => x.Count > 1).ToList();
            Console.WriteLine("Se generaron los frecuentes");
            var cons = listSales.GroupBy(x => x.docNum);
            foreach (var itemset in freq)
            {
                double utility = 0;
                List<String> names = new List<string>();
                List<String> usados = new List<String>();
                foreach (var trans in cons)
                {


                    foreach (var vent in trans)
                    {
                        bool alguno = false;
                        for (int i = 0; i < itemset.Count && !alguno; i++)
                        {
                            if (vent.itemCode.Equals(itemset[i]))
                            {
                                alguno = true;
                                utility += vent.docTotal;
                                if (!usados.Contains(itemset[i]))
                                {

                                    usados.Add(itemset[i]);
                                    names.Add(listItems.First(x => x.itemCode == Convert.ToInt32(itemset[i])).itemName);

                                }

                            }

                        }

                    }


                }

                if (utility >= min)
                {

                    line += "Los items: ";
                    names.ForEach(x => line += x + ", ");
                    line += " generan una utilidad de: $" + utility + "\n\n";

                }

            }


            return line;
        }


       

        public String[] runClusteringSEP(int clustersNumber, int botTHSales, int clusteringMethod)
        {
            String[] resultado = new string[2];

            loadDataClustering(botTHSales);
            clustering = new Clustering(listClients, clustersNumber, clusteringMethod);
            clusters = clustering.clusters;
            for (int i = 0; i < clusters.Length; i++)
            {
                resultado[0] += "CLUSTER " + i + ":$#Elementos: " + clusters[i].itemsCluster.Count() + "$Clientes Pertenecientes:$$";
                foreach (Client actual in clusters[i].itemsCluster)
                {
                    resultado[0] += "- " + actual.CardCode + "$";
                }
                resultado[0] += "$";
                resultado[1] += "COMPRAS REPRESENTATIVAS DEL CLUSTER #" + i + " (Centroide):$$";
                for (int j = 0; j < clusters[i].centroid.Count(); j++)
                {
                    if (clusters[i].centroid[j] != 0)
                    {
                        resultado[1] += "- " + listItems.ElementAt(j).itemName + "$";
                    }
                }
                resultado[1] += "$";
                //line += "\n";
            }

            return resultado;
        }

        public String runClustering(int clustersNumber, int botTHSales, int clusteringMethod)
        {
            String line = "INFORME CLUSTERIZACIÓN POR K-MEANS\n\n";
            loadDataClustering(botTHSales);
            clustering = new Clustering(listClients,clustersNumber, clusteringMethod);
            clusters = clustering.clusters;
            for (int i = 0; i < clusters.Length; i++)
            {
                line += "CLUSTER " + i + ":\n#Elementos: " + clusters[i].itemsCluster.Count() + "\nClientes Pertenecientes:\n";
                foreach (Client actual in clusters[i].itemsCluster)
                {
                    line += actual.CardCode + "\n";
                }
                line += "Compras Representativas del Cluster (Centroide):\n";
                for (int j = 0; j < clusters[i].centroid.Count(); j++)
                {
                    if (clusters[i].centroid[j] != 0)
                    {
                        line += listItems.ElementAt(j).itemName + "\n";
                    }
                }
                line += "\n";
            }
            return line;
        }
        public List<List<List<String>>> doRecomendationsClustering()
        {
            String line = "RECOMENDACIONES: \n";
            List<List<List<String>>> clustersRecomendations = new List<List<List<string>>>();
            foreach (Cluster actual in clustering.clusters)
            {
                List<List<String>> clusterRecomendations = new List<List<string>>();
                for (int i = 0; i < actual.itemsCluster.Count(); i++)
                {
                    List<String> clientRecomendation = new List<string>();
                    Client client = actual.itemsCluster[i];
                    clientRecomendation.Add(client.CardCode);
                    line += client.CardCode + ":\n";
                    for (int j = 0; j < actual.itemsCluster[i].items.Count(); j++)
                    {
                        if (actual.centroid[j] >= 1 && client.items[j] <= actual.centroid[j] / 2)
                        {
                            clientRecomendation.Add(listItems.ElementAt(j).itemName);
                            line += listItems.ElementAt(j).itemName + "\n";
                        }
                    }
                    clusterRecomendations.Add(clientRecomendation);
                    line += "\n";
                }
                clustersRecomendations.Add(clusterRecomendations);
            }
            return clustersRecomendations;
        }

        public List<List<string>> transacciones = new List<List<string>>();
        public void cargarTransacciones()
        {
            List<List<string>> trans = new List<List<string>>();
            var cons = listSales.GroupBy(x => x.docNum);
            //cons.ToList().ForEach(x=>Console.WriteLine(x.Key));

            foreach (var s in cons)
            {
                List<string> temp = new List<string>();
                foreach (var r in s)
                {
                    try
                    {
                        temp.Add(r.itemCode);

                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(r.itemCode);
                    }

                }
                //Console.WriteLine(s.Key);
                //Console.WriteLine(temp.ToString());
                trans.Add(temp);
            }
            transacciones = trans;

        }
        public List<Item> getItems()
        {
            return listItems;
        }

        public List<Sale> getSales()
        {
            return listSales;
        }

        public List<Client> getClients()
        {
            return listClients;
        }

        public List<List<Item>> getTransactions()
        {
            return listTransactions;
        }

        public void setTransactions(List<List<Item>> newTransactions)
        {
            listTransactions = newTransactions;
        }

        public void loadData()
        {
           var dataClients = File.ReadLines("...\\...\\Clientes.csv");
            var dataItems = File.ReadLines("...\\...\\Articulos.csv");
            var dataSales = File.ReadLines("...\\...\\Ventas.csv");

            foreach (var s in dataSales)
            {
                String[] data = s.Split(';');
                if (!s.Equals("") && data[4] != "NULL" && data[4] != "ItemCode")
                {
                    Sale newSale = new Sale();
                    newSale.cardCode = data[0];
                    newSale.docNum = (data[1]);
                    newSale.docDate = data[2];
                    newSale.docTotal = Convert.ToDouble(data[3]);
                    newSale.itemCode = data[4];
                    newSale.amount = Convert.ToInt32(data[5]);
                    newSale.price = Convert.ToDouble(data[6]);
                    newSale.totalLine = Convert.ToDouble(data[7]);
                    listSales.Add(newSale);

                }
            }
            foreach (var s in dataItems)
            {
                String[] datos = s.Split(';');
                if (datos.Length > 1)
                {
                    if (datos[1] != "********" && datos[1] != "ItemName")
                    {
                        Item newItem = new Item();
                        newItem.itemCode = Convert.ToInt32(datos[0]);
                        newItem.itemName = datos[1];
                        listItems.Add(newItem);
                    }
                }
                else
                {
                    break;
                }
            }
            foreach (var s in dataClients)
            {
                String[] datos = s.Split(';');
                if (s.Equals(""))
                {
                    break;
                }
                if (!s.Equals("") && datos[2] != "NULL" && datos[3] != "NULL" && datos[1] != "GroupName")
                {
                    Client newClient = new Client();
                    newClient.CardCode = datos[0].Trim();
                    newClient.GroupName = datos[1].Trim();
                    newClient.City = datos[2].Trim();
                    newClient.Dpto = datos[3].Trim();
                    newClient.PymntGruoup = datos[4].Trim();
                    newClient.items = new double[listItems.Count()];
                    listClients.Add(newClient);
                }
            }
			cargarTransacciones();
            //calculatePursaches();
            //Console.WriteLine(articulos.Count());
            //Console.WriteLine(ventas.Count());
			/*
            for (int i = 0; i < listItems.Count(); i++)
            {
                foreach (Sale sale in listSales)
                {
                    if (sale.itemCode.Equals(listItems[i].itemCode + ""))
                    {
                        try
                        {
                            listClients.First(k => k.CardCode.Equals(sale.cardCode)).items[i] += 1;
                            Console.WriteLine("holi");
                        }
                        catch { }
                    }
                }
            }
            int h = 0;
			*/
        }
        public void cleanData(double topTH, double botTH, int botTHSales)
        {

            List<Item> cleanList = new List<Item>();
            double count = listSales.Count();
            Hashtable set = new Hashtable();
            for (int i = 0; i < listSales.Count(); i++)
            {
                if (!set.ContainsKey(listSales[i].itemCode) && listSales[i].amount > botTHSales)
                {
                    set.Add(listSales[i].itemCode, 1);
                }
                else
                {
                    set[listSales[i].itemCode] = Convert.ToInt32(set[listSales[i].itemCode]) + 1;
                }
            }
            foreach (DictionaryEntry elemento in set)
            {
                Console.WriteLine(elemento.Value);
                Console.WriteLine(Convert.ToInt32(elemento.Value) / count);
                if (((Convert.ToInt32(elemento.Value) / count) >= topTH) || ((Convert.ToInt32(elemento.Value) / count) <= botTH))
                {
                    try
                    {
                        cleanList.Add(listItems.First(a => a.itemCode == Convert.ToInt32(elemento.Key)));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(elemento.Key);
                    }
                }
            }

            Console.WriteLine(cleanList.Count());

        }



    public void loadTransactions()
        {
            List<List<Item>> trans = new List<List<Item>>();
            var cons = listSales.GroupBy(x => x.docNum);
            foreach (var s in cons)
            {
                List<Item> temp = new List<Item>();
                foreach (var r in s)
                {
                    try
                    {
                        temp.Add(listItems.First(x => x.itemCode.Equals(Convert.ToInt32(r.itemCode))));
                    }
                    catch (Exception e)
                    {

                    }

                }
                trans.Add(temp);
            }
            listTransactions = trans;
        }

        public void calculatePursaches()
        {
            foreach (Client actual in listClients)
            {
                double pursaches = 0;
                var sales = listSales.Where(i => i.cardCode.Equals(actual.CardCode));
                foreach (Sale venta in sales)
                {
                    pursaches += venta.totalLine;
                }
                actual.Purchases = pursaches;
            }
        }

        /*
        public String runClusterApriori(int supp, int trust, int clust, int clustersNumber, int botTHSales)
        {
            String line = "";

            Console.WriteLine("Calculando");
            runClustering(clustersNumber, botTHSales);
            cargarTransaccionesClust(clust);
            List<List<string>> op = APriori.ItemsFrecuentes(transaccionesClust, supp);

            Console.WriteLine("Calculando reglas");
            List<ReglaAsociacion> reglas = APriori.ReglasAsociacion(transaccionesClust, op, trust);

            line = APriori.rules(reglas);
            Console.WriteLine(line);


            return line;
        }

        public void cargarTransaccionesClust(int cluster)
        {
            List<List<string>> transClust = new List<List<string>>();
            var cons = listSales.GroupBy(x => x.docNum);
            //cons.ToList().ForEach(x=>Console.WriteLine(x.Key));
            foreach (var z in clusters[cluster].itemsCluster)
            {
                foreach (var s in cons)
                {
                    List<string> temp = new List<string>();
                    foreach (var r in s)
                    {
                        try
                        {
                            if (r.cardCode.Equals(z.CardCode))
                            {
                                temp.Add(r.itemCode);
                            }
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(r.itemCode);
                        }

                    }
                    //Console.WriteLine(s.Key);
                    //Console.WriteLine(temp.ToSt ring());
                    transClust.Add(temp);
                }
            }

            transaccionesClust = transClust;

        }
        */
    }
}
