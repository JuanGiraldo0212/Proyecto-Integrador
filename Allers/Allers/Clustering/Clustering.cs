using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers.Clustering
{
    class Clustering
    {
        public Hashtable datosClientes = new Hashtable();
        public List<Cliente> clientes = new List<Cliente>();
        public Cluster[] clusters;
        public Clustering(List<Cliente> clientes, int numberOfClusters)
        {
            clusters = new Cluster[numberOfClusters];
            for(int i = 0; 0 < numberOfClusters; i++)
            {
                Random r = new Random();
                clusters[i] = new Cluster(clientes.ElementAt(r.Next(0, clientes.Count() - 1)));
            }
        }
    }
}
