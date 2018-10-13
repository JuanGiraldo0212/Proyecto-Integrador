using Allers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class APriori
	{

	public static String PrintL(List<List<string>> op) {
		String imp = "";
		foreach (var s in op)
		{
			imp += "{";
			foreach (var p in s)
			{
				imp += p + ",";
			}
			imp += "}\n";
		}
		return imp;
	}


		public static List<List<string>> ItemSetsUnicos(List<List<string>> db)
		{
			List<List<string>> unique = new List<List<string>>();
		
		foreach (List<string> itemset in db)
			{
			
			foreach (String item in itemset) {
				List<string> nueva = new List<string>{item};
				//Console.WriteLine(itemset.Count());
				
				if (!unique.Any(x=>x.Any(y=>y.Equals(item)))) {
					
					unique.Add(nueva);
				}
			}
			}

			return (unique);
		}

		public static double FindSupport(List<string> item, List<List<string>> db)
	{
		int matchCount = 0;
		foreach (var s in db) {
			
			if (item.All(x => s.Contains(x))) {
				matchCount++;
			}
			

		}

		double support = ((double)matchCount / (double)db.Count) * 100.0;
		return (support);
	}


	public static List<List<string>> ItemsFrecuentes(List<List<string>>  db, double supportThreshold)
	{
		//I.ForEach(x=>Console.WriteLine(x.ToString()));
		List<List<string>> L = new List<List<string>>(); //itemset frecuente
		List<List<string>> Li = new List<List<string>>(); //itemset para cada iteracion
		List<List<string>> Ci = new List<List<string>>(); //itemset que supera el umbral en cada iteracion
		List<List<string>> Temp = ItemSetsUnicos(db);
	//Console.WriteLine(PrintL(Temp));
		foreach (List<string> item in Temp)
		{
			Ci.Add(item);
		}

		
		int k = 2;
		while (Ci.Count != 0)
		{
			
			Li.Clear();
			foreach (List<string> itemset in Ci)
			{

				double supp=FindSupport(itemset,db);
				
				if (supp >= supportThreshold)
				{
					Li.Add(itemset);
					L.Add(itemset);
				}
			}


			Ci.Clear();
			//Console.WriteLine(PrintL(Li));
			List<List<string>> temp = CombinacionesApriori(Li);
			//Console.WriteLine(temp.Count);
			//Console.WriteLine(temp.Count);
			//Console.WriteLine(k);
			//temp.ForEach(x => Console.WriteLine(x.ToString()));

			//Console.WriteLine(temp.ToString());
			Ci.AddRange(temp);

			k += 1;
		}

		return (L);
	}


	public static List<List<string>> CombinacionesApriori(List<List<string>> db) {
		List<List<string>> listaFin = new List<List<string>>();
		int largo = db.Count;
		for (int i=0;i<largo;i++) {
			String[] actual = new string[db[i].Count]; 
			db[i].CopyTo(actual);
			List<string> actual2 = actual.ToList();
			for (int j=i+1;j<largo;j++) {

				string[] union = new string[db[j].Count];
				db[j].CopyTo(union);
				List<string> union2 = union.ToList();
				union2.AddRange(actual2);
				//union2.Distinct();
				listaFin.Add(union2);
			}

		}
		return listaFin;
	}

	public static IEnumerable<IEnumerable<T>> GetPowerSet<T>(List<T> list)
	{
		return from m in Enumerable.Range(0, 1 << list.Count)
			   select
				   from i in Enumerable.Range(0, list.Count)
				   where (m & (1 << i)) != 0
				   select list[i];
	}

	public static List<ReglaAsociacion> ReglasAsociacion(List<List<string>> db, List<List<string>> L, double confidenceThreshold)
		{
			List<ReglaAsociacion> allRules = new List<ReglaAsociacion>();

			foreach (List<string> itemset in L)
			{
				var subsets = GetPowerSet(itemset);
			
			foreach (var subset in subsets)
			{
				 
				double confidence = (FindSupport(itemset, db) / FindSupport(subset.ToList(), db)) * 100.0;
				if (confidence >= confidenceThreshold)
				{
					ReglaAsociacion rule = new ReglaAsociacion();
					string[] temp = new string[itemset.Count];
					itemset.CopyTo(temp);
					List<string> itemset2 = temp.ToList();
					rule.X.AddRange(subset);
					subset.ToList().ForEach(x => itemset2.Remove(x));
					rule.Y.AddRange(itemset2);
					rule.Support = FindSupport(itemset, db);
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
