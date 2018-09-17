using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    public class FuercitaBruta
    {
        
        public List<Articulo> articulos = new List<Articulo>();
        public List<Venta> ventas = new List<Venta>();
        
        public List<Articulo> darArticulos()
        {
            return articulos;
        }

        public List<Venta> darVentas()
        {
            return ventas;
        }

        public void cargarDatos()
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

        public void pruebaCombinaciones()
        {
            Articulo articulo1 = new Articulo();
            articulo1.itemCode = 1;
            articulo1.itemName = "A";

            Articulo articulo2 = new Articulo();
            articulo2.itemCode = 2;
            articulo2.itemName = "B";

            Articulo articulo3 = new Articulo();
            articulo3.itemCode = 3;
            articulo3.itemName = "C";

            Articulo articulo4 = new Articulo();
            articulo4.itemCode = 4;
            articulo4.itemName = "D";

            List<Articulo> articulosPrueba = new List<Articulo>();

            articulosPrueba.Add(articulo1);
            articulosPrueba.Add(articulo2);
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);

            var misArt = Combinations(articulosPrueba, 2);
            Console.WriteLine("Olee");

        }

        public void hacerCombinaciones()
        {
            Combinations(articulos, 9).AsParallel().ToList().ForEach(i =>
            {
                Console.Write("{");
                i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.WriteLine("}");
            });
        }

        public IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int setLenght)
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
        /*
        public List<Articulo> darArticulos()
        {
            return articulos;
        }

        public List<Venta> darVentas()
        {
            return ventas;
        }
        */
    }
}
