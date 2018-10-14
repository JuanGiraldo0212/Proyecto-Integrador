using Allers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Cluster
    {
        public List<Cliente> elementos { get; set; }
        public double[] centroid { get; set; }

        public Cluster(double[] centroid, Cliente clienteCentroide)
        {
            this.centroid = centroid;
		elementos = new List<Cliente>();
            elementos.Add(clienteCentroide);
        } 

    }

