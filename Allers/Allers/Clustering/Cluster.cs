using System;
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
        double meanGroupName { get; set; }
        double meanCity { get; set; }
        double meanDpto { get; set; }
        double meanPymntGroup { get; set; }
        public Cluster(Cliente clientCentroid)
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
