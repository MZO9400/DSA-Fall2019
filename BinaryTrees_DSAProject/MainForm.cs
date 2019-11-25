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
			this.Tree = new BinaryTree();
			this.InitializeComponent();
		}

		private void MainForm_Load(Object sender, EventArgs e) {

		}
		private void makeBlob(Node self, Int32 width, Int32 height) {
			if (self == null) { 
				return;
			}
			this.Controls.Add(
				new System.Windows.Forms.Label {
					AutoSize = true,
					Anchor = (AnchorStyles.Top | AnchorStyles.Bottom),
					ForeColor = Color.White,
					Location = new System.Drawing.Point(width / 2, height),
					Name = "Blob" + (width / 2).ToString(),
					Size = new System.Drawing.Size(35, 13),
					TabIndex = 8,
					Text = self.m_getData().ToString(),
					BorderStyle = BorderStyle.FixedSingle,
					Padding = new Padding(8)
				}
			);
		}
		private void removeOldControls() {
			for (Int32 i = 0; i < this.Controls.Count; i++) {
				if (this.Controls[i] is Label) {
					if (this.Controls[i].Name.Contains("Blob")) {
						this.Controls[i].Dispose();
					}
				}
			}
		}
		private void drawBlobs() {
			this.removeOldControls();
			this.m_drawBoxesHelper(this.Tree.getRoot(), this.Width, 100);
		}
		private void m_drawBoxesHelper(Node current, Int32 width, Int32 height) {
			if (current != null) {
				this.makeBlob(current, width, height);
			}
			else {
				return;
			}
			if (current.mLeft != null) {
				this.m_drawBoxesHelper(current.mLeft, width - 100, height + 100);
			}

			if (current.mRight != null) {
				this.m_drawBoxesHelper(current.mRight, width + 100, height + 100);
			}
		}
		private void InsertValue_TextChanged(Object sender, EventArgs e) {}

		private void InsertionButton_Click(Object sender, EventArgs e) {
			if (this.textBox1.Text == "") {
				return;
			}
			Int32 value = Convert.ToInt32(this.textBox1.Text);
			this.Tree.insertNode(ref value);
			this.textBox1.Text = "";
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
		private void DrawBlobs_Click(Object sender, EventArgs e) {
			this.drawBlobs();
		}

	}
}
