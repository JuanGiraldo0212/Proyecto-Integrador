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
			this.button1.Enabled = false;
            if (comboBox1.SelectedItem.Equals("Clustering K-means"))
            {
                var t = new Thread((ThreadStart)(() => {
                    String line = contexto.runClustering(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                   this.Invoke((MethodInvoker)delegate ()
                    {
						this.button1.Enabled = true;
						richTextBox1.Text = line;
                    });

                }));

                t.Start();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelClientes_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show(this,"Introducir sólo números", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show(this, "Introducir sólo números", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToInt32(textBox1.Text) + 1 + "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox1.Text) != 2)
            textBox1.Text = Convert.ToInt32(textBox1.Text) - 1 + "";
        }
    }
}
