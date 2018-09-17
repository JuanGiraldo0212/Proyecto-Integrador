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
        
        public void TestCargaElementoAt()
        {
            FuercitaBruta bruta = new FuercitaBruta();
            bruta.cargarDatos();

            String resultadoArticulo = "TAPON EMERGENCIA CAUCHO 1010 ALL AMERICA";
            String resultadoVenta = "66";

            Assert.AreEqual(bruta.darArticulos().ElementAt(9).itemName, resultadoArticulo);
            Assert.AreEqual(bruta.darVentas().ElementAt(17).itemCode, resultadoVenta);

        }

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

            List<Articulo> articulosPrueba = new List<Articulo>();

            articulosPrueba.Add(articulo1);
            articulosPrueba.Add(articulo2);
            articulosPrueba.Add(articulo3);
            articulosPrueba.Add(articulo4);

            var misArt = bruta.Combinations(articulosPrueba, 2);

            Assert.AreEqual(misArt.Count(), 6);

        }
        
    }
}
