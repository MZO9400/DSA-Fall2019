using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * Self written Form class, this is the front-end GUI and handling functions
 */
namespace BT {
	public partial class MainForm : Form {
		public MainForm() {
			// Initialize my tree here
			this.Tree = new BinaryTree();
			this.InitializeComponent();
		}

		private void MainForm_Load(Object sender, EventArgs e) {

		}
		/*
		 * Build a blob from self->data at width (x), and height (y).
		 */
		private void makeBlob(Node self, Single width, Int32 height) {
			if (self == null) { 
				return;
			}
			this.Controls.Add(
				new System.Windows.Forms.Label {
					AutoSize = true,
					Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
					ForeColor = Color.Black,
					Location = new System.Drawing.Point((Int32)(width / 2), height),
					Name = "Blob" + (width / 2).ToString(), // Key "Blob" added here to keep track of labels
					Size = new System.Drawing.Size(35, 13),
					TabIndex = 8,
					Text = self.m_getData().ToString(),
					BorderStyle = BorderStyle.FixedSingle,
					Padding = new Padding(8)
				}
			);
		}
		/*
		 * Before re-adding new controls and labels, remove all old labels which contain key "Blob"
		 */
		private void removeOldControls() {
			for (Int32 i = 0; i < this.Controls.Count; i++) {
				if (this.Controls[i] is Label) { // Match data-type
					if (this.Controls[i].Name.Contains("Blob")) {
						this.Controls[i].Dispose();
					}
				}
			}
		}
		/*
		 * This function is called whenever a new value is added or removed, this redraws the graphics with new tree
		 * Height starts from 100, an Int32. Whereas width starts from maximum value of width (max X axis), drawing
		 * starts from Tree->mRoot. Level is used as a multiplier to prevent overlapping of complex nodes
		 */
		private void drawBlobs() {
			this.removeOldControls();
			Single level = 1.2F;
			this.m_drawBoxesHelper(this.Tree.getRoot(), (Single) this.Width, 100, level);
		}
		/*
		 * Helper function that changes values for each node depending on its level. The differences between levels is 0.05F times width
		 * Width differences is width +- 50 * level, whereas height difference is 75 on each level. Stop changing level if it reaches 1.0F
		 * So the nodes do not retract beyond their valid positions
		 */
		private void m_drawBoxesHelper(Node current, Single width, Int32 height, Single level) {
			if (current != null) {
				this.makeBlob(current, width, height);
			}
			else {
				return;
			}
			if (current.mLeft != null) {
				this.m_drawBoxesHelper(current.mLeft, width - 50 - (((width - 50) * level) - (width - 50)), height + 75, level - (level > 1.0F ? (Single) 0.05 : 0));
			}

			if (current.mRight != null) {
				this.m_drawBoxesHelper(current.mRight, width + 50 + (((width - 50) * level) - (width - 50)), height + 75, level - (level > 1.0F ? (Single) 0.05 : 0));
			}
		}
		private void InsertValue_TextChanged(Object sender, EventArgs e) {}

		/*
		 * Upon clicking the insert button, set the text to null and convert the value into an integer and push into nodes
		 */
		private void InsertionButton_Click(Object sender, EventArgs e) {
			if (this.textBox1.Text == "") {
				return;
			}
			Int32 value = Convert.ToInt32(this.textBox1.Text);
			this.Tree.insertNode(ref value);
			this.textBox1.Text = "";
			drawBlobs();
		}
		/*
		 * Allow only numbers, backspace, enter, and some other special characters
		 */
		private void InsertValue_KeyPress(Object sender, KeyPressEventArgs e) {
			Char insert = e.KeyChar;
			if (!(insert >= '0' && insert <= '9') && insert != 8 && insert != 46) {
				e.Handled = true;
			}
			/*
			 * Enter (13) adds the current value into Tree
			 */
			if (insert == 13) {
				this.InsertionButton_Click(this, new EventArgs());
				e.Handled = true;
			}
		}
		/*
		 * Same happens with delete button. Value is converted from String to Int32 and removed from Tree
		 */
		private void DeletionButton_Click(Object sender, EventArgs e) {
			if (this.textBox2.Text == "") {
				return;
			}
			Int32 value = Convert.ToInt32(this.textBox2.Text);
			this.Tree.deleteNode(ref value);
			this.textBox2.Text = "";
			drawBlobs();
		}

		private void DeletionValue_TextChanged(Object sender, EventArgs e) {}
		
		/*
		 * Simple as before
		 */
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
		/*
		 * Buttons which show popups printing certain orders of tree traversal
		 */
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
