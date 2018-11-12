using Allers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Cluster
    {
        public List<Client> itemsCluster { get; set; }
        public double[] centroid { get; set; }

        public Cluster(double[] centroid, Client clienteCentroide)
        {
            this.centroid = centroid;
		    itemsCluster = new List<Client>();
            itemsCluster.Add(clienteCentroide);
        } 

    }

