using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allers
{
	public partial class PanelMenu : Form
	{
		private PanelProductos productos;
		private PanelClientes clientes;
		private PanelVentas ventas;
        private Context contexto;
		public PanelMenu()
		{
            contexto = new Context();
			InitializeComponent();
		}

		

		private void button1_Click(object sender, EventArgs e)
		{
			
				productos = new PanelProductos(contexto);
				//this.Hide();
				productos.Show();
			
			
		}

		private void PanelMenu_Load(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			clientes = new PanelClientes(contexto);
			clientes.Show();
		}

        private void button5_Click(object sender, EventArgs e)
        {

          //  string selectedPathArt = "";
          //  string selectedPathClie = "";
          //  string selectedPathVent = "";
          //  var t = new Thread((ThreadStart)(() => {
          //      /*FolderBrowserDialog fbd = new FolderBrowserDialog();
          //      fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
          //      fbd.ShowNewFolderButton = true;

          //      if (fbd.ShowDialog() == DialogResult.Cancel)
          //          return;

          //      selectedPathArt = fbd.SelectedPath;
          //      */
          //      MessageBox.Show("Escoga el archivo de articulos",
          //  "Important Message");
          //      OpenFileDialog openFileDialog1 = new OpenFileDialog();
          //      DialogResult result = openFileDialog1.ShowDialog();
          //      if (result == DialogResult.OK)
          //      {
          //          selectedPathArt = openFileDialog1.FileName;
          //      }


          //      MessageBox.Show("Escoga el archivo de Clientes",
          //"Important Message");
          //      OpenFileDialog openFileDialog2 = new OpenFileDialog();
          //      DialogResult result2 = openFileDialog2.ShowDialog();
          //      if (result2 == DialogResult.OK)
          //      {
          //          selectedPathClie = openFileDialog2.FileName;
          //      }

          //      MessageBox.Show("Escoga el archivo de Ventas",
          //"Important Message");

          //      OpenFileDialog openFileDialog3 = new OpenFileDialog();
          //      DialogResult result3 = openFileDialog3.ShowDialog();
          //      if (result3 == DialogResult.OK)
          //      {
          //          selectedPathVent = openFileDialog3.FileName;
          //      }
          //      contexto.loadData(selectedPathArt, selectedPathClie, selectedPathVent);
                
          //  }));
            


          //  t.SetApartmentState(ApartmentState.STA);
          //  t.Start();
        }

		private void button4_Click(object sender, EventArgs e)
		{
			ventas = new PanelVentas(contexto);
			ventas.Show();
		}

		private void PanelMenu_FormClosed(object sender, FormClosedEventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
