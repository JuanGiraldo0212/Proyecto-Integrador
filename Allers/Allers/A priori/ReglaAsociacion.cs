using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class ReglaAsociacion
	{
		

		public List<string> X { get; set; }
		public List<string> Y { get; set; }
		public double Support { get; set; }
		public double Confidence { get; set; }
		

		public ReglaAsociacion()
		{
			X = new List<string>();
			Y = new List<string>();
			Support = 0.0;
			Confidence = 0.0;
		}

	public string ImpList(List<string> list) {
		String imp = "{";
		list.ForEach(x=>imp+=x+",");
		imp += "}";
		return imp;
	}


		public override string ToString()
		{
			return (ImpList(X) + " => " + ImpList(Y) + " (support: " + Math.Round(Support, 2) + "%, confidence: " + Math.Round(Confidence, 2) + "%)");
		}
	
	}
