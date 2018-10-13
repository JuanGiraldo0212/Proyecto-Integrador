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

            var groupNames = clientes.Select(i => i.GroupName).Distinct().ToList();
            for (int i = 0; i < groupNames.Count(); i++)
            {
                if (!datosClientes.ContainsKey(groupNames[i]))
                    datosClientes.Add(groupNames[i], i);
            }

            var cities = clientes.Select(i => i.City).Distinct().ToList();
            for (int i = 0; i < cities.Count(); i++)
            {
                if (!datosClientes.ContainsKey(cities[i]))
                    datosClientes.Add(cities[i], i);
            }

            var dptos = clientes.Select(i => i.Dpto).Distinct().ToList();
            for (int i = 0; i < dptos.Count(); i++)
            {
                if (!datosClientes.ContainsKey(dptos[i]))
                    datosClientes.Add(dptos[i], i);
            }

            var pymnts = clientes.Select(i => i.PymntGruoup).Distinct().ToList();
            for (int i = 0; i < dptos.Count(); i++)
            {
                if (!datosClientes.ContainsKey(pymnts[i]))
                    datosClientes.Add(pymnts[i], i);
            }
        }
    }
}
