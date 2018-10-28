namespace Allers
{
	partial class PanelClientes
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelClientes));
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Clustering"});
			this.comboBox1.Location = new System.Drawing.Point(49, 186);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(176, 33);
			this.comboBox1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(49, 313);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(48, 30);
			this.textBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(76, 547);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(169, 57);
			this.button1.TabIndex = 2;
			this.button1.UseVisualStyleBackColor = false;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBox1.Location = new System.Drawing.Point(386, 34);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(546, 588);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// PanelClientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(963, 655);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox1);
			this.Name = "PanelClientes";
			this.Text = "PanelClientes";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}