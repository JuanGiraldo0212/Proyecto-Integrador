using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Allers;
using System.Linq;
using System.Collections.Generic;

namespace FuerzaBrutaTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestCargaCantidadElementos()
        {
            FuercitaBruta bruta = new FuercitaBruta();
            bruta.cargarDatos();
            int resultadoCantidadArticulos = 18;
            int resultadoCantidadVentas = 149299;

            //Assert
            Assert.AreEqual(bruta.darArticulos().Count(), resultadoCantidadArticulos);
            Assert.AreEqual(bruta.darVentas().Count(), resultadoCantidadVentas);
        }
        [TestMethod]
        public void TestCargaElementoAt()
        {
            FuercitaBruta bruta = new FuercitaBruta();
            bruta.cargarDatos();

            String resultadoArticulo = "TAPON EMERGENCIA CAUCHO 1010 ALL AMERICA";
            String resultadoVenta = "66";

            Assert.AreEqual(bruta.darArticulos().ElementAt(10).itemName, resultadoArticulo);
            Assert.AreEqual(bruta.darVentas().ElementAt(17).itemCode, resultadoVenta);

        }
        [TestMethod]
        public void TestCombination()
        {
            FuercitaBruta bruta = new FuercitaBruta();
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

            Articulo articulo5 = new Articulo();
            articulo5.itemCode = 5;
            articulo5.itemName = "E";

            Articulo articulo6 = new Articulo();
            articulo6.itemCode = 6;
            articulo6.itemName = "F";

            List<Articulo> articulosPrueba = new List<Articulo>();

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
            FuercitaBruta bruta = new FuercitaBruta();
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
            
            Articulo articulo5 = new Articulo();
            articulo5.itemCode = 5;
            articulo5.itemName = "E";

            Articulo articulo6 = new Articulo();
            articulo6.itemCode = 6;
            articulo6.itemName = "F";

            Articulo articulo7 = new Articulo();
            articulo7.itemCode = 7;
            articulo7.itemName = "G";

            Articulo articulo8 = new Articulo();
            articulo8.itemCode = 8;
            articulo8.itemName = "H";

            List<Articulo> articulosPrueba = new List<Articulo>();

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
            FuercitaBruta bruta = new FuercitaBruta();
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

            var misArt = bruta.ConjuntoPotencia(articulosPrueba);

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
            FuercitaBruta bruta = new FuercitaBruta();
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

            Articulo articulo5 = new Articulo();
            articulo5.itemCode = 5;
            articulo5.itemName = "E";

            Articulo articulo6 = new Articulo();
            articulo6.itemCode = 6;
            articulo6.itemName = "F";

            Articulo articulo7 = new Articulo();
            articulo7.itemCode = 7;
            articulo7.itemName = "G";

            Articulo articulo8 = new Articulo();
            articulo8.itemCode = 8;
            articulo8.itemName = "H";

            Articulo articulo9 = new Articulo();
            articulo9.itemCode = 9;
            articulo9.itemName = "I";

            List<Articulo> articulosPrueba = new List<Articulo>();

            articulosPrueba.Add(articulo1);
            articulosPrueba.Add(articulo2);
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);
            articulosPrueba.Add(articulo5);
            articulosPrueba.Add(articulo6);
            articulosPrueba.Add(articulo7);
            articulosPrueba.Add(articulo8);
            articulosPrueba.Add(articulo9);

            var misArt = bruta.ConjuntoPotencia(articulosPrueba);

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
            FuercitaBruta bruta = new FuercitaBruta();
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
            for (int i = 1; i <=4; i++)
            {
                combinaciones = combinaciones.Union(bruta.Combinations(articulosPrueba, i));
            }
            //var misArt = bruta.Combinations(articulosPrueba, 2);

            List<List<Articulo>> transacciones = new List<List<Articulo>>();

            List<Articulo> lista1 = new List<Articulo>();
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);
            List<Articulo> lista2 = new List<Articulo>();
            articulosPrueba.Add(articulo1);
            articulosPrueba.Add(articulo4);
            List<Articulo> lista3 = new List<Articulo>();
            articulosPrueba.Add(articulo2);
            articulosPrueba.Add(articulo3);
            List<Articulo> lista4 = new List<Articulo>();
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);
            List<Articulo> lista5 = new List<Articulo>();
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);
            List<Articulo> lista6 = new List<Articulo>();
            articulosPrueba.Add(articulo1);
            articulosPrueba.Add(articulo2);
            List<Articulo> lista7 = new List<Articulo>();
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

    }
}
