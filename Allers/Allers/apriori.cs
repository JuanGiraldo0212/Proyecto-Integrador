using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Allers
{
    public partial class apriori : UserControl
    {
        public int indice;
        List<ReglaAsociacion> allRules = new List<ReglaAsociacion>();
        Context contexto;
        public apriori()
        {
            InitializeComponent();
        }
        public void setRules(List<ReglaAsociacion> allRules)
        {
            this.allRules = allRules;
        }

        public void setCont(Context contexto)
        {
            this.contexto = contexto;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {   

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            visReglas(-1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visReglas(1);
        }

        private void apriori_Load(object sender, EventArgs e)
        {
            indice = 0;
        }

        public void visReglas(int mov)
        {
            if (mov == 1)
            {
                if (indice == allRules.Count - 1)
                {
                    indice = 0;
                }
                else
                {
                    indice++;
                }
            }
            else if(mov ==-1)
            {
                if (indice == 0)
                {
                    indice = allRules.Count - 1;
                }
                else
                {
                    indice--;
                }
            }
            else
            {
                indice = 0;
            }
            if (allRules.Any())
            {
                String compra = contexto.convertRules(allRules[indice]).Split('-')[0];

                String compraRecomendada = contexto.convertRules(allRules[indice]).Split('-')[1];

                richTextBox1.Text = compra;
                richTextBox2.Text = compraRecomendada;
                textBox1.Text = Math.Round(allRules[indice].Confidence, 2) + "%)";

            }
            else
            {
                MessageBox.Show(this, "No se infirio ninguna regla", "Aviso", MessageBoxButtons.OK);
            }


        }

       
    }
}
