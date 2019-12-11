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
namespace BST {
	public partial class MainForm : Form {
		public MainForm() {
			// Initialize my tree here
			this.Tree = new BinarySearchTree();
			this.InitializeComponent();
		}

		private void mainForm_Load(Object sender, EventArgs e) {

		}
		/*
		 * Build a blob from self->data at width (x), and height (y).
		 */
		private async Task<Int32> makeBlob(Node self, Single width, Int32 height) {
			if (self == null) {
				return await Task.FromResult(1);
			}
			this.Controls.Add(
				new System.Windows.Forms.Label {
					AutoSize = true,
					Anchor = AnchorStyles.Top | AnchorStyles.Bottom,
					ForeColor = Color.Black,
					Location = new System.Drawing.Point((Int32) (width / 2), height),
					Name = "Blob" + (width / 2).ToString(), // Key "Blob" added here to keep track of labels
					Size = new System.Drawing.Size(35, 13),
					TabIndex = 8,
					Text = self.m_getData().ToString(),
					BorderStyle = BorderStyle.FixedSingle,
					Padding = new Padding(8)
				}
			);
			return await Task.FromResult(0);
		}
		/*
		 * Before re-adding new controls and labels, remove all old labels which contain key "Blob"
		 */
		private void removeOldControls() {
			this.Invalidate();
			this.Update();
			for (Int32 i = this.Controls.Count - 1; i != 0; i--) {
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
			this.m_drawBoxesHelper(this.Tree.getRoot(), (Single) this.Width, 100, level, false);
		}
		/*
		 * Helper function that changes values for each node depending on its level. The differences between levels is 0.05F times width
		 * Width differences is width +- 50 * level, whereas height difference is 75 on each level. Stop changing level if it reaches 1.0F
		 * So the nodes do not retract beyond their valid positions
		 */
		private async void m_drawBoxesHelper(Node current, Single width, Int32 height, Single level, Boolean isLeft) {
			if (current != null) {
				Graphics line = this.CreateGraphics();
				if (level != 1.2F) {
					if (isLeft == true) {
						line.DrawLine(Pens.Black, width / 2, height,
							(width + 150 + (((width - 50) * (level + 0.05F)) - (width - 50))) / 2,
							height - 75);
					}
					else {
						line.DrawLine(Pens.Black, width / 2, height,
							(width + 50 - (((width - 50) * (level + 0.05F)) - (width - 50))) / 2,
							height - 75);
					}
				}
				_ = await this.makeBlob(current, width, height);
			}
			else {
				return;
			}
			if (current.mLeft != null) {
				this.m_drawBoxesHelper(current.mLeft, width - 50 - (((width - 50) * level) - (width - 50)),
					height + 75, level - (level > 1.0F ? (Single) 0.05 : 0), true);
			}

			if (current.mRight != null) {
				this.m_drawBoxesHelper(current.mRight, width + 50 + (((width - 50) * level) - (width - 50)),
					height + 75, level - (level > 1.0F ? (Single) 0.05 : 0), false);
			}
		}
		private void insertValue_TextChanged(Object sender, EventArgs e) { }

		/*
		 * Upon clicking the insert button, set the text to null and convert the value into an integer and push into nodes
		 */
		private void insertionButton_Click(Object sender, EventArgs e) {
			if (this.textBox1.Text == "") {
				return;
			}
			for (Int32 i = 1; i < this.textBox1.Text.Length; i++) {
				if (this.textBox1.Text[i] == '-') {
					this.textBox1.Text = this.textBox1.Text.Remove(i, 1);
				}
			}
			Int32 value = Convert.ToInt32(this.textBox1.Text);
			this.Tree.insertNode(ref value);
			this.textBox1.Text = "";
			this.drawBlobs();
		}
		/*
		 * Allow only numbers, backspace, enter, and some other special characters
		 */
		private void insertValue_KeyPress(Object sender, KeyPressEventArgs e) {
			Char insert = e.KeyChar;
			if (!(insert >= '0' && insert <= '9') && insert != 8 && insert != 46 && insert != '-') {
				e.Handled = true;
			}
			/*
			 * Enter (13) adds the current value into Tree
			 */
			if (insert == 13) {
				this.insertionButton_Click(this, new EventArgs());
				e.Handled = true;
			}
		}
		/*
		 * Same happens with delete button. Value is converted from String to Int32 and removed from Tree
		 */
		private void deletionButton_Click(Object sender, EventArgs e) {
			if (this.textBox2.Text == "") {
				return;
			}
			for (Int32 i = 1; i < this.textBox2.Text.Length; i++) {
				if (this.textBox2.Text[i] == '-') {
					this.textBox2.Text = this.textBox2.Text.Remove(i, 1);
				}
			}
			Int32 value = Convert.ToInt32(this.textBox2.Text);
			this.Tree.deleteNode(ref value);
			this.textBox2.Text = "";
			this.drawBlobs();
		}

		private void deletionValue_TextChanged(Object sender, EventArgs e) { }

		/*
		 * Simple as before
		 */
		private void deletionValue_KeyPress(Object sender, KeyPressEventArgs e) {
			Char insert = e.KeyChar;
			if (!(insert >= '0' && insert <= '9') && insert != 8 && insert != 46 && insert != '-') {
				e.Handled = true;
			}
			if (insert == 13) {
				this.deletionButton_Click(this, new EventArgs());
				e.Handled = true;
			}

		}
		/*
		 * Buttons which show popups printing certain orders of tree traversal
		 */
		private void preOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.preOrderTraversal(), "PREORDER");
		}
		private void inOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.inOrderTraversal(), "INORDER");
		}
		private void postOrderButton_Click(Object sender, EventArgs e) {
			_ = MessageBox.Show(this.Tree.postOrderTraversal(), "POSTORDER");
		}

		private void reset_Click(Object sender, EventArgs e) {
			this.Tree = new BST.BinarySearchTree();
			this.removeOldControls();
			GC.Collect();
		}

		private void loadButton_Click(Object sender, EventArgs e) {
			if (DialogResult.OK == this.loadTree.ShowDialog()) {
				String text = System.IO.File.ReadAllText(this.loadTree.FileName);
				this.reset_Click(this, new EventArgs());
				String[] textArray = text.Split(' ');
				foreach (String item in textArray) {
					if (!Int32.TryParse(item, out Int32 toInsert)) {
						continue;
					}
					this.Tree.insertNode(ref toInsert);
				}
			}
			this.drawBlobs();
		}

		private void saveButton_Click(Object sender, EventArgs e) {
			if (DialogResult.OK == this.saveTree.ShowDialog()) {
				System.IO.File.WriteAllText(this.saveTree.FileName, this.Tree.levelOrderTraversal());
			}
		}

	}
}