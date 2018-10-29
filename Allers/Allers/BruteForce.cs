using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    public class BruteForce
    {
        /*
        public List<Item> listItems = new List<Item>();
        public List<Sale> listSales = new List<Sale>();
        public List<Client> listClients = new List<Client>();
        
        public List<List<Item>> listTransactions = new List<List<Item>>();
        */
        public List<Rules> listRules;
        public static Hashtable clientInfoHT;
        public Context context;

        public Context getContext()
        {
            return context;
        }

        /*
        public void setTransactions(List<List<Item>> newTransactions)
        {
            listTransactions = newTransactions;
        }

        public List<Item> getItems()
        {
            return listItems;
        }
        
        public List<Sale> getSales()
        {
            return listSales;
        }
        */

        public BruteForce()
        {
            context = new Context();
            listRules = new List<Rules>();
            clientInfoHT = new Hashtable();

           // context.loadData(0);
        }

        public void preCombinations()
        {
            Item item1 = new Item();
            item1.itemCode = 1;
            item1.itemName = "A";

            Item item2 = new Item();
            item2.itemCode = 2;
            item2.itemName = "B";

            Item item3 = new Item();
            item3.itemCode = 3;
            item3.itemName = "C";

            Item item4 = new Item();
            item4.itemCode = 4;
            item4.itemName = "D";

            List<Item> testItems = new List<Item>();

            testItems.Add(item1);
            testItems.Add(item2);
            testItems.Add(item3);
            testItems.Add(item4);


            IEnumerable<IEnumerable<Item>> combinationsIE = GetPowerSet(testItems);
            Console.Write("ITEMSETS GENERADOS");
            combinationsIE.OrderBy(x => x.Count()).ToList().ForEach(i =>
            {
                Console.Write("{");
                i.ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.WriteLine("}");
            });

            //var misArt = bruta.Combinations(articulosPrueba, 2);

            List<List<Item>> transactionsLL = new List<List<Item>>();

            List<Item> list1 = new List<Item>();
            list1.Add(item3);
            list1.Add(item4);
            List<Item> list2 = new List<Item>();
            list2.Add(item1);
            list2.Add(item4);
            List<Item> list3 = new List<Item>();
            list3.Add(item2);
            list3.Add(item3);
            List<Item> list4 = new List<Item>();
            list4.Add(item3);
            list4.Add(item4);
            List<Item> list5 = new List<Item>();
            list5.Add(item3);
            list5.Add(item4);
            List<Item> list6 = new List<Item>();
            list6.Add(item1);
            list6.Add(item2);
            List<Item> list7 = new List<Item>();
            list7.Add(item1);
            list7.Add(item4);

            transactionsLL.Add(list1);
            transactionsLL.Add(list2);
            transactionsLL.Add(list3);
            transactionsLL.Add(list4);
            transactionsLL.Add(list5);
            transactionsLL.Add(list6);
            transactionsLL.Add(list7);

            context.setTransactions(transactionsLL);

            List<transWithSupp> endList = frequentItemSet(combinationsIE, 0.25);
            Console.WriteLine("ITEMSETS FRECUENTES");
            endList.OrderBy(x => x.getItemSet().Count()).ToList().ForEach(i =>
            {
                Console.Write("{");
                i.getItemSet().ToList().ForEach(j => Console.Write(j.itemName + ","));
                Console.Write("}");
                Console.WriteLine(" Support Count:" + i.getSupp());
            });
            generateRules(endList);
            Console.WriteLine("REGLAS GENERADAS");
            listRules.ForEach(r =>
            {
                Console.Write("{");
                r.antecedent.ForEach(a => Console.Write(a.itemName + ","));
                Console.Write("-->");
                r.consequent.ForEach(b => Console.Write(b.itemName + ","));
                Console.Write("}");
                Console.Write("Confidence count:" + r.getConf());
                Console.Write(" Support Count:" + r.getSupp());

                Console.Write("\n");

            });
            checkRules(0.09);
            Console.WriteLine("REGLAS QUE PASARON EL UMBRAL DE 0,09");
            listRules.ForEach(r =>
            {
                Console.Write("{");
                r.antecedent.ForEach(a => Console.Write(a.itemName + ","));
                Console.Write("-->");
                r.consequent.ForEach(b => Console.Write(b.itemName + ","));
                Console.Write("}");
                Console.Write("Confidence count:" + r.getConf());
                Console.Write(" Support Count:" + r.getSupp());

                Console.Write("\n");

            });

        }
        public IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }
        public void makeCombinaciones()
        {
            Combinations(context.listItems, 9).AsParallel().ToList().ForEach(i =>
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

        public List<List<Item>> SetPow(List<Item> set)
        {
            List<List<Item>> listSetPow = new List<List<Item>>();
            if (set.Count() == 2)
            {
                listSetPow.Add(new List<Item>());
                List<Item> conjunto1 = new List<Item>()
                {
                    set[0]
                };
                List<Item> conjunto2 = new List<Item>()
                {
                    set[1]
                };
                List<Item> conjunto3 = new List<Item>()
                {
                    set[0],set[1],
                };
                listSetPow.Add(conjunto1);
                listSetPow.Add(conjunto2);
                listSetPow.Add(conjunto3);
            }
            else
            {
                List<Item> aux = new List<Item>();
                for (int i = 0; i < set.Count() - 1; i++)
                {
                    aux.Add(set[i]);
                }
                Item last = set.Last();
                listSetPow = SetPow(aux);

                List<List<Item>> aux1 = new List<List<Item>>();

                for (int i = 0; i < listSetPow.Count(); i++)
                {
                    List<Item> aux2 = new List<Item>();
                    if (listSetPow[i].Count() == 0)
                    {
                        aux2.Add(last);
                    }
                    for (int j = 0; j < listSetPow[i].Count(); j++)
                    {
                        Item actual = new Item();
                        string code = Convert.ToString(listSetPow[i][j].itemCode).Clone() + "";
                        actual.itemCode = Convert.ToInt32(code);
                        actual.itemName = listSetPow[i][j].itemName.Clone() + "";
                        aux2.Add(actual);
                        aux2.Add(last);
                    }
                    aux1.Add(aux2.Distinct().ToList());
                }
                foreach (List<Item> lista in aux1)
                {

                    listSetPow.Add(lista);
                }
            }
            return listSetPow;
        }


        //Esto es lo de David

        public class transWithSupp
        {
            private List<Item> trans { get; set; }
            private double suppCount { get; set; }
            private double supp { get; set; }

            public transWithSupp(List<Item> trans, double suppCount, double supp)
            {
                this.trans = trans;
                this.suppCount = suppCount;
                this.supp = supp;
            }
            public double getSupp()
            {
                return suppCount;
            }

            public List<Item> getItemSet()
            {
                return trans;
            }

        }

        public class Rules
        {
            public List<Item> antecedent { get; set; }
            public List<Item> consequent { get; set; }
            private double suppCount { get; set; }

            private double confidenceCount { get; set; }

            public Rules(List<Item> antecedent, List<Item> consequent, double suppCount, double confidenceCount)
            {
                this.consequent = consequent;
                this.antecedent = antecedent;
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

        public List<transWithSupp> frequentItemSet(IEnumerable<IEnumerable<Item>> itemSets, double suppCountPar)
        {
            List<transWithSupp> transwithSuppList = new List<transWithSupp>();
            foreach (var s in itemSets)
            {
                double transcount = context.listTransactions.Count;
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
                    List<Item> antecedente = s.getItemSet().ToList().GetRange(0, i);
                    List<Item> consecuente = s.getItemSet().ToList().GetRange(i, s.getItemSet().Count() - i);
                    if (antecedente.Count() != 0 && consecuente.Count() != 0)
                    {
                        listRules.Add(new Rules(antecedente, consecuente, s.getSupp(), s.getSupp() / calcSupport(antecedente)));
                    }
                }
            }

            foreach (var s in frequentItemSet)
            {
                if (s.getItemSet().Count() > 0)
                {
                    List<Item> antecedente = s.getItemSet().ToList().GetRange(s.getItemSet().Count - 1, s.getItemSet().Count() - 1);
                    List<Item> consecuente = s.getItemSet().ToList().GetRange(0, s.getItemSet().Count() - 1);
                    if (antecedente.Count() != 0 && consecuente.Count() != 0)
                    {
                        listRules.Add(new Rules(antecedente, consecuente, s.getSupp(), s.getSupp() / calcSupport(antecedente)));
                    }
                }
            }

            listRules.Distinct();

        }

        public void checkRules(double confidCountPar)
        {
            listRules = listRules.Where(z => z.getConf() >= confidCountPar).ToList();
        }

        public int calcSupport(List<Item> s)
        {
            int support = 0;
            foreach (var z in context.listTransactions)
            {

                if (s.All(element => z.Contains(element)))
                {
                    support++;
                }
            }
            return support;
        }

        public List<List<Item>> association(List<Item> input)
        {
            List<List<Item>> exit = new List<List<Item>>();
            foreach (var s in listRules)
            {
                if (s.antecedent.All(element => input.Contains(element)))
                {
                    exit.Add(s.consequent);
                }
                else
                {
                    exit = null;
                }
            }
            return exit;

        }


    }
}

