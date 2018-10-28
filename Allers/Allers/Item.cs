using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
	public class Item
	{

		public int itemCode { get; set; }
		public string itemName { get; set; }

		public Item() {
			

		}

		public override string ToString()
		{
			return itemName;
		}

	}
}
