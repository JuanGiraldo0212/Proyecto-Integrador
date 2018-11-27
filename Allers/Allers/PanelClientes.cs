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

            //Beyckercito el mejorcito
            //int coso =  contexto.clustering.clusters[0].itemsCluster.Count;

            this.button1.Enabled = false;
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show(this, "Debe escoger un tipo de análisis", "Aviso", MessageBoxButtons.OK);

            }
            else if (comboBox1.SelectedItem.Equals("Clustering K-means"))
            {
                var t = new Thread((ThreadStart)(() => {
                    String[] line = contexto.runClusteringSEP(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 0);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.button1.Enabled = true;
                        //richTextBox1.Text = line;
                        String[] clientesSeparados = line[0].Split('$');
                        for (int i = 0; i < clientesSeparados.Length; i++)
                        {
                            listBoxClientes.Items.Add(clientesSeparados[i]);
                        }

                        String[] itemsSeparados = line[1].Split('$');

                        for (int i = 0; i < itemsSeparados.Length; i++)
                        {
                            listBoxItems.Items.Add(itemsSeparados[i]);
                        }

                        List<List<List<String>>> recomendaciones = contexto.doRecomendationsClustering();

                        for (int i = 0; i < recomendaciones.Count; i++)
                        {
                            //listBoxRecomendaciones.Items.Add("Cluster # " + i);
                            for (int j = 0; j < recomendaciones.ElementAt(i).Count; j++)
                            {
                                if (recomendaciones.ElementAt(i).ElementAt(j).Count != 1)
                                {
                                    for (int k = 0; k < recomendaciones.ElementAt(i).ElementAt(j).Count; k++)
                                    {
                                        if (k == 0)
                                        {
                                            listBoxRecomendaciones.Items.Add("RECOMENDACIONES PARA EL CLIENTE " + recomendaciones.ElementAt(i).ElementAt(j).ElementAt(0));
                                            listBoxRecomendaciones.Items.Add("");
                                        }
                                        else
                                        {
                                            listBoxRecomendaciones.Items.Add("- " + recomendaciones.ElementAt(i).ElementAt(j).ElementAt(k));
                                            if (k == recomendaciones.ElementAt(i).ElementAt(j).Count - 1)
                                            {
                                                listBoxRecomendaciones.Items.Add("");
                                            }
                                        }
                                    }
                                }
                            }
                        }


                        pintarGraficoPastel();
                    });

                }));

                t.Start();


            }
            else if (comboBox1.SelectedItem.Equals("Clustering Bisecting-K-means"))
            {
                var t = new Thread((ThreadStart)(() => {
                    String[] line = contexto.runClusteringSEP(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 1);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.button1.Enabled = true;
                        //richTextBox1.Text = line;

                        String[] clientesSeparados = line[0].Split('$');
                        for (int i = 0; i < clientesSeparados.Length; i++)
                        {
                            listBoxClientes.Items.Add(clientesSeparados[i]);
                        }

                        String[] itemsSeparados = line[1].Split('$');

                        for (int i = 0; i < itemsSeparados.Length; i++)
                        {
                            listBoxItems.Items.Add(itemsSeparados[i]);
                        }

                        List<List<List<String>>> recomendaciones = contexto.doRecomendationsClustering();

                        for (int i = 0; i < recomendaciones.Count; i++)
                        {
                            //listBoxRecomendaciones.Items.Add("Cluster # " + i);
                            for (int j = 0; j < recomendaciones.ElementAt(i).Count; j++)
                            {
                                if (recomendaciones.ElementAt(i).ElementAt(j).Count != 1)
                                {
                                    for (int k = 0; k < recomendaciones.ElementAt(i).ElementAt(j).Count; k++)
                                    {
                                        if (k == 0)
                                        {
                                            listBoxRecomendaciones.Items.Add("RECOMENDACIONES PARA EL CLIENTE " + recomendaciones.ElementAt(i).ElementAt(j).ElementAt(0));
                                            listBoxRecomendaciones.Items.Add("");
                                        }
                                        else
                                        {
                                            listBoxRecomendaciones.Items.Add("- " + recomendaciones.ElementAt(i).ElementAt(j).ElementAt(k));

                                            if (k == recomendaciones.ElementAt(i).ElementAt(j).Count - 1)
                                            {
                                                listBoxRecomendaciones.Items.Add("");
                                            }

                                        }
                                    }
                                }
                            }
                        }
                        pintarGraficoPastel();
                    });

                }));

                t.Start();


            }
        }

        public void pintarGraficoPastel()
        {
            //chartCluster.Titles.Add("Lista Clusterings");
            for(int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                chartClust.Series["s1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint("Cluster " + i, contexto.clustering.clusters[i].itemsCluster.Count + ""));
                //chartCluster.Series["s1"].Points.AddXY("Cluster" + i, contexto.clustering.clusters[i].itemsCluster.Count + "");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.apriori1.setCont(contexto);
            this.apriori1.setRules(contexto.runClusterApriori(5,0,Convert.ToInt32(textBox3.Text),Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), 0));
            this.apriori1.visReglas(0);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
