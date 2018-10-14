using Allers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Clustering
    {
        public static Hashtable datosClientes = new Hashtable();
        public List<Cliente> clientes = new List<Cliente>();
        public Cluster[] clusters;
		public double[] DatosGroupNames = new double[2];
		public double[] DatosCities = new double[2];
		public double[] DatosDptos = new double[2];
		public double[] DatosPymnts = new double[2];
		public Clustering(List<Cliente> clientes, int numberOfClusters)
		{
			

			var groupNames = clientes.Select(i => i.GroupName).Distinct().ToList();
			double suma1 = 0.0;
			for (int i = 0; i < groupNames.Count; i++)
			{
				if (!datosClientes.ContainsKey(groupNames[i]))
				{
					datosClientes.Add(groupNames[i], i);
					suma1 += i;
				}

			}
			DatosGroupNames[0] = suma1 / groupNames.Count;

			var cities = clientes.Select(i => i.City).Distinct().ToList();
			double suma2 = 0;
			for (int i = 0; i < cities.Count(); i++)
			{
				if (!datosClientes.ContainsKey(cities[i]))
				{
					datosClientes.Add(cities[i], i);
					suma2 += i;
				}
			}
			DatosCities[0] = suma2 / cities.Count;

			var dptos = clientes.Select(i => i.Dpto).Distinct().ToList();
			double suma3 = 0;
			for (int i = 0; i < dptos.Count(); i++)
			{
				if (!datosClientes.ContainsKey(dptos[i]))
				{
					datosClientes.Add(dptos[i], i);
					suma3 += i;
				}
			}
			DatosDptos[0] = suma3 / dptos.Count;

			var pymnts = clientes.Select(i => i.PymntGruoup).Distinct().ToList();
			double suma4 = 0;
			for (int i = 0; i < dptos.Count(); i++)
			{
				if (!datosClientes.ContainsKey(pymnts[i]))
				{
					datosClientes.Add(pymnts[i], i);
					suma4 += i;
				}
			}
			DatosPymnts[0] = suma4 / pymnts.Count;
            CalcularDesviaciones();

            clusters = new Cluster[numberOfClusters];
            for (int i = 0; i < numberOfClusters; i++)
            {
                Random r = new Random();
                Cliente centroid = clientes.ElementAt(r.Next(0, clientes.Count() - 1));
                clusters[i] = new Cluster(Normalizar(centroid), centroid);
            }
            findClusters();
        }

		public double[] Normalizar(Cliente actual) {

			double[] datos = new double[4];
            datos[0] = (Convert.ToDouble(datosClientes[actual.GroupName]) - DatosGroupNames[0])/DatosGroupNames[1];
			datos[1] = (Convert.ToDouble(datosClientes[actual.City]) - DatosCities[0]) / DatosCities[1];
			datos[2] = (Convert.ToDouble(datosClientes[actual.Dpto]) - DatosDptos[0]) / DatosDptos[1];
			datos[3] = (Convert.ToDouble(datosClientes[actual.PymntGruoup]) - DatosPymnts[0]) / DatosPymnts[1];


			return datos;
		}
		public void CalcularDesviaciones() {
			var groupNames = clientes.Select(i => i.GroupName).Distinct().ToList();
			double suma1 = 0;
			var cities = clientes.Select(i => i.City).Distinct().ToList();
			double suma2 = 0;
			var dptos = clientes.Select(i => i.Dpto).Distinct().ToList();
			double suma3 = 0;
			var pymnts = clientes.Select(i => i.PymntGruoup).Distinct().ToList();
			double suma4 = 0;
			foreach (var s in groupNames) {
				suma1 += Math.Pow(((double)datosClientes[s])-DatosGroupNames[0],2);
			}
			DatosGroupNames[1] = Math.Sqrt(suma1 / groupNames.Count);

			foreach (var s in cities)
			{
				suma2 += Math.Pow(((double)datosClientes[s]) - DatosCities[0], 2);
			}
			DatosCities[1] = Math.Sqrt(suma2 / cities.Count);
			foreach (var s in dptos)
			{
				suma3 += Math.Pow(((double)datosClientes[s]) - DatosDptos[0], 2);
			}
			DatosDptos[1] = Math.Sqrt(suma3 / dptos.Count);
			foreach (var s in pymnts)
			{
				suma4 += Math.Pow(((double)datosClientes[s]) - DatosPymnts[0], 2);
			}
			DatosPymnts[1] = Math.Sqrt(suma4 / pymnts.Count);
		}
        public void ReCalculateCentroid(Cluster cluster)
        {
            double[] datos = new double[4];
            IEnumerable<double[]> sums = cluster.elementos.Select(i => Normalizar(i));
            datos[0] = sums.Average(j => j[0]);
            datos[1] = sums.Average(j => j[1]);
            datos[2] = sums.Average(j => j[2]);
            datos[3] = sums.Average(j => j[3]);
            cluster.centroid = datos; 
        }
        public double[] distances(Cliente cliente)
        {
            double[] posiciónCliente = Normalizar(cliente);
            double[] distances = new double[clusters.Count()];
            for(int i = 0; i < clusters.Count(); i++)
            {
                Cluster cluster = clusters[i];
                double sum = Math.Pow(cluster.centroid[0] - posiciónCliente[0], 2) +
                                Math.Pow(cluster.centroid[1] - posiciónCliente[1], 2) +
                                Math.Pow(cluster.centroid[2] - posiciónCliente[2], 2) +
                                Math.Pow(cluster.centroid[3] - posiciónCliente[3], 2);
                double distance = Math.Sqrt(sum);
                distances[i] = distance;
            }
            return distances;
        }
        public void findClusters()
        {
            bool changes = false;
            do
            {
                foreach (Cliente actual in clientes)
                {
                    bool asigned = false;
                    double[] d = distances(actual);
                    double minimum = d.Min();
                    for(int i = 0; i < d.Count() && !asigned; i++)
                    {
                        if (d[i] == minimum)
                        {
                            foreach(Cluster cluster in clusters)
                            {
                                cluster.elementos.Remove(actual);
                            }
                            clusters[i].elementos.Add(actual);
                            ReCalculateCentroid(clusters[i]);
                            changes = true;
                            asigned = true;
                        }
                    }
                }
            }
            while (changes);
            
        }
    }

