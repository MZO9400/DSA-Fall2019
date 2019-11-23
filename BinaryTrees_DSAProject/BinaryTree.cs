using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT {
	class BinaryTree {
		private Node mRoot;
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
		private Node m_findNode(ref Int32 data, ref Node parent) {
			if (parent.m_getData() > data) {
				return this.m_findNode(ref data, ref parent.mLeft);
			}
			else {
				return parent.m_getData() < data ? this.m_findNode(ref data, ref parent.mRight) : parent;
			}
		}
		private Node m_getMinimum(ref Node parent) {
			return parent == null ? parent : this.m_getMinimum(ref parent.mLeft);
		}
		private Node m_getParent(ref Node self, ref Node find) {
			if (find != this.mRoot || self == null) {
				return null;
			}
			else {
				if (self.mLeft == find || self.mRight == find)
					return self;
				else {
					if (self.m_getData() < find.m_getData()) {
						return m_getParent(ref self.mRight, ref find);
					}
					else {
						return m_getParent(ref self.mLeft, ref find);
					}
				}
			}
		}
		public void m_deleteNode(ref Int32 data) {
			Node current = mRoot;
			Node parent = mRoot;
			bool isLeftChild = false;

			if (mRoot == null) {
				return;
			}

			while (current != null && current.m_getData() != data) {
				parent = current;

				if (data < current.m_getData()) {
					current = current.mLeft;
					isLeftChild = true;
				}
				else {
					current = current.mRight;
					isLeftChild = false;
				}
			}

			if (current == null) {
				return;
			}

			if (current.mRight == null && current.mLeft == null) {
				if (current == mRoot) {
					mRoot = null;
				}
				else {
					if (isLeftChild) {
						parent.mLeft = null;
					}
					else {
						parent.mRight = null;
					}
				}
			}
			else if (current.mRight == null)
			{
				if (current == mRoot) {
					mRoot = current.mLeft;
				}
				else {
					if (isLeftChild)
					{
						parent.mLeft = current.mLeft;
					}
					else {
						parent.mRight = current.mLeft;
					}
				}
			}
			else if (current.mLeft == null) 
		   {
				if (current == mRoot) {
					mRoot = current.mRight;
				}
				else {
					if (isLeftChild) {
						parent.mLeft = current.mRight;
					}
					else {   
						parent.mRight = current.mRight;
					}
				}
			}
			else
			{	
				Node successor = m_getMinimum(ref current.mRight);
				
				if (current == mRoot) {
					mRoot = successor;
				}
				else if (isLeftChild) {
					parent.mLeft = successor;
				}
				else {
					parent.mRight = successor;
				}

			}

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
				_ = this.m_postOrderTraversal(ref parent.mLeft, ref key);
			}
			if (parent.mRight != null) {
				_ = this.m_postOrderTraversal(ref parent.mRight, ref key);
			}
			key += " " + parent.m_getData();
			return key;
		}

		public Node getParent(ref Node data) {
			return m_getParent(ref mRoot, ref data);
		}
		public String InOrderTraversal() {
			String value = "";
			return this.m_inOrderTraversal(ref this.mRoot, ref value);
		}
		public String PreOrderTraversal() {
			String value = "";
			return this.m_preOrderTraversal(ref this.mRoot, ref value);
		}
		public String PostOrderTraversal() {
			String value = "";
			return this.m_postOrderTraversal(ref this.mRoot, ref value);
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
			this.m_deleteNode(ref data);
		}
	}
}
