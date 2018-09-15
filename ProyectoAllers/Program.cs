using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAllers
{
	static class Program
	{
		/// <summary>
		/// Punto de entrada principal para la aplicación.
		/// </summary>
		[STAThread]

		static void Main()
		{


			using (var ctx = new Contexto1())
			{
				cargarDatos(ctx);
			}

			
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			
			
		}
		
		public static void cargarDatos(Contexto1 ctx) {
		List<Cliente> clientes = new List<Cliente>();
		List<Articulo> articulos = new List<Articulo>();
		List<Venta> ventas = new List<Venta>();
		List<Pedido> pedidos = new List<Pedido>();
		var datosClientes = File.ReadLines("...\\...\\Clientes.csv");
			var datosArticulos = File.ReadLines("...\\...\\Articulos.csv");
			var datosVentas = File.ReadLines("...\\...\\Ventas.csv");
			var conjuntos = new List<String>();

			foreach (var s in datosClientes) { 
				String[] datos = s.Split(';');
				if (datos[2]!="NULL" && datos[3]!="NULL" && datos[3] != "Name") {
				Cliente nuevo = new Cliente();
				nuevo.CardCode = datos[0];
				nuevo.GroupName = datos[1];
				nuevo.City = datos[2];
				nuevo.Region = datos[3];
				nuevo.Pymnt = datos[4];
				clientes.Add(nuevo);
				}
				
			}

			foreach (var s in datosVentas) {
				String[] datos = s.Split(';');
				if (datos[4]!="NULL" && datos[4]!= "ItemCode") {
					if ((!conjuntos.Contains(datos[1]))) {
					Venta nueva = new Venta();
					nueva.ClienteCardCode = datos[0];
					nueva.DocNum = Convert.ToInt32(datos[1]);
					conjuntos.Add(datos[1]);
					nueva.DocDate = datos[2];
					nueva.DocTotal = Convert.ToDouble(datos[3]);
					ventas.Add(nueva);

					}
					Pedido nuevo = new Pedido();
					nuevo.ArticuloItemCode = Convert.ToInt32(datos[4]);
					nuevo.Cantidad = Convert.ToInt32(datos[5]);
					nuevo.Precio = Convert.ToDouble(datos[6]);
					nuevo.LineaTotal = Convert.ToDouble(datos[7]);
					nuevo.VentaDocNum1= Convert.ToInt32(datos[1]);
					nuevo.VentaClienteCardCode= datos[0];
					pedidos.Add(nuevo);
				}
			}

			foreach (var s in datosArticulos) {
				String[] datos = s.Split(';');
				if (datos[1]!= "********" && datos[1]!= "ItemName") {
					Articulo nuevo = new Articulo();
					nuevo.ItemCode = Convert.ToInt32(datos[0]);
					nuevo.ItemName = datos[1];
					articulos.Add(nuevo);
					
				}
			}
			
			//////////////////////////////////
			///Esto es para cargar al servidor,
			///Dejar comentado

			/*
			clientes.ForEach(c=>ctx.Clientes.Add(c));
			ctx.SaveChanges();
			Console.WriteLine("1");
			ventas.ForEach(v=>ctx.Ventas.Add(v));
			ctx.SaveChanges();
			pedidos.ForEach(p => ctx.Pedidos.Add(p));
			ctx.SaveChanges();
			articulos.ForEach(a=>ctx.Articulos.Add(a));
			ctx.SaveChanges();
			*/

		}
		
	}
}
