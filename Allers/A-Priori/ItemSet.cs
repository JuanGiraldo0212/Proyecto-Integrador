

using Allers;
using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	
		public class Itemset : List<Articulo>
		{
			

			public double Support { get; set; }

			public bool Contains(Itemset itemset)
			{
				return (this.Intersect(itemset).Count() == itemset.Count);
			}

			public Itemset Remove(Itemset itemset)
			{
				Itemset removed = new Itemset();
				removed.AddRange(from item in this
								 where !itemset.Contains(item)
								 select item);
				return (removed);
			}

			public override string ToString()
			{
				string line = "{";
				foreach(var s in this){
				line += s.ToString()+",";
				}
				line += "}";
				return line + (this.Support > 0 ? " (support: " + Math.Round(this.Support, 2) + "%)" : string.Empty);
			}

			
		}
	
