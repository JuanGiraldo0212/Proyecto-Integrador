using Allers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class APriori
	{
		public static ListaItemSet DoApriori(ListaItemSet db, double supportThreshold)
		{
			Itemset I = db.GetUniqueItems();
			ListaItemSet L = new ListaItemSet(); //itemset frecuente
			ListaItemSet Li = new ListaItemSet(); //itemset para cada iteracion
			ListaItemSet Ci = new ListaItemSet(); //itemset que supera el umbral en cada iteracion

			
			foreach (Articulo item in I)
			{
				Ci.Add(new Itemset() { item });
			}

			
			int k = 2;
			while (Ci.Count != 0)
			{
				
				Li.Clear();
				foreach (Itemset itemset in Ci)
				{
					itemset.Support = db.FindSupport(itemset);
					if (itemset.Support >= supportThreshold)
					{
						Li.Add(itemset);
						L.Add(itemset);
					}
				}

				
				Ci.Clear();
				ListaItemSet temp = MetodosBinarios.FindSubsets(Li.GetUniqueItems(), k);
				//Console.WriteLine(temp.ToString());
				Ci.AddRange(temp); 
				
				k += 1;
			}

			return (L);
		}

		public static List<ReglaAsociacion> Mine(ListaItemSet db, ListaItemSet L, double confidenceThreshold)
		{
			List<ReglaAsociacion> allRules = new List<ReglaAsociacion>();

			foreach (Itemset itemset in L)
			{
				ListaItemSet subsets = MetodosBinarios.FindSubsets(itemset, 0); 
				foreach (Itemset subset in subsets)
				{
					double confidence = (db.FindSupport(itemset) / db.FindSupport(subset)) * 100.0;
					if (confidence >= confidenceThreshold)
					{
						ReglaAsociacion rule = new ReglaAsociacion();
						rule.X.AddRange(subset);
						rule.Y.AddRange(itemset.Remove(subset));
						rule.Support = db.FindSupport(itemset);
						rule.Confidence = confidence;
						if (rule.X.Count > 0 && rule.Y.Count > 0)
						{
							allRules.Add(rule);
						}
					}
				}
			}

			return (allRules);
		}
	}
