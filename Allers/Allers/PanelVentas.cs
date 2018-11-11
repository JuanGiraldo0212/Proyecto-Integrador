using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allers
{
	public partial class PanelVentas : Form
	{
		private APriori context;

		public PanelVentas(APriori ctx)
		{
			InitializeComponent();
			context = ctx;
		
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
