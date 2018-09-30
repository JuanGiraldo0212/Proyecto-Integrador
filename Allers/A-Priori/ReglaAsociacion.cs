using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class ReglaAsociacion
	{
		

		public Itemset X { get; set; }
		public Itemset Y { get; set; }
		public double Support { get; set; }
		public double Confidence { get; set; }
		

		public ReglaAsociacion()
		{
			X = new Itemset();
			Y = new Itemset();
			Support = 0.0;
			Confidence = 0.0;
		}


		public override string ToString()
		{
			return (X + " => " + Y + " (support: " + Math.Round(Support, 2) + "%, confidence: " + Math.Round(Confidence, 2) + "%)");
		}
	
	}
