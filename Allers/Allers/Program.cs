using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
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
            FuercitaBruta principal = new FuercitaBruta();
            //principal.pruebaCombinaciones();
            principal.cargarDatos();
			principal.cleanData(0.0002, 1.33959370123042E-05);
            //principal.hacerCombinaciones();

            /*
            cargarDatos();
            Combinations(articulos, 9).AsParallel().ToList().ForEach(i =>
            {
                Console.Write("{");
                i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.WriteLine("}");
            });
            */
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
        static List<Articulo> articulos = new List<Articulo>();
        static List<Venta> ventas = new List<Venta>();
        static List<Rules> rules = new List<Rules>();

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

            //Console.WriteLine(articulos.Count());
            //Console.WriteLine(ventas.Count());
        }

        public static List<List<Articulo>> Combinations<Articulo>(List<Articulo> elements, int setLenght)
        {
            int elementLenght = elements.Count();
            if (setLenght == 1)
            {
                Console.Write("Holi");
                return elements.Select(e => Enumerable.Repeat(e, 1).ToList()).ToList();
            }
            else if (setLenght == elementLenght)
            {
                Console.Write("Holi");
                return Enumerable.Repeat(elements, 1).ToList();
            }
            else
            {
                Console.Write("Holi");
                return Combinations(elements.Skip(1).ToList(), setLenght - 1)
                                .Select(tail => Enumerable.Repeat(elements.First(), 1).Union(tail).ToList())
                                .Union(Combinations(elements.Skip(1).ToList(), setLenght).ToList()).ToList();
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

        static List<List<Articulo>> transactions = new List<List<Articulo>>();


        public static void cargarTransactions()
        {
            List<List<Articulo>> trans = new List<List<Articulo>>();
            var cons = ventas.GroupBy(x => x.cardCode);
            foreach (var s in cons)
            {
                List<Articulo> temp = new List<Articulo>();
                foreach (var r in s)
                {
                    temp.Add(articulos.First(x => x.itemCode.Equals(r.itemCode)));

                }
                trans.Add(temp);
            }
            transactions = trans;
        }

            public class transWithSupp
            {
            private List<Articulo> trans { get; set; }
            private double suppCount { get; set; }
            private double supp { get; set; }

            public transWithSupp(List<Articulo> trans, double suppCount, double supp)
            {
                this.trans = trans;
                this.suppCount = suppCount;
                this.supp = supp;
            }
            public double getSupp()
            {
                return suppCount;
            }

            public List<Articulo> getItemSet()
            {
                return trans;
            }

        }

        public class Rules
        {
            public List<Articulo> antecedente { get; set; }
            public List<Articulo> consecuente { get; set; } 
            private double suppCount { get; set; }

            private double confidenceCount {get; set;}

            public Rules(List<Articulo> antecedente, List<Articulo> consecuente,  double suppCount, double confidenceCount)
            {
                this.consecuente = consecuente;
                this.antecedente = antecedente;
                this.suppCount = suppCount;
                this.confidenceCount = confidenceCount;
            }
            public double getSupp()
            {
                return suppCount;
            }
            public double getConf()
            {
                return confidenceCount;
            }
        }
        public static List<transWithSupp> frequentItemSet(List<List<Articulo>> itemSets, double suppCountPar){
            
            List<transWithSupp> transwithSuppList = new List<transWithSupp>();
            foreach (var s in itemSets)
            {
                transwithSuppList.Add(new transWithSupp(s, calcSupport(s)/transactions.Count(), calcSupport(s)));

            }

            return transwithSuppList.Where(c=>c.getSupp()>=suppCountPar).ToList();
        }

        public static void generateRules<T>(List<transWithSupp> frequentItemSet)
        {

            foreach(var s in frequentItemSet)
            {
                for(int i = 1; i<s.getItemSet().Count();i++)
                {
                 List<Articulo> antecedente = s.getItemSet().ToList().GetRange(0,i);
                 List<Articulo> consecuente = s.getItemSet().ToList().GetRange(i, s.getItemSet().Count()-i);
                 rules.Add(new Rules(antecedente,consecuente,s.getSupp(),s.getSupp()/calcSupport(antecedente)));
                }
            }

            foreach (var s in frequentItemSet)
            {
                List<Articulo> antecedente = s.getItemSet().ToList().GetRange(s.getItemSet().Count()-1, s.getItemSet().Count());
                List<Articulo> consecuente = s.getItemSet().ToList().GetRange(0, s.getItemSet().Count()-1);
                rules.Add(new Rules(antecedente, consecuente, s.getSupp(), s.getSupp() / calcSupport(antecedente)));
            }

            rules.Distinct();
            
        }

        public static void checkRules(double confidCountPar)
        {
            rules = rules.Where(z => z.getConf() >= confidCountPar).ToList();
        }

        public static int calcSupport(List<Articulo> s)
        {
            int support = 0;
            foreach (var z in transactions)
            {

                if (z.All(element => s.Contains(element)))
                {
                    support++;
                }
            }
            return support;
        }

        public static List<List<Articulo>> association(List<Articulo> input)
        {
            List<List<Articulo>> salida = new List<List<Articulo>>();
            foreach (var s in rules)
            {
                if (s.antecedente.All(element => input.Contains(element)))
                {

                    salida.Add( s.consecuente);

                }
                else
                {

                    salida = null;
                }

            }

            return salida;


        }

		

    }
}
