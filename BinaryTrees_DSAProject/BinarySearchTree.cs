using System;
using System.Collections.Generic;

namespace BST {
	internal class BinarySearchTree {
		private Node mRoot;

		/*
		 * Count number of data elements
		 */
		public Int32 getCount() {
			return this.levelOrderTraversal().Split(' ').Length;
		}
		/*
		 * Getter, setter is not needed.
		 */
		public Node getRoot() {
			return this.mRoot;
		}

		/*
		 * Simple ctor
		 */
		public BinarySearchTree(ref Int32 data) {
			this.mRoot = new Node(ref data);
		}
		public BinarySearchTree(Node root = null) {
			this.mRoot = root;
		}

		/*
		 * Simple insert node recursive function. Only adds unique values on correct positions
		 */
		private static void m_insertNode(ref Int32 data, ref Node parent) {
			if (parent == null) {
				parent = new Node(ref data);
			}
			else if (parent.m_getData() > data) {
				m_insertNode(ref data, ref parent.mLeft);
			}
			else if (parent.m_getData() < data) {
				m_insertNode(ref data, ref parent.mRight);
			}
			else if (parent.m_getData() == data) {
				return;
			}
		}
		/*
		 * Recursive function to find a node containing specified data
		 */
		private Node m_findNode(ref Int32 data, ref Node parent) {
			if (parent != null) {
				if (parent.m_getData() > data) {
					return this.m_findNode(ref data, ref parent.mLeft);
				}
				else {
					return parent.m_getData() < data ? this.m_findNode(ref data, ref parent.mRight) : parent;
				}
			}
			return null;
		}
		/*
		 * Get minimum of right subtree of self.
		 */
		private Node m_getMinimum(ref Node self) {
			if (self.mRight == null) {
				return self;
			}
			Node child = self.mRight;
			while (child.mLeft != null) {
				child = child.mLeft;
			}
			return child;
		}
		/*
		 * Find parent of a node 
		 */
		private Node m_getParent(ref Node self, ref Node find) {
			if (find != this.mRoot || self == null) {
				return null;
			}
			else {
				if (self.mLeft == find || self.mRight == find) {
					return self;
				}
				else {
					if (self.m_getData() < find.m_getData()) {
						return this.m_getParent(ref self.mRight, ref find);
					}
					else {
						return this.m_getParent(ref self.mLeft, ref find);
					}
				}
			}
		}
		/*
		 * Delete node function. If value to delete is found then from the certain value,
		 * 1) if there are no children: remove self
		 * 2) if there is one child, shift it up and remove self
		 * 3) if there are two children, get the min from right subtree and replace it with self
		 */
		private Node m_deleteNode(ref Int32 data, ref Node self) {
			if (self == null) {
				return self;
			}
			else if (data < self.m_getData()) {
				self.mLeft = this.m_deleteNode(ref data, ref self.mLeft);
			}
			else if (data > self.m_getData()) {
				self.mRight = this.m_deleteNode(ref data, ref self.mRight);
			}

			else {
				if (self.mLeft == null && self.mRight == null) {
					self = null;
					return self;
				}

				else if (self.mLeft == null) {
					self = self.mRight;
					return self;
				}
				else if (self.mRight == null) {
					self = self.mLeft;
					return self;
				}

				else {
					Int32 tData = this.m_getMinimum(ref self.mRight).m_getData();
					self.m_setData(ref tData);
					self.mRight = this.m_deleteNode(ref tData, ref self.mRight);
				}
			}
			return self;
		}

		/*
		 * As studied in class, simple traversal techniques
		 */
		private String m_inOrderTraversal(ref Node parent, ref String key) {
			if (parent == null) {
				return key;
			}
			if (parent.mLeft != null) {
				_ = this.m_inOrderTraversal(ref parent.mLeft, ref key);
			}

			key += " " + parent.m_getData();
			if (parent.mRight != null) {
				_ = this.m_inOrderTraversal(ref parent.mRight, ref key);
			}

			return key;
		}
		private String m_preOrderTraversal(ref Node parent, ref String key) {
			if (parent == null) {
				return key;
			}
			key += " " + parent.m_getData();
			if (parent.mLeft != null) {
				_ = this.m_preOrderTraversal(ref parent.mLeft, ref key);
			}
			if (parent.mRight != null) {
				_ = this.m_preOrderTraversal(ref parent.mRight, ref key);
			}
			return key;
		}
		private String m_postOrderTraversal(ref Node parent, ref String key) {
			if (parent == null) {
				return key;
			}
			if (parent.mLeft != null) {
				_ = this.m_postOrderTraversal(ref parent.mLeft,ref key);
			}
			if (parent.mRight != null) {
				_ = this.m_postOrderTraversal(ref parent.mRight, ref key);
			}
			key += " " + parent.m_getData();
			return key;
		}

		/*
		 * Level order traversing for saving tree data in files. Trees are always built by level orders
		 * So it only makes sense to rebuild a tree with level order traversed data when loading from file
		 */
		private String m_levelOrderTraversal(ref Node parent, ref String key) {
			Queue<Node> queue = new Queue<Node>(); // Make a simple queue
			queue.Enqueue(parent); // Add all the current level nodes
			while (queue.Count != 0) {
				Node temporary = queue.Dequeue(); // Dequeue the current root node of the tree.
				key += temporary.m_getData() + " "; // Put its data in the key string
				if (temporary.mLeft != null) {
					queue.Enqueue(temporary.mLeft); // Add the level-- level nodes
				}
				if (temporary.mRight != null) {
					queue.Enqueue(temporary.mRight); // Same as above
				}
			}
			return key;
		}


		/*
		 * Public functions to be accessed from outside. Traversal here starts from mRoot and 
		 * each function calls recursive selves with children
		 */
		public Node getParent(ref Node data) {
			return this.m_getParent(ref this.mRoot, ref data);
		}
		public String inOrderTraversal() {
			String key = "";
			return this.m_inOrderTraversal(ref this.mRoot, ref key);
		}
		public String preOrderTraversal() {
			String key = "";
			return this.m_preOrderTraversal(ref this.mRoot, ref key);
		}
		public String postOrderTraversal() {
			String key = "";
			return this.m_postOrderTraversal(ref this.mRoot, ref key);
		}
		public String levelOrderTraversal() {
			String key = "";
			return this.m_levelOrderTraversal(ref this.mRoot, ref key);
		}
		public Node getMinimum() {
			return this.m_getMinimum(ref this.mRoot);
		}
		public void insertNode(ref Int32 data) {
			m_insertNode(ref data, ref this.mRoot);
		}
		public Node findNode(ref Int32 data) {
			return this.m_findNode(ref data, ref this.mRoot);
		}
		public void deleteNode(ref Int32 data) { 
			_ = this.m_deleteNode(ref data, ref this.mRoot);
		}
	}
}
