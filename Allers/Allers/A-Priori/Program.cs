using Allers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A_Priori
{
	class Program
	{
		public static List<Articulo> articulos = new List<Articulo>();
		public static List<Venta> ventas = new List<Venta>();
		public static List<List<string>> transacciones = new List<List<string>>();

		static void Main(string[] args)
		{

			cargarDatos();

			cargarTransacciones();
			//transacciones.ForEach(x=>Console.WriteLine(x.ToString()));
			//escoger nucleo del pc
			Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
			//dar prioridad alta al nucleo

			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
			Thread.CurrentThread.Priority = ThreadPriority.Highest;


			#region Test
			/*
			List<List<string>> art = new List<List<string>>();

			art.Add(new Itemset { "bread" });
			art.Add(new Itemset { "milk" });
			art.Add(new Itemset { "beer" });
			art.Add(new Itemset { "umbrella" });
			art.Add(new Itemset { "diaper" });
			art.Add(new Itemset { "water" });
			art.Add(new Itemset { "detergent" });
			art.Add(new Itemset { "cheese" });
			articulos.Add(new Articulo {itemName= "bread",itemCode=1 });
			articulos.Add(new Articulo { itemName = "milk", itemCode = 2 });
			articulos.Add(new Articulo { itemName = "beer", itemCode = 3 });
			articulos.Add(new Articulo { itemName = "umbrella", itemCode = 4 });
			articulos.Add(new Articulo { itemName = "diaper", itemCode = 5 });
			articulos.Add(new Articulo { itemName = "water", itemCode = 6 });
			articulos.Add(new Articulo { itemName = "detergent", itemCode = 7 });
			articulos.Add(new Articulo { itemName = "cheese", itemCode = 8 });
			transacciones.Add(new List<String> {articulos[7].itemName,articulos[4].itemName, articulos[5].itemName, articulos[0].itemName, articulos[3].itemName });
			transacciones.Add(new List<String> { articulos[4].itemName, articulos[5].itemName });
			transacciones.Add(new List<String> { articulos[7].itemName, articulos[4].itemName, articulos[1].itemName });
			transacciones.Add(new List<String> { articulos[4].itemName ,articulos[7].itemName, articulos[6].itemName });
			transacciones.Add(new List<String> { articulos[7].itemName, articulos[1].itemName, articulos[2].itemName });
			/*
			List<List<string>> comb = APriori.Combinaciones(APriori.ItemSetsUnicos(transacciones));
			List<List<string>> pass = new List<List<string>>();
			foreach (var s in comb) {
				double supp=APriori.FindSupport(s,transacciones);
				if (supp>=40) {
					pass.Add(s);
				}

			}
			Console.WriteLine(APriori.PrintL(pass));
			List<List<string>> comb2 = APriori.Combinaciones(APriori.ItemSetsUnicos(transacciones));
			*/
			//Console.WriteLine(APriori.PrintL(APriori.ItemSetsUnicos(transacciones)));
			//Console.WriteLine(APriori.FindSupport(new List<string> {"beer","milk"},transacciones));
			/*
			List<List<string>> unique = APriori.ItemSetsUnicos(transacciones);
			Console.WriteLine(APriori.PrintL(unique));
			foreach (var s in unique) {
				double supp = APriori.FindSupport(s,transacciones);
				Console.WriteLine(supp);
			}
			*/
			
			
			List<List<string>> op = APriori.ItemsFrecuentes(transacciones,2);
			Console.WriteLine(APriori.PrintL(op));
			List<ReglaAsociacion> reglas = APriori.ReglasAsociacion(transacciones,op,50);
			Console.WriteLine(reglas.Count);
			reglas.ForEach(x=>Console.WriteLine(x.ToString()));
			/*
			String imp = "";
			foreach (var s in op) {
				imp += "{";
				foreach (var p in s) {
					imp += p + ",";
				}
				imp += "}\n";
			}
			Console.WriteLine(imp);
			*/
			#endregion
			/*
				 Stopwatch stopwatch = new Stopwatch();
				 stopwatch.Start();
				 ListaItemSet lista = APriori.FrequentItemSets(transacciones, -1);
				 Console.WriteLine("Frequent itemsets");
				 Console.WriteLine(lista.ToString());
				 List<ReglaAsociacion> reglas = APriori.ReglasAsociacion(transacciones, lista, -1);
				 Console.WriteLine("Reglas de asociacion");
				 Console.WriteLine(reglas.Count());
				 reglas.ToList().ForEach(x => Console.WriteLine(x.ToString()));
				 stopwatch.Stop();
				 Console.WriteLine(stopwatch.ElapsedMilliseconds);
				 */



		}

        public static long TestFunction(long seed, int count)
        {
            long result = seed;
            for (int i = 0; i < count; ++i)
            {
                result ^= i ^ seed; // Some useless bit operations
            }
            return result;
        }



        #region CargaDatos
        public static void cargarDatos()
		{

			//var datosClientes = File.ReadLines("...\\...\\Clientes.csv");
			var datosArticulos = File.ReadLines("...\\...\\Articulos.csv");
			var datosVentas = File.ReadLines("...\\...\\Ventas.csv");
		


			foreach (var s in datosVentas)
			{
				String[] datos = s.Split(';');
				if (datos.Length > 1)
				{
					if (datos[4] != "NULL" && datos[4] != "ItemCode")
					{

						Venta nueva = new Venta();
						nueva.cardCode = datos[0];
						nueva.docNum = (datos[1]);
						nueva.docDate = datos[2];
						nueva.docTotal = Convert.ToDouble(datos[3]);
						nueva.itemCode = datos[4];
						nueva.cantidad = Convert.ToInt32(datos[5]);
						nueva.precio = Convert.ToDouble(datos[6]);
						nueva.lineaTotal = Convert.ToDouble(datos[7]);
						ventas.Add(nueva);
					}
				}
				else {
					break;
				}
			}

			foreach (var s in datosArticulos)
			{
				String[] datos = s.Split(';');
				if (datos.Length > 1)
				{
					if (datos[1] != "********" && datos[1] != "ItemName")
					{

						Articulo nuevo = new Articulo();
						nuevo.itemCode = Convert.ToInt32(datos[0]);
						nuevo.itemName = datos[1];
						articulos.Add(nuevo);
						
					}
				}
				else
				{
					break;
				}
			}

		}
		public static void cargarTransacciones()
		{
			List<List<string>> trans = new List<List<string>>();
			var cons = ventas.GroupBy(x => x.docNum);
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
					catch (Exception e){
						//Console.WriteLine(r.itemCode);
					}

				}
				//Console.WriteLine(s.Key);
				//Console.WriteLine(temp.ToString());
				trans.Add(temp);
			}
			transacciones = trans;
			
		}

	#endregion

	}
}
