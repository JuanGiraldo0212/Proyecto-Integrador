using System;
using System.Collections;
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

        //De David
        public List<List<Articulo>> transactions = new List<List<Articulo>>();
        public List<Rules> rules = new List<Rules>();

        public void setTransactions(List<List<Articulo>> newTransactions)
        {
            transactions = newTransactions;
        }

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

            //Console.WriteLine(articulos.Count());
            //Console.WriteLine(ventas.Count());
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


            IEnumerable<IEnumerable<Articulo>> combinaciones = new List<List<Articulo>>();
            for (int i = 1; i <= 4; i++)
            {
                combinaciones = combinaciones.Union(Combinations(articulosPrueba, i));
            }
            //var misArt = bruta.Combinations(articulosPrueba, 2);

            List<List<Articulo>> transacciones = new List<List<Articulo>>();

            List<Articulo> lista1 = new List<Articulo>();
            lista1.Add(articulo3);
            lista1.Add(articulo4);
            List<Articulo> lista2 = new List<Articulo>();
            lista2.Add(articulo1);
            lista2.Add(articulo4);
            List<Articulo> lista3 = new List<Articulo>();
            lista3.Add(articulo2);
            lista3.Add(articulo3);
            List<Articulo> lista4 = new List<Articulo>();
            lista4.Add(articulo3);
            lista4.Add(articulo4);
            List<Articulo> lista5 = new List<Articulo>();
            lista5.Add(articulo3);
            lista5.Add(articulo4);
            List<Articulo> lista6 = new List<Articulo>();
            lista6.Add(articulo1);
            lista6.Add(articulo2);
            List<Articulo> lista7 = new List<Articulo>();
            lista7.Add(articulo1);
            lista7.Add(articulo4);

            transacciones.Add(lista1);
            transacciones.Add(lista2);
            transacciones.Add(lista3);
            transacciones.Add(lista4);
            transacciones.Add(lista5);
            transacciones.Add(lista6);
            transacciones.Add(lista7);

            setTransactions(transacciones);

            List<transWithSupp> listaFinal = frequentItemSet(combinaciones, 0.25);
            generateRules(listaFinal);
            checkRules(0.05);
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

        public List<List<Articulo>> Combinations<Articulo>(List<Articulo> elements, int setLenght)
        {
            int elementLenght = elements.Count();
            if (setLenght == 1)
            {
             
                return elements.Select(e => Enumerable.Repeat(e, 1).ToList()).ToList();
            }
            else if (setLenght == elementLenght)
            {
                
                return Enumerable.Repeat(elements, 1).ToList();
            }
            else
            {
               
                return Combinations(elements.Skip(1).ToList(), setLenght - 1)
                                .Select(tail => Enumerable.Repeat(elements.First(), 1).Union(tail).ToList())
                                .Union(Combinations(elements.Skip(1).ToList(), setLenght).ToList()).ToList();
            }
        }

        public List<List<Articulo>> ConjuntoPotencia(List<Articulo> conjunto)
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
                        string code = Convert.ToString(conjuntoPotencia[i][j].itemCode).Clone() + "";
                        actual.itemCode = Convert.ToInt32(code);
                        actual.itemName = conjuntoPotencia[i][j].itemName.Clone() + "";
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


        //Esto es lo de David

        public void cargarTransactions()
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

            private double confidenceCount { get; set; }

            public Rules(List<Articulo> antecedente, List<Articulo> consecuente, double suppCount, double confidenceCount)
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

        public List<transWithSupp> frequentItemSet(IEnumerable<IEnumerable<Articulo>> itemSets, double suppCountPar)
        {
            List<transWithSupp> transwithSuppList = new List<transWithSupp>();
            foreach (var s in itemSets)
            {
                double transcount = transactions.Count;
                double suppCount = calcSupport(s.ToList()) / transcount;
                transwithSuppList.Add(new transWithSupp(s.ToList(), suppCount, calcSupport(s.ToList())));

            }
            return transwithSuppList.Where(c => c.getSupp() >= suppCountPar).ToList();
        }

        public void generateRules(List<transWithSupp> frequentItemSet)
        {

            foreach (var s in frequentItemSet)
            {
                for (int i = 1; i < s.getItemSet().Count(); i++)
                {
                    List<Articulo> antecedente = s.getItemSet().ToList().GetRange(0, i);
                    List<Articulo> consecuente = s.getItemSet().ToList().GetRange(i, s.getItemSet().Count() - i);
                    rules.Add(new Rules(antecedente, consecuente, s.getSupp(), s.getSupp() / calcSupport(antecedente)));
                }
            }

            foreach (var s in frequentItemSet)
            {
                List<Articulo> antecedente = s.getItemSet().ToList().GetRange(s.getItemSet().Count-1, s.getItemSet().Count()-1);
                List<Articulo> consecuente = s.getItemSet().ToList().GetRange(0, s.getItemSet().Count() - 1);
                rules.Add(new Rules(antecedente, consecuente, s.getSupp(), s.getSupp() / calcSupport(antecedente)));
            }

            rules.Distinct();

        }

        public void checkRules(double confidCountPar)
        {
            rules = rules.Where(z => z.getConf() >= confidCountPar).ToList();
        }

        public  int calcSupport(List<Articulo> s)
        {
            int support = 0;
            foreach (var z in transactions)
            {

                if (s.All(element => z.Contains(element)))
                {
                    support++;
                }
            }
            return support;
        }

        public List<List<Articulo>> association(List<Articulo> input)
        {
            List<List<Articulo>> salida = new List<List<Articulo>>();
            foreach (var s in rules)
            {
                if (s.antecedente.All(element => input.Contains(element)))
                {
                    salida.Add(s.consecuente);
                }
                else
                {
                    salida = null;
                }
            }
            return salida;
            
        }

		public void cleanData(double topTH,double botTH) {

			List<Articulo> cleanList = new List<Articulo>();
			double count = ventas.Count();
			Hashtable set = new Hashtable();
			for (int i=0;i<ventas.Count();i++) {
				if (!set.ContainsKey(ventas[i].itemCode))
				{
					set.Add(ventas[i].itemCode, 1);
				}
				else {
					set[ventas[i].itemCode] = Convert.ToInt32(set[ventas[i].itemCode])+1;
				}
			}
			foreach (DictionaryEntry elemento in set) {
				Console.WriteLine(elemento.Value);
				Console.WriteLine(Convert.ToInt32(elemento.Value) / count);
				if (((Convert.ToInt32(elemento.Value)/count)>=topTH) || ((Convert.ToInt32(elemento.Value) / count) <= botTH) ) {
					try {
						cleanList.Add(articulos.First(a => a.itemCode == Convert.ToInt32(elemento.Key)));
					}
					catch (Exception e) {
						Console.WriteLine(elemento.Key);
					}
				}
			}

			Console.WriteLine(cleanList.Count());
		
		}


    }
}
