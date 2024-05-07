using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorDraw {
	public partial class Group : Form {
		public Group() {
			InitializeComponent();
		}

		private void Group_Load(object sender, EventArgs e) {
			TreeView.Top = Menu.Bottom;
			TreeView.Left = 0;
		}

		private void Group_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = true;
		}

		private void Group_SizeChanged(object sender, EventArgs e) {
			TreeView.Width = Width - 16;
			TreeView.Height = Height - Menu.Height - 41;
		}

		private void MenuItem_EditAdd_Click(object sender, EventArgs e) {
			TreeView.Nodes.Add(new TreeNode($"Group{TreeView.Nodes.Count}"));
		}

		private void MenuItem_EditDel_Click(object sender, EventArgs e) {
			if (null != TreeView.SelectedNode) {
				TreeView.Nodes.Remove(TreeView.SelectedNode);
			}
		}
	}
}
