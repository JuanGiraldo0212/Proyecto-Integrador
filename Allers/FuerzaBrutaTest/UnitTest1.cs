using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Allers;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace FuerzaBrutaTest
{
    [TestClass]
    public class UnitTest1
    {
        /*
        [TestMethod]
        public void TestCargaCantidadElementos()
        {
            
             BruteForce bruta = new BruteForce();
             bruta.loadData();
             int resultadoCantidadArticulos = 18;
             int resultadoCantidadVentas = 149299;

             
            Assert.AreEqual(bruta.getItems().Count(), resultadoCantidadArticulos);
            Assert.AreEqual(bruta.getSales().Count(), resultadoCantidadVentas);
            
        }
        */
        [TestMethod]
        public void TestClustering()
        {
            Context contexto = new Context();
            contexto.loadDataClustering(4000);

            for(int j = 0; j < 2; j++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Clustering cluster = new Clustering(contexto.listClients, 3, 0);
                sw.Stop();
                String tiempoPartido = sw.Elapsed.TotalMilliseconds.ToString();
                Console.WriteLine(tiempoPartido);
            }

            Console.WriteLine("Finalizo Beycker");

            Assert.AreEqual(1, 1);
        }


            /*
            [TestMethod]
            public void TestCargaElementoAt()
            {
                BruteForce bruta = new BruteForce();
                bruta.loadData();

                String resultadoArticulo = "TAPON EMERGENCIA CAUCHO 1010 ALL AMERICA";
                String resultadoVenta = "66";

                Assert.AreEqual(bruta.getItems().ElementAt(10).itemName, resultadoArticulo);
                Assert.AreEqual(bruta.getSales().ElementAt(17).itemCode, resultadoVenta);

            }
            [TestMethod]
            public void TestCombination()
            {


                BruteForce bruta = new BruteForce();
                Item articulo1 = new Item();
                articulo1.itemCode = 1;
                articulo1.itemName = "A";

                Item articulo2 = new Item();
                articulo2.itemCode = 2;
                articulo2.itemName = "B";

                Item articulo3 = new Item();
                articulo3.itemCode = 3;
                articulo3.itemName = "C";

                Item articulo4 = new Item();
                articulo4.itemCode = 4;
                articulo4.itemName = "D";

                Item articulo5 = new Item();
                articulo5.itemCode = 5;
                articulo5.itemName = "E";

                Item articulo6 = new Item();
                articulo6.itemCode = 6;
                articulo6.itemName = "F";

                List<Item> articulosPrueba = new List<Item>();

                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                articulosPrueba.Add(articulo5);
                articulosPrueba.Add(articulo6);

                var misArt = bruta.Combinations(articulosPrueba, 2);

                Assert.AreEqual(misArt.Count(), 15);

            }
            [TestMethod]
            public void TestCombinationElementAt()
            {
                BruteForce bruta = new BruteForce();
                Item articulo1 = new Item();
                articulo1.itemCode = 1;
                articulo1.itemName = "A";

                Item articulo2 = new Item();
                articulo2.itemCode = 2;
                articulo2.itemName = "B";

                Item articulo3 = new Item();
                articulo3.itemCode = 3;
                articulo3.itemName = "C";

                Item articulo4 = new Item();
                articulo4.itemCode = 4;
                articulo4.itemName = "D";

                Item articulo5 = new Item();
                articulo5.itemCode = 5;
                articulo5.itemName = "E";

                Item articulo6 = new Item();
                articulo6.itemCode = 6;
                articulo6.itemName = "F";

                Item articulo7 = new Item();
                articulo7.itemCode = 7;
                articulo7.itemName = "G";

                Item articulo8 = new Item();
                articulo8.itemCode = 8;
                articulo8.itemName = "H";

                List<Item> articulosPrueba = new List<Item>();

                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                articulosPrueba.Add(articulo5);
                articulosPrueba.Add(articulo6);
                articulosPrueba.Add(articulo7);
                articulosPrueba.Add(articulo8);

                var misArt = bruta.Combinations(articulosPrueba, 3);

                Assert.AreEqual(misArt.ElementAt(0).ElementAt(0).itemName, "A");
                Assert.AreEqual(misArt.ElementAt(0).ElementAt(1).itemName, "B");
                Assert.AreEqual(misArt.ElementAt(0).ElementAt(2).itemName, "C");

                Assert.AreEqual(misArt.ElementAt(55).ElementAt(0).itemName, "F");
                Assert.AreEqual(misArt.ElementAt(55).ElementAt(1).itemName, "G");
                Assert.AreEqual(misArt.ElementAt(55).ElementAt(2).itemName, "H");

            }

            [TestMethod]
            public void TestConjuntoPotencia()
            {
                BruteForce bruta = new BruteForce();
                Item articulo1 = new Item();
                articulo1.itemCode = 1;
                articulo1.itemName = "A";

                Item articulo2 = new Item();
                articulo2.itemCode = 2;
                articulo2.itemName = "B";

                Item articulo3 = new Item();
                articulo3.itemCode = 3;
                articulo3.itemName = "C";

                Item articulo4 = new Item();
                articulo4.itemCode = 4;
                articulo4.itemName = "D";

                List<Item> articulosPrueba = new List<Item>();

                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);

                var misArt = bruta.SetPow(articulosPrueba);

                Assert.AreEqual(misArt.ElementAt(0).Count(), 0);

                Assert.AreEqual(misArt.ElementAt(1).ElementAt(0).itemName, "A");

                Assert.AreEqual(misArt.ElementAt(2).ElementAt(0).itemName, "B");

                Assert.AreEqual(misArt.ElementAt(3).ElementAt(0).itemName, "A");
                Assert.AreEqual(misArt.ElementAt(3).ElementAt(1).itemName, "B");

                Assert.AreEqual(misArt.ElementAt(15).ElementAt(0).itemName, "A");
                Assert.AreEqual(misArt.ElementAt(15).ElementAt(1).itemName, "D");
                Assert.AreEqual(misArt.ElementAt(15).ElementAt(2).itemName, "C");
                Assert.AreEqual(misArt.ElementAt(15).ElementAt(3).itemName, "B");
            }

            [TestMethod]
            public void TestConjuntoPotenciaLarga()
            {
                BruteForce bruta = new BruteForce();
                Item articulo1 = new Item();
                articulo1.itemCode = 1;
                articulo1.itemName = "A";

                Item articulo2 = new Item();
                articulo2.itemCode = 2;
                articulo2.itemName = "B";

                Item articulo3 = new Item();
                articulo3.itemCode = 3;
                articulo3.itemName = "C";

                Item articulo4 = new Item();
                articulo4.itemCode = 4;
                articulo4.itemName = "D";

                Item articulo5 = new Item();
                articulo5.itemCode = 5;
                articulo5.itemName = "E";

                Item articulo6 = new Item();
                articulo6.itemCode = 6;
                articulo6.itemName = "F";

                Item articulo7 = new Item();
                articulo7.itemCode = 7;
                articulo7.itemName = "G";

                Item articulo8 = new Item();
                articulo8.itemCode = 8;
                articulo8.itemName = "H";

                Item articulo9 = new Item();
                articulo9.itemCode = 9;
                articulo9.itemName = "I";

                List<Item> articulosPrueba = new List<Item>();

                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                articulosPrueba.Add(articulo5);
                articulosPrueba.Add(articulo6);
                articulosPrueba.Add(articulo7);
                articulosPrueba.Add(articulo8);
                articulosPrueba.Add(articulo9);

                var misArt = bruta.SetPow(articulosPrueba);

                Assert.AreEqual(misArt.ElementAt(511).ElementAt(0).itemName, "A");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(1).itemName, "I");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(2).itemName, "H");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(3).itemName, "G");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(4).itemName, "F");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(5).itemName, "E");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(6).itemName, "D");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(7).itemName, "C");
                Assert.AreEqual(misArt.ElementAt(511).ElementAt(8).itemName, "B");
            }

            [TestMethod]
            public void TestFrequentItemSet()
            {
                BruteForce bruta = new BruteForce();
                Item articulo1 = new Item();
                articulo1.itemCode = 1;
                articulo1.itemName = "A";

                Item articulo2 = new Item();
                articulo2.itemCode = 2;
                articulo2.itemName = "B";

                Item articulo3 = new Item();
                articulo3.itemCode = 3;
                articulo3.itemName = "C";

                Item articulo4 = new Item();
                articulo4.itemCode = 4;
                articulo4.itemName = "D";

                List<Item> articulosPrueba = new List<Item>();

                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);


                IEnumerable<IEnumerable<Item>> combinaciones = new List<List<Item>>();
                for (int i = 1; i <=4; i++)
                {
                    combinaciones = combinaciones.Union(bruta.Combinations(articulosPrueba, i));
                }
                //var misArt = bruta.Combinations(articulosPrueba, 2);

                List<List<Item>> transacciones = new List<List<Item>>();

                List<Item> lista1 = new List<Item>();
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                List<Item> lista2 = new List<Item>();
                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo4);
                List<Item> lista3 = new List<Item>();
                articulosPrueba.Add(articulo2);
                articulosPrueba.Add(articulo3);
                List<Item> lista4 = new List<Item>();
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                List<Item> lista5 = new List<Item>();
                articulosPrueba.Add(articulo3);
                articulosPrueba.Add(articulo4);
                List<Item> lista6 = new List<Item>();
                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo2);
                List<Item> lista7 = new List<Item>();
                articulosPrueba.Add(articulo1);
                articulosPrueba.Add(articulo4);

                transacciones.Add(lista1);
                transacciones.Add(lista2);
                transacciones.Add(lista3);
                transacciones.Add(lista4);
                transacciones.Add(lista5);
                transacciones.Add(lista6);
                transacciones.Add(lista1);
                transacciones.Add(lista7);

                bruta.setTransactions(transacciones);


            }

        */

        }
}
