using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
	public class Client
	{
		 
		public string CardCode { get; set; }
		public string GroupName { get; set; }
		public string City { get; set; }
		public string Dpto { get; set; }
        public string PymntGruoup { get; set; }
        public double[] items { get; set; }
        public double Purchases { get; set; }
        
        public Client() {}
}
}
