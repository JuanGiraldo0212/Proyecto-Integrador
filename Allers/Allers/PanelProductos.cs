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

        public RichTextBox getRichbox()
        {
            return richTextBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.Equals("A-Priori"))
            {
                var t = new Thread((ThreadStart)(() => {
                   String line =contexto.runApriori(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        richTextBox1.Text = line;
                    });

                }));

                t.Start();
               
            }
            else if(comboBox1.SelectedItem.Equals("Fuerza Bruta"))
            {
                MessageBox.Show("Dada la gran cantidad de datos no es posible realizar un análisis por fuerza bruta",
                "Important Message");
            }
            button1.Enabled = false;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if(Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show(this, "Introducir sólo números", "Aviso", MessageBoxButtons.OK);
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
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show(this, "Introducir sólo números", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void PanelProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
