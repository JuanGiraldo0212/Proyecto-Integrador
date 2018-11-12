using Allers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Clustering
{

    public List<Client> clients = new List<Client>();
    public Cluster[] clusters;
    public Clustering(List<Client> clientsMain, int numberOfClusters, int clusteringMethod)
    {
        clients = clientsMain;
        if (clusteringMethod == 0)
        {
            do_K_means(numberOfClusters);
        }
        if (clusteringMethod == 1)
        {
            do_Bisecting_K_means(numberOfClusters);
        }
    }
    public void do_Bisecting_K_means(int numberOfClusters)
    {
        List<Cluster> tempClusters = new List<Cluster>();
        if (numberOfClusters > 2)
        {
            while (tempClusters.Count() != numberOfClusters)
            {

                do_K_means(2);
                if (tempClusters.Count() + clusters.Count() == numberOfClusters)
                {
                    tempClusters.Add(clusters[0]);
                    tempClusters.Add(clusters[1]);
                }
                else
                {
                    var temp = clusters.OrderByDescending(m => m.itemsCluster.Count());
                    tempClusters.Add(temp.Last());
                    clients = temp.First().itemsCluster;
                }
            }
            clusters = tempClusters.ToArray();
        }
        else
        {
            do_K_means(2);
        }
    }
    public void do_K_means(int numberOfClusters)
    {
        clusters = new Cluster[numberOfClusters];
        for (int i = 0; i < numberOfClusters; i++)
        {
            Random r = new Random();
            //Console.Write(clients.Count() - 1);
            Client centroid = clients.ElementAt(r.Next(0, clients.Count() - 1));
            clusters[i] = new Cluster(centroid.items, centroid);
        }
        findClusters();
    }
    public void ReCalculateCentroids()
    {
        foreach (Cluster cluster in clusters)
        {
            if (cluster.itemsCluster.Count() != 0)
            {
                double[] datos = new double[cluster.centroid.Count()];
                for (int j = 0; j < cluster.centroid.Count(); j++)
                {
                    datos[j] = cluster.itemsCluster.Average(h => h.items[j]);
                }
                cluster.centroid = datos;
            }
            else
            {


            }
        }

    }
    public double[] distances(Client cliente)
    {
        double[] distances = new double[clusters.Count()];
        for (int i = 0; i < clusters.Count(); i++)
        {
            Cluster cluster = clusters[i];
            double sum = 0;
            for (int j = 0; j < cluster.centroid.Length; j++)
            {
                sum += Math.Pow(cluster.centroid[j] - cliente.items[j], 2);
            }
            double distance = Math.Sqrt(sum);
            distances[i] = distance;
        }
        return distances;
    }
    public void findClusters()
    {
        bool changes = true;
        while (changes)
        {
            changes = false;
            foreach (Client actual in clients)
            {

                bool asigned = false;
                double[] d = distances(actual);
                double minimum = d.Min();
                for (int i = 0; i < d.Count() && !asigned; i++)
                {
                    if (d[i] == minimum && d.Where(l => l == 0).Count() != d.Count())
                    {
                        foreach (Cluster cluster in clusters)
                        {
                            if (clusters[i] != cluster)
                                cluster.itemsCluster.Remove(actual);
                        }
                        if (!clusters[i].itemsCluster.Contains(actual))
                        {
                            clusters[i].itemsCluster.Add(actual);
                            changes = true;
                            asigned = true;
                            ReCalculateCentroids();
                        }
                    }
                }
            }
            //Console.WriteLine("Hole");

        }


    }
}
