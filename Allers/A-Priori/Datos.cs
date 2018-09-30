using Allers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Priori
{
	class Datos
	{
		public  List<Articulo> articulos = new List<Articulo>();
		public  List<Venta> ventas = new List<Venta>();
		public  ListaItemSet transacciones = new ListaItemSet();
		public List<Cliente> clientes = new List<Cliente>();

		public void CargarDatos()
		{

			var datosClientes = File.ReadLines("...\\...\\Clientes.csv");
			var datosArticulos = File.ReadLines("...\\...\\Articulos.csv");
			var datosVentas = File.ReadLines("...\\...\\Ventas.csv");



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

			foreach (var s in datosClientes)
			{
				String[] datos = s.Split(';');
				if (datos.Length > 1)
				{
					if (datos[2] != "1" && datos[3] != "NULL")
					{

						Cliente nuevo = new Cliente();
						nuevo.CardCode = datos[0];
						nuevo.GroupName = datos[1];
						nuevo.Ciudad = datos[2];
						nuevo.Dpto = datos[3];
						clientes.Add(nuevo);

					}
				}
				else
				{
					break;
				}
			}

		}

		public void FirstCleanUp() {



		}

	}
}
