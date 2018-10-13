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
		public double[] DatosGroupNames = new double[2];
		public double[] DatosCities = new double[2];
		public double[] DatosDptos = new double[2];
		public double[] DatosPymnts = new double[2];
		public Clustering(List<Cliente> clientes, int numberOfClusters)
		{
			clusters = new Cluster[numberOfClusters];
			for (int i = 0; 0 < numberOfClusters; i++)
			{
				Random r = new Random();
				clusters[i] = new Cluster(clientes.ElementAt(r.Next(0, clientes.Count() - 1)));
			}

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
        }

		public double[] Normalizar(Cliente actual) {

			double[] datos = new double[4];
			datos[0] = ((double)datosClientes[actual.GroupName] - DatosGroupNames[0])/DatosGroupNames[1];
			datos[1] = ((double)datosClientes[actual.City] - DatosCities[0]) / DatosCities[1];
			datos[2] = ((double)datosClientes[actual.Dpto] - DatosDptos[0]) / DatosDptos[1];
			datos[3] = ((double)datosClientes[actual.PymntGruoup] - DatosPymnts[0]) / DatosPymnts[1];


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
    }
}
