using Allers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Priori
{
	class Program
	{
		public static List<Articulo> articulos = new List<Articulo>();
		public static List<Venta> ventas = new List<Venta>();
		public static ListaItemSet transacciones = new ListaItemSet();

		static void Main(string[] args)
		{
			Console.WriteLine("K");
			cargarDatos();

			cargarTransacciones();
			
			#region Test
			/*
			articulos.Add(new Articulo {itemName= "bread",itemCode=1 });
			articulos.Add(new Articulo { itemName = "milk", itemCode = 2 });
			articulos.Add(new Articulo { itemName = "beer", itemCode = 3 });
			articulos.Add(new Articulo { itemName = "umbrella", itemCode = 4 });
			articulos.Add(new Articulo { itemName = "diaper", itemCode = 5 });
			articulos.Add(new Articulo { itemName = "water", itemCode = 6 });
			articulos.Add(new Articulo { itemName = "detergent", itemCode = 7 });
			articulos.Add(new Articulo { itemName = "cheese", itemCode = 8 });
			transacciones.Add(new Itemset {articulos[7],articulos[4],articulos[5],articulos[0],articulos[3] });
			transacciones.Add(new Itemset { articulos[4], articulos[5] });
			transacciones.Add(new Itemset { articulos[7], articulos[4], articulos[1] });
			transacciones.Add(new Itemset { articulos[4], articulos[7], articulos[6] });
			transacciones.Add(new Itemset { articulos[7], articulos[1], articulos[2] });
			*/
			#endregion
			ListaItemSet lista =APriori.DoApriori(transacciones,10);
			Console.WriteLine(lista.ToString());
			List<ReglaAsociacion> reglas=  APriori.Mine(transacciones,lista,50);
			Console.WriteLine(reglas.Count());
			reglas.ToList().ForEach(x => Console.WriteLine(x.ToString()));

		}



		#region CargaDatos
		public static void cargarDatos()
		{

			//var datosClientes = File.ReadLines("...\\...\\Clientes.csv");
			var datosArticulos = File.ReadLines("...\\...\\Articulos2.csv");
			var datosVentas = File.ReadLines("...\\...\\Ventas2.csv");
		


			foreach (var s in datosVentas)
			{
				String[] datos = s.Split(';');
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
			ListaItemSet trans = new ListaItemSet();
			var cons = ventas.GroupBy(x => x.docNum);
			//cons.ToList().ForEach(x=>Console.WriteLine(x.Key));
			
			foreach (var s in cons)
			{
				Itemset temp = new Itemset();
				foreach (var r in s)
				{
					try
					{
						temp.Add(articulos.First(x => x.itemCode==Convert.ToInt32(r.itemCode)));
						
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
