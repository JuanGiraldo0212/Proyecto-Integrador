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
	public partial class PanelMenu : Form
	{
		private PanelProductos productos;
		private PanelClientes clientes;
		public PanelMenu()
		{
			InitializeComponent();
		}

		

		private void button1_Click(object sender, EventArgs e)
		{
			
				productos = new PanelProductos();
				//this.Hide();
				productos.Show();
			
			
		}

		private void PanelMenu_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			clientes = new PanelClientes();
			clientes.Show();
		}
	}
}
