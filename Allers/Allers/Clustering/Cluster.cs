﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers.Clustering
{
    class Cluster
    {
        List<Cliente> elementos { get; set; }
        double[] centroid { get; set; }
        public Cluster(Cliente clienteCentroide)
        {
          
        }
        public void reCalculateCentroid()
        {
            if(elementos.Count() != 0)
            {
                foreach (Cliente actual in elementos)
                {

                }
            }
        }
    }
}