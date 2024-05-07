using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorDraw {
	public partial class Main : Form {
		private readonly Group Layer = new Group();
		private readonly int OfsWidth;
		private readonly int OfsHeight;
		private const int RulerWidth = 20;

		private bool Mouse;
		private Point MousePos;
		private Graphics Front;
		private Graphics Back;

		public Main() {
			InitializeComponent();
			OfsWidth = vScrollBar.Width + 16;
			OfsHeight = hScrollBar.Height + Menu.Bottom + 41;
			PictureBox.Left = 0;
			hScrollBar.Left = 0;
			PictureBox.Top = Menu.Bottom;
			vScrollBar.Top = Menu.Bottom;
		}

		private void Main_Load(object sender, EventArgs e) {
			Timer.Interval = 16;
			Timer.Start();
			Main_SizeChanged();
		}

		private void Main_Shown(object sender, EventArgs e) {
			Layer.StartPosition = FormStartPosition.CenterParent;
			Layer.Show();
		}

		private void Main_SizeChanged(object sender = null, EventArgs e = null) {
			if (Width <= OfsWidth || Height <= OfsHeight) {
				return;
			}

			var width = Width - OfsWidth;
			var height = Height - OfsHeight;
			PictureBox.Width = width;
			PictureBox.Height = height;
			vScrollBar.Left = PictureBox.Right;
			vScrollBar.Height = PictureBox.Height;
			hScrollBar.Top = PictureBox.Bottom;
			hScrollBar.Width = PictureBox.Width;

			if (null != Front) {
				Front.Dispose();
				Front = null;
			}
			if (null != Back) {
				Back.Dispose();
				Back = null;
			}
			if (null != PictureBox.Image) {
				PictureBox.Image.Dispose();
				PictureBox.Image = null;
			}
			if (null != PictureBox.BackgroundImage) {
				PictureBox.BackgroundImage.Dispose();
				PictureBox.BackgroundImage = null;
			}
			PictureBox.Image = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
			PictureBox.BackgroundImage = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
			Front = Graphics.FromImage(PictureBox.Image);
			Back = Graphics.FromImage(PictureBox.BackgroundImage);

			UpdateBack();
			UpdateFront();
		}

		#region メニューイベント(ファイル)
		private void Menu_File_New_Click(object sender, EventArgs e) {

		}

		private void Menu_File_Open_Click(object sender, EventArgs e) {

		}

		private void Menu_File_Save_Click(object sender, EventArgs e) {

		}

		private void Menu_File_SaveAs_Click(object sender, EventArgs e) {

		}
		#endregion

		#region メニューイベント(編集)
		private void Menu_Edit_Undo_Click(object sender, EventArgs e) {

		}

		private void Menu_Edit_Redo_Click(object sender, EventArgs e) {

		}

		private void Menu_Edit_Cut_Click(object sender, EventArgs e) {

		}

		private void Menu_Edit_Copy_Click(object sender, EventArgs e) {

		}

		private void Menu_Edit_Paste_Click(object sender, EventArgs e) {

		}

		private void Menu_Edit_SelectGroup_Click(object sender, EventArgs e) {

		}
		#endregion

		#region メニューイベント(表示)
		private void Menu_Display_ZoomIn_Click(object sender, EventArgs e) {

		}

		private void Menu_Display_ZoomOut_Click(object sender, EventArgs e) {

		}

		private void Menu_Display_Zoom100_Click(object sender, EventArgs e) {

		}
		#endregion

		#region ピクチャーボックスイベント
		private void PictureBox_MouseEnter(object sender, EventArgs e) {
			Mouse = true;
		}

		private void PictureBox_MouseLeave(object sender, EventArgs e) {
			Mouse = false;
		}

		private void PictureBox_MouseMove(object sender, MouseEventArgs e) {
			MousePos = e.Location;
		}
		#endregion

		private void Timer_Tick(object sender, EventArgs e) {
			UpdateFront();
		}

		private void UpdateBack() {
			Back.Clear(Color.Black);
			Back.FillRectangle(Brushes.Gray, 0, RulerWidth, RulerWidth, vScrollBar.Height - RulerWidth);
			Back.FillRectangle(Brushes.Gray, RulerWidth, 0, hScrollBar.Width - RulerWidth, RulerWidth);
			PictureBox.BackgroundImage = PictureBox.BackgroundImage;
		}

		private void UpdateFront() {
			Front.Clear(Color.Transparent);
			Front.FillEllipse(Brushes.Red, MousePos.X - 4, MousePos.Y - 4, 8, 8);
			Front.DrawLine(Pens.Red, MousePos.X, 0, MousePos.X, PictureBox.Height);
			Front.DrawLine(Pens.Red, 0, MousePos.Y, PictureBox.Width, MousePos.Y);
			PictureBox.Image = PictureBox.Image;
		}
	}
}
