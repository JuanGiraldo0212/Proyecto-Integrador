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
	public partial class PanelClientes : Form
	{
        Context contexto;
		public PanelClientes(Context contexto)
		{
            this.contexto = contexto;
			InitializeComponent();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            String line = contexto.runClustering(Convert.ToInt32(textBox1.Text));
            richTextBox1.Text = line;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
