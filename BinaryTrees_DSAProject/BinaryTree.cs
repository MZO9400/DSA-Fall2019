using System;
using System.Collections.Generic;

namespace BT {
	class BinaryTree {
		private Node mRoot;
		public Int32 getCount() {
			return System.Text.RegularExpressions.Regex.Matches(this.InOrderTraversal(), @"((\w+(\s?)))").Count;
		}
		public Node getRoot() {
			return this.mRoot;
		}
		public BinaryTree(Node root = null) {
			this.mRoot = root;
		}
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

		internal List<Int32> getValues(String v) {
			throw new NotImplementedException();
		}

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
		public Node m_deleteNode(ref Int32 data, ref Node self) {
			if (this.findNode(ref data) == this.mRoot) { 
				this.mRoot = null;
				return null;
			}
			if (this.mRoot.mLeft == null && this.mRoot.mRight == null) {
				this.mRoot = null;
				return null;
			}
			if (self == null) {
				return null;
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

		public List<Int32> getValues(Func<Node, String> traverse) {
			List<String> tempList = new List<String> (traverse(this.mRoot).Split(' '));
			List<Int32> finalList = new List<Int32>();
			foreach (String i in tempList) {
				finalList.Add(Int32.Parse(i));
			}
			return finalList;
		}
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
