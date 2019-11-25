using System;
using System.Collections.Generic;

namespace BT {
	class BinaryTree {
		private Node mRoot;

		/*
		 * Count number of data elements
		 */
		public Int32 getCount() {
			return System.Text.RegularExpressions.Regex.Matches(this.InOrderTraversal(), @"((\w+(\s?)))").Count;
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
		public BinaryTree(Node root = null) {
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
		public Node m_deleteNode(ref Int32 data, ref Node self) {
			if (self == null) {
				return self;
			}
			if (data < self.m_getData()) {
				self.mLeft = this.m_deleteNode(ref data, ref self.mLeft);
			}
			else if (data > self.m_getData()) {
				self.mRight = this.m_deleteNode(ref data, ref self.mRight);
			}
			else {
				if (self.mLeft == null) {
					return self.mRight;
				}
				else if (self.mRight == null) {
					return self.mLeft;
				}
				Node selfRight = self.mRight;
				Int32 min = this.m_getMinimum(ref selfRight).m_getData();
				self.m_setData(min);
				self.mRight = this.m_deleteNode(ref min, ref selfRight);
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
		 * Public functions to be accessed from outside. Traversal here starts from mRoot and 
		 * each function calls recursive selves with children
		 */
		public Node getParent(ref Node data) {
			return this.m_getParent(ref this.mRoot, ref data);
		}
		public String InOrderTraversal() {
			String key = "";
			return this.m_inOrderTraversal(ref this.mRoot, ref key);
		}
		public String PreOrderTraversal() {
			String key = "";
			return this.m_preOrderTraversal(ref this.mRoot, ref key);
		}
		public String PostOrderTraversal() {
			String key = "";
			return this.m_postOrderTraversal(ref this.mRoot, ref key);
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
