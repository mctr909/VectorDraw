using System;
using System.Windows.Forms;

namespace VectorDraw.Forms {
	public partial class GridSettings : Form {
		MainForm.GridValues mParent;

		public GridSettings(MainForm.GridValues values) {
			InitializeComponent();
			mParent = values;
			numPix.Value = mParent.Pix;
			numScale.Value = (decimal)mParent.Scale;
		}

		private void btnApply_Click(object sender, EventArgs e) {
			mParent.Pix = (int)numPix.Value;
			mParent.Scale = (double)numScale.Value;
			Close();
		}
	}
}
