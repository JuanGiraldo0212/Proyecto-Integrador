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
        public static Hashtable datosClientesInv = new Hashtable();
        public List<Cliente> clientes = new List<Cliente>();
        public Cluster[] clusters;
		public double[] DatosGroupNames = new double[2];
		public double[] DatosCities = new double[2];
		public double[] DatosDptos = new double[2];
		public double[] DatosPymnts = new double[2];
        public double[] DatosPursaches = new double[2];
		public Clustering(List<Cliente> clientess, int numberOfClusters)
		{
		    clientes = clientess;
            int contador = 1;
			var groupNames = clientes.Select(i => i.GroupName).Distinct().ToList();
			for (int i = 0; i < groupNames.Count; i++)
			{
				if (!datosClientes.ContainsKey(groupNames[i]) && !datosClientesInv.ContainsKey(contador))
				{
					datosClientes.Add(groupNames[i], contador);
                    datosClientesInv.Add(contador, groupNames[i]);
                    contador++;
                }

			}

			var cities = clientes.Select(i => i.City).Distinct().ToList();
			for (int i = 0; i < cities.Count(); i++)
			{
				if (!datosClientes.ContainsKey(cities[i]) && !datosClientesInv.ContainsKey(contador))
				{
					datosClientes.Add(cities[i], contador);
                    datosClientesInv.Add(contador, cities[i]);
                    contador++;
                }
			}

			var dptos = clientes.Select(i => i.Dpto).Distinct().ToList();
			for (int i = 0; i < dptos.Count(); i++)
			{
				if (!datosClientes.ContainsKey(dptos[i]) && !datosClientesInv.ContainsKey(contador))
				{
					datosClientes.Add(dptos[i], contador);
                    datosClientesInv.Add(contador, dptos[i]);
                    contador++;
                }
			}

			var pymnts = clientes.Select(i => i.PymntGruoup).Distinct().ToList();
			for (int i = 0; i < dptos.Count(); i++)
			{
				if (!datosClientes.ContainsKey(pymnts[i]) && !datosClientesInv.ContainsKey(contador))
				{
					datosClientes.Add(pymnts[i], contador);
                    datosClientesInv.Add(contador, pymnts[i]);
                    contador++;
                }
			}
        //Console.WriteLine(DatosGroupNames[0]);
        //Console.WriteLine(DatosDptos[0]);
        //Console.WriteLine(DatosCities[0]);
        //Console.WriteLine(DatosPymnts[0]);
        CalcularDesviaciones();
        CalculateMeans();
            clusters = new Cluster[numberOfClusters];
            for (int i = 0; i < numberOfClusters; i++)
            {
                Random r = new Random();
                Cliente centroid = clientes.ElementAt(r.Next(0, clientes.Count() - 1));
                clusters[i] = new Cluster(Normalizar(centroid), centroid);
            }
            findClusters();
        }

        public static string hashInv(double value)
        {
        string key = "hehe";
        int value1 = (int)value;
        foreach(string actual in datosClientes.Keys)
        {
            if(Convert.ToInt32(datosClientes[actual]) == value1)
            {
                key = actual;
            }
        }
        return key;
        }
		public double[] Normalizar(Cliente actual) {

			double[] datos = new double[5];
            datos[0] = (Convert.ToDouble(datosClientes[actual.GroupName]) - DatosGroupNames[0])/DatosGroupNames[1];
			datos[1] = (Convert.ToDouble(datosClientes[actual.City]) - DatosCities[0]) / DatosCities[1];
			datos[2] = (Convert.ToDouble(datosClientes[actual.Dpto]) - DatosDptos[0]) / DatosDptos[1];
			datos[3] = (Convert.ToDouble(datosClientes[actual.PymntGruoup]) - DatosPymnts[0]) / DatosPymnts[1];
            datos[4] =  (actual.Purchases - DatosPursaches[0]) / DatosPursaches[1];


        return datos;
		}
    public void CalculateMeans()
    {
        DatosGroupNames[0] = clientes.Average(i => Convert.ToDouble(datosClientes[i.GroupName]));
        DatosCities[0] = clientes.Average(i => Convert.ToDouble(datosClientes[i.City]));
        DatosDptos[0] = clientes.Average(i => Convert.ToDouble(datosClientes[i.Dpto]));
        DatosPymnts[0] = clientes.Average(i => Convert.ToDouble(datosClientes[i.PymntGruoup]));
        DatosPursaches[0] = clientes.Average(i => i.Purchases);
    }
    public void CalcularDesviaciones() {
			var groupNames = clientes.Select(i => i.GroupName).ToList();
			double suma1 = 0;
			var cities = clientes.Select(i => i.City).ToList();
			double suma2 = 0;
			var dptos = clientes.Select(i => i.Dpto).ToList();
			double suma3 = 0;
			var pymnts = clientes.Select(i => i.PymntGruoup).ToList();
			double suma4 = 0;
        var prs = clientes.Select(i => i.Purchases).ToList();
        double suma5 = 0;
        foreach (var s in groupNames) {
				suma1 += Math.Pow(Convert.ToDouble(datosClientes[s])-DatosGroupNames[0],2);
			}
			DatosGroupNames[1] = Math.Sqrt(suma1 / groupNames.Count);

			foreach (var s in cities)
			{
				suma2 += Math.Pow(Convert.ToDouble(datosClientes[s]) - DatosCities[0], 2);
			}
			DatosCities[1] = Math.Sqrt(suma2 / cities.Count);
			foreach (var s in dptos)
			{
				suma3 += Math.Pow(Convert.ToDouble(datosClientes[s]) - DatosDptos[0], 2);
			}
			DatosDptos[1] = Math.Sqrt(suma3 / dptos.Count);
			foreach (var s in pymnts)
			{
				suma4 += Math.Pow(Convert.ToDouble(datosClientes[s]) - DatosPymnts[0], 2);
			}
			DatosPymnts[1] = Math.Sqrt(suma4 / pymnts.Count);
        foreach (var s in prs)
        {
            suma5 += Math.Pow(s - DatosPymnts[0], 2);
        }
        DatosPursaches[1] = Math.Sqrt(suma5 / pymnts.Count);
    }
        public void ReCalculateCentroids()
        {
            foreach(Cluster cluster in clusters)
            {
            if (cluster.elementos.Count() != 0)
            {
                double[] datos = new double[5];
                IEnumerable<double[]> sums = cluster.elementos.Select(i => Normalizar(i));
                datos[0] = sums.Average(j => j[0]);
                datos[1] = sums.Average(j => j[1]);
                datos[2] = sums.Average(j => j[2]);
                datos[3] = sums.Average(j => j[3]);
                datos[4] = sums.Average(j => j[4]);
                cluster.centroid = datos;
            }
            else
            {
                List<double> centroid = new List<double> { 0, 0, 0, 0,0 };
                cluster.centroid = centroid.ToArray();

            }
            }
            
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
                                //Math.Pow(cluster.centroid[4] - posiciónCliente[4], 2);
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
                                if(clusters[i] != cluster)
                                cluster.elementos.Remove(actual);
                            }
                            if(!clusters[i].elementos.Contains(actual))
                            {
                                clusters[i].elementos.Add(actual);
                                changes = true;
                                asigned = true;
                                ReCalculateCentroids();
                            }
                        }
                    }
                }
            Console.WriteLine("Hole");
            
            }
            
            
        }
    }

