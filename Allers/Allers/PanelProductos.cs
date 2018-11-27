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
        /*
        public RichTextBox getRichbox()
        {
            return richTextBox1;
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
			this.button1.Enabled = false;
            
			Console.WriteLine("ok");
            if (comboBox1.SelectedItem.Equals("A-Priori"))
            {
                var t = new Thread((ThreadStart)(() => {
                    
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.apriori1.setRules(contexto.runApriori(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
                        this.apriori1.setCont(contexto);
                        this.apriori1.visReglas(0);
                        this.button1.Enabled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToDouble(textBox1.Text) + 0.1) + "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) != 0.0)
                textBox1.Text = Convert.ToDouble(textBox1.Text) - 0.1 + "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToDouble(textBox2.Text) + 0.1 + "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) != 0.0)
                textBox2.Text = Convert.ToDouble(textBox2.Text) - 0.1 + "";
        }

        private void apriori1_Load(object sender, EventArgs e)
        {

        }
    }
}
