using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Geometry;

namespace VectorDraw.Forms {
	public partial class LayerList : Form {
		static LayerList mInstance;

		List<Layer> mList;
		Layer mCurrent;
		bool mValueChanged = false;
		bool mChangeEventStopped = false;

		public static void Open(List<Layer> list, Point pos) {
			if (null == mInstance) {
				mInstance = new LayerList(list);
				mInstance.Show();
				mInstance.Location = pos;
			}
		}

		private LayerList(List<Layer> list) {
			InitializeComponent();
			mList = list;
		}

		private void ObjectList_Load(object sender, EventArgs e) {
			SetLayout();
			SetList();
			timer1.Interval = 200;
			timer1.Enabled = true;
			timer1.Start();
		}

		private void LayerList_FormClosed(object sender, FormClosedEventArgs e) {
			mInstance = null;
		}

		private void ObjectList_SizeChanged(object sender, EventArgs e) {
			SetLayout();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
			if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex >= mList.Count) {
				mCurrent = null;
				return;
			}
			mChangeEventStopped = true;
			mCurrent = mList[listBox1.SelectedIndex];
			txtName.Text = mCurrent.Name;
			numDepth.Value = (decimal)mCurrent.Depth;
			mChangeEventStopped = false;
		}

		private void txtName_TextChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void numDepth_ValueChanged(object sender, EventArgs e) {
			mValueChanged = !mChangeEventStopped;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			if (!mValueChanged) {
				return;
			}
			mValueChanged = false;
			if (null != mList.Find((l) => l.Name == txtName.Text && l != mCurrent)) {
				txtName.ForeColor = Color.Red;
				return;
			}
			txtName.ForeColor = Color.Black;
			mCurrent.Name = txtName.Text;
			mCurrent.Depth = (double)numDepth.Value;
			mChangeEventStopped = true;
			SetList();
			mChangeEventStopped = false;
		}

		private void 追加ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!listBox1.Focused) {
				return;
			}
			mCurrent = Layer.Add(mList);
			SetList();
		}

		private void 削除ToolStripMenuItem_Click(object sender, EventArgs e) {
			if (!listBox1.Focused) {
				return;
			}
			if (null == mCurrent) {
				return;
			}
			mList.Remove(mCurrent);
			SetList();
		}

		void SetLayout() {
			const int PanelWidth = 200;
			listBox1.Top = menuStrip1.Bottom;
			listBox1.Left = 0;
			listBox1.Width = Width - PanelWidth - 16;
			listBox1.Height = Height - menuStrip1.Bottom - 39;
			panel1.Top = menuStrip1.Bottom;
			panel1.Left = listBox1.Right;
			panel1.Width = PanelWidth;
			panel1.Height = listBox1.Height;
		}

		void SetList() {
			listBox1.Items.Clear();
			object selectedObj = null;
			foreach(var l in mList) {
				var strLayer = $"[{l.Depth.ToString("+0.00;-0.00; 0.00")}] {l.Name}";
				listBox1.Items.Add(strLayer);
				if (l == mCurrent) {
					selectedObj = strLayer;
				}
			}
			listBox1.SelectedItem = selectedObj;
		}
	}
}
