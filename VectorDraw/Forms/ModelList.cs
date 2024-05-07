using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Geometry;

namespace VectorDraw.Forms {
	public partial class ModelList : Form {
		static ModelList mInstance;

		List<Model> mModelList;
		List<Layer> mLayerList;
		Model mCurrentModel;
		Group mCurrentGroup;
		bool mValueChanged = false;
		bool mChangeEventStopped = false;

		public static void Open(List<Model> modelList, List<Layer> layerList, Point pos) {
			if (null == mInstance) {
				mInstance = new ModelList(modelList, layerList);
				mInstance.Show();
				mInstance.Location = pos;
			}
		}

		private ModelList(List<Model> modelList, List<Layer> layerList) {
			InitializeComponent();
			mModelList = modelList;
			mLayerList = layerList;
		}

		private void ModelList_Load(object sender, EventArgs e) {
			SetLayout();
			SetList();
			timer1.Interval = 200;
			timer1.Enabled = true;
			timer1.Start();
		}

		private void ModelList_FormClosed(object sender, FormClosedEventArgs e) {
			mInstance = null;
		}

		private void ModelList_SizeChanged(object sender, EventArgs e) {
			SetLayout();
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
			mChangeEventStopped = true;
			if (e.Node.Tag is Model model) {
				mCurrentModel = model;
				mCurrentGroup = null;
				txtName.Text = model.Name;
				cmbLayer.Items.Clear();
				cmbLayer.Enabled = false;
				numPix.Enabled = false;
				numScale.Enabled = false;
			}
			if (e.Node.Tag is Group group) {
				mCurrentModel = (Model)e.Node.Parent.Tag;
				mCurrentGroup = group;
				MainForm.CurrentGroup = group;
				txtName.Text = group.Name;
				numPix.Value = group.Pix;
				numScale.Value = (decimal)group.Scale;
				cmbLayer.Items.Clear();
				foreach(var l in mLayerList) {
					cmbLayer.Items.Add(l.Name);
				}
				cmbLayer.SelectedItem = group.Layer.Name;
				cmbLayer.Enabled = true;
				numPix.Enabled = true;
				numScale.Enabled = true;
			}
			mChangeEventStopped = false;
		}

		private void txtName_TextChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void numPix_ValueChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void numScale_ValueChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			if (!mValueChanged) {
				return;
			}
			mValueChanged = false;
			if (null == mCurrentGroup) {
				mCurrentModel.Name = txtName.Text;
			}
			else {
				mCurrentGroup.Name = txtName.Text;
				mCurrentGroup.Layer = mLayerList[mLayerList.FindIndex((layer) =>
					(string)cmbLayer.SelectedItem == layer.Name
				)];
				mCurrentGroup.Pix = (int)numPix.Value;
				mCurrentGroup.Scale = (double)numScale.Value;
			}
			mChangeEventStopped = true;
			SetList();
			mChangeEventStopped = false;
		}

		private void モデル追加ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!treeView1.Focused) {
				return;
			}
			mCurrentModel = Model.Add(mModelList);
			SetList();
		}

		private void グループ追加ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!treeView1.Focused) {
				return;
			}
			if (null == mCurrentModel) {
				return;
			}
			mCurrentGroup = Group.Add(mCurrentModel, mLayerList[0]);
			SetList();
		}

		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!treeView1.Focused) {
				return;
			}
			var node = GetSelectedNode();
			if (null == node) {
				return;
			}
			if (node.Tag is Model model) {
				mModelList.Remove(model);
			}
			if (node.Tag is Group group) {
				mCurrentModel.Groups.Remove(group);
			}
			treeView1.Nodes.Remove(node);
		}

		private void コピーToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!treeView1.Focused) {
				return;
			}
		}

		private void 貼り付けToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!treeView1.Focused) {
				return;
			}
			SetList();
		}

		void SetLayout() {
			const int PanelWidth = 200;
			treeView1.Top = menuStrip1.Bottom;
			treeView1.Left = 0;
			treeView1.Width = Width - PanelWidth - 16;
			treeView1.Height = Height - menuStrip1.Bottom - 39;
			treeView1.Scrollable = true;
			panel1.Top = menuStrip1.Bottom;
			panel1.Left = treeView1.Right;
			panel1.Width = PanelWidth;
			panel1.Height = treeView1.Height;
		}

		TreeNode GetSelectedNode() {
			TreeNode selectedNode = null;
			foreach (TreeNode o in treeView1.Nodes) {
				if (o.Tag == mCurrentModel) {
					selectedNode = o;
				}
				foreach (TreeNode g in o.Nodes) {
					if (g.Tag == mCurrentGroup) {
						selectedNode = g;
					}
				}
			}
			return selectedNode;
		}

		void SetList() {
			treeView1.SuspendLayout();
			treeView1.Nodes.Clear();
			foreach (var o in mModelList) {
				var nodeObj = new TreeNode() {
					Text = o.Name,
					Tag = o
				};
				foreach (var g in o.Groups) {
					var nodeGrp = new TreeNode() {
						Text = $"{g.Name}[{g.Layer.Name}]",
						Tag = g
					};
					nodeObj.Nodes.Add(nodeGrp);
				}
				treeView1.Nodes.Add(nodeObj);
			}
			treeView1.ExpandAll();
			treeView1.SelectedNode = GetSelectedNode();
			treeView1.ResumeLayout(false);
		}
	}
}
