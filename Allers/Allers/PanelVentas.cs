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
	public partial class PanelVentas : Form
	{
		private Context context;

		public PanelVentas(Context ctx)
		{
			InitializeComponent();
			context = ctx;
		
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem.Equals("High Utility"))
			{
				var t = new Thread((ThreadStart)(() => {
					String line = context.runHighUtility(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
					this.Invoke((MethodInvoker)delegate ()
					{
						richTextBox1.Text = line;
						this.button1.Enabled = true;
					});

				}));

				t.Start();

			}
		}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
