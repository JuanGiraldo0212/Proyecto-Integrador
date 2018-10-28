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
    public partial class PanelInicio : Form
    {
		private PanelMenu menu = null;
        public PanelInicio()
        {
            InitializeComponent();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			menu = new PanelMenu();
			this.Hide();
			menu.Show();
			
		}
	}
}
