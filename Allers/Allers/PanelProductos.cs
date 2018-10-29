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
	public partial class PanelProductos : Form
	{
        Context contexto;

        public PanelProductos(Context contexto)
		{
            this.contexto = contexto;
			InitializeComponent();
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String line = contexto.runApriori(Convert.ToInt32(textBox1.Text),Convert.ToInt32(textBox2.Text));
            richTextBox1.Text=line;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
