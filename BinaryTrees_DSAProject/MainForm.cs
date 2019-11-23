using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT {
	public partial class MainForm : Form {
		public MainForm() {
			this.InitializeComponent();
		}

		private void MainForm_Load(Object sender, EventArgs e) {

		}

		private void InsertValue_TextChanged(Object sender, EventArgs e) {}

		private void InsertionButton_Click(Object sender, EventArgs e) {
			if (this.textBox1.Text == "") {
				return;
			}
			Int32 value = Convert.ToInt32(this.textBox1.Text);
			this.Tree.insertNode(ref value);
			this.textBox1.Text = "";
			this.richTextBox1.Text = this.Tree.PreOrderTraversal() + "\n" +
									 this.Tree.InOrderTraversal() + "\n" +
									 this.Tree.PostOrderTraversal() + "\n\n" + Tree.getCount();
		}
		
		private void InsertValue_KeyPress(Object sender, KeyPressEventArgs e) {
			Char insert = e.KeyChar;
			if (!(insert >= '0' && insert <= '9') && insert != 8 && insert != 46) {
				e.Handled = true;
			}
			if (insert == 13) {
				this.InsertionButton_Click(this, new EventArgs());
				e.Handled = true;
			}
		}

		private void PreOrderText_TextChanged(Object sender, EventArgs e) {

		}

		private void DeletionButton_Click(Object sender, EventArgs e) {
			if (this.textBox2.Text == "") {
				return;
			}
			Int32 value = Convert.ToInt32(this.textBox2.Text);
			this.Tree.deleteNode(ref value);
			this.textBox2.Text = "";
			this.richTextBox1.Text = this.Tree.PreOrderTraversal() + "\n" +
									 this.Tree.InOrderTraversal() + "\n" +
									 this.Tree.PostOrderTraversal() + "\n\n" + Tree.getCount();
		}

		private void DeletionValue_TextChanged(Object sender, EventArgs e) {}

		private void DeletionValue_KeyPress(Object sender, KeyPressEventArgs e) {
			Char insert = e.KeyChar;
			if (!(insert >= '0' && insert <= '9') && insert != 8 && insert != 46) {
				e.Handled = true;
			}
			if (insert == 13) {
				this.DeletionButton_Click(this, new EventArgs());
				e.Handled = true;
			}

		}

		private void preOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.PreOrderTraversal(), "PREORDER");
		}
		private void inOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.InOrderTraversal(), "INORDER");
		}
		private void postOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.PostOrderTraversal(), "POSTORDER");
		}
	}
}
