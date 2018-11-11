using System.Drawing;

namespace Allers
{
	partial class PanelMenu
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
			System.Windows.Forms.Button button1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelMenu));
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			button1.BackColor = System.Drawing.Color.Transparent;
			button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
			button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.ForeColor = System.Drawing.Color.Transparent;
			button1.Location = new System.Drawing.Point(92, 220);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(126, 133);
			button1.TabIndex = 0;
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
			this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.ForeColor = System.Drawing.Color.Transparent;
			this.button2.Location = new System.Drawing.Point(399, 220);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(135, 133);
			this.button2.TabIndex = 1;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
			this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.ForeColor = System.Drawing.Color.Transparent;
			this.button3.Location = new System.Drawing.Point(92, 488);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(125, 136);
			this.button3.TabIndex = 2;
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
			this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.Transparent;
			this.button4.Location = new System.Drawing.Point(399, 487);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(124, 137);
			this.button4.TabIndex = 3;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// PanelMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(963, 655);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(button1);
			this.Name = "PanelMenu";
			this.Text = "PanelMenu";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PanelMenu_FormClosed);
			this.Load += new System.EventHandler(this.PanelMenu_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}