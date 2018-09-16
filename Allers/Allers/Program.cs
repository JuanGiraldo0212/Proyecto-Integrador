using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Allers
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            cargarDatos();
            Combinations(articulos, 9).AsParallel().ToList().ForEach(i =>
            {
                Console.Write("{");
                i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.WriteLine("}");
            });
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        static List<Articulo> articulos = new List<Articulo>();
        static List<Venta> ventas = new List<Venta>();

        public static void cargarDatos()
        {


            //var datosClientes = File.ReadLines("...\\...\\Clientes.csv");
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

            Console.WriteLine(articulos.Count());
            Console.WriteLine(ventas.Count());
        }
        public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int setLenght)
        {
            int elementLenght = elements.Count();
            if (setLenght == 1)
            {
                Console.Write("Holi");
                return elements.Select(e => Enumerable.Repeat(e, 1));
            }
            else if (setLenght == elementLenght)
            {
                Console.Write("Holi");
                return Enumerable.Repeat(elements, 1);
            }
            else
            {
                Console.Write("Holi");
                return Combinations(elements.Skip(1), setLenght - 1)
                                .Select(tail => Enumerable.Repeat(elements.First(), 1).Union(tail))
                                .Union(Combinations(elements.Skip(1), setLenght));
            }
        }
        public static List<List<Articulo>> ConjuntoPotencia(List<Articulo> conjunto)
        {
            List<List<Articulo>> conjuntoPotencia = new List<List<Articulo>>();
            if (conjunto.Count() == 2)
            {
                conjuntoPotencia.Add(new List<Articulo>());
                List<Articulo> conjunto1 = new List<Articulo>()
                {
                    conjunto[0]
                };
                List<Articulo> conjunto2 = new List<Articulo>()
                {
                    conjunto[1]
                };
                List<Articulo> conjunto3 = new List<Articulo>()
                {
                    conjunto[0],conjunto[1],
                };
                conjuntoPotencia.Add(conjunto1);
                conjuntoPotencia.Add(conjunto2);
                conjuntoPotencia.Add(conjunto3);
            }
            else
            {
                List<Articulo> aux = new List<Articulo>();
                for (int i = 0; i < conjunto.Count() - 1; i++)
                {
                    aux.Add(conjunto[i]);
                }
                Articulo last = conjunto.Last();
                conjuntoPotencia = ConjuntoPotencia(aux);

                List<List<Articulo>> aux1 = new List<List<Articulo>>();

                for (int i = 0; i < conjuntoPotencia.Count(); i++)
                {
                    List<Articulo> aux2 = new List<Articulo>();
                    if (conjuntoPotencia[i].Count() == 0)
                    {
                        aux2.Add(last);
                    }
                    for (int j = 0; j < conjuntoPotencia[i].Count(); j++)
                    {
                        Articulo actual = new Articulo();
                        string code = Convert.ToString(conjuntoPotencia[i][j].itemCode).Clone()+"";
                        actual.itemCode = Convert.ToInt32(code);
                        actual.itemName = conjuntoPotencia[i][j].itemName.Clone()+"";
                        aux2.Add(actual);
                        aux2.Add(last);
                    }
                    aux1.Add(aux2.Distinct().ToList());
                }
                foreach (List<Articulo> lista in aux1)
                {
                    conjuntoPotencia.Add(lista);
                }
            }
            return conjuntoPotencia;
        }
    }
}
