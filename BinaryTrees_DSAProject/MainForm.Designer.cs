﻿namespace BT {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(1034, 419);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(65, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.TextChanged += new System.EventHandler(this.InsertValue_TextChanged);
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InsertValue_KeyPress);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Location = new System.Drawing.Point(1034, 445);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(65, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Insert";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.InsertionButton_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button2.Location = new System.Drawing.Point(963, 445);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(65, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.DeletionButton_Click);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(963, 419);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(64, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.TextChanged += new System.EventHandler(this.DeletionValue_TextChanged);
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DeletionValue_KeyPress);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button3.Location = new System.Drawing.Point(37, 445);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Preorder";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.preOrderButton_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button4.Location = new System.Drawing.Point(118, 445);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "Inorder";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.inOrderButton_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button5.Location = new System.Drawing.Point(199, 445);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 7;
			this.button5.Text = "Postorder";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.postOrderButton_Click);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(1136, 480);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.MinimumSize = new System.Drawing.Size(500, 250);
			this.Name = "MainForm";
			this.Text = "Binary Tree";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private BT.BinaryTree Tree;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
	}
}

