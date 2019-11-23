using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT {
	class Node {
		public Node mLeft;
		public Node mRight;
		private Int32 mData;
		public Node(ref Int32 data, Node left = null, Node right = null) {
			this.mData = data;
			this.mLeft = left;
			this.mRight = right;
		}
		public void m_setData(Int32 data) {
			this.mData = data;
		}
		public Int32 m_getData() {
			return this.mData;
		}
	}
}
