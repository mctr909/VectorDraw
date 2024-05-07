namespace VectorDraw {
	partial class Main {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.Menu = new System.Windows.Forms.MenuStrip();
			this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_New = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Menu_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Menu_File_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_File_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Edit_Undo = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Edit_Redo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Menu_Edit_Cut = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Edit_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Edit_Paste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.Menu_Edit_SelectGroup = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Display = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Display_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Display_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
			this.Menu_Display_Zoom100 = new System.Windows.Forms.ToolStripMenuItem();
			this.vScrollBar = new System.Windows.Forms.VScrollBar();
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.PictureBox = new System.Windows.Forms.PictureBox();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.Menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Edit,
            this.Menu_Display});
			this.Menu.Location = new System.Drawing.Point(0, 0);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(272, 24);
			this.Menu.TabIndex = 0;
			this.Menu.Text = "menuStrip1";
			// 
			// Menu_File
			// 
			this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_New,
            this.toolStripSeparator1,
            this.Menu_File_Open,
            this.toolStripSeparator2,
            this.Menu_File_Save,
            this.Menu_File_SaveAs});
			this.Menu_File.Name = "Menu_File";
			this.Menu_File.Size = new System.Drawing.Size(67, 20);
			this.Menu_File.Text = "ファイル(F)";
			// 
			// Menu_File_New
			// 
			this.Menu_File_New.Name = "Menu_File_New";
			this.Menu_File_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.Menu_File_New.Size = new System.Drawing.Size(184, 22);
			this.Menu_File_New.Text = "新規作成(N)";
			this.Menu_File_New.Click += new System.EventHandler(this.Menu_File_New_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
			// 
			// Menu_File_Open
			// 
			this.Menu_File_Open.Name = "Menu_File_Open";
			this.Menu_File_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.Menu_File_Open.Size = new System.Drawing.Size(184, 22);
			this.Menu_File_Open.Text = "開く(O)";
			this.Menu_File_Open.Click += new System.EventHandler(this.Menu_File_Open_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
			// 
			// Menu_File_Save
			// 
			this.Menu_File_Save.Name = "Menu_File_Save";
			this.Menu_File_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.Menu_File_Save.Size = new System.Drawing.Size(184, 22);
			this.Menu_File_Save.Text = "上書き保存(S)";
			this.Menu_File_Save.Click += new System.EventHandler(this.Menu_File_Save_Click);
			// 
			// Menu_File_SaveAs
			// 
			this.Menu_File_SaveAs.Name = "Menu_File_SaveAs";
			this.Menu_File_SaveAs.Size = new System.Drawing.Size(184, 22);
			this.Menu_File_SaveAs.Text = "名前を付けて保存(A)";
			this.Menu_File_SaveAs.Click += new System.EventHandler(this.Menu_File_SaveAs_Click);
			// 
			// Menu_Edit
			// 
			this.Menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Edit_Undo,
            this.Menu_Edit_Redo,
            this.toolStripSeparator3,
            this.Menu_Edit_Cut,
            this.Menu_Edit_Copy,
            this.Menu_Edit_Paste,
            this.toolStripSeparator4,
            this.Menu_Edit_SelectGroup});
			this.Menu_Edit.Name = "Menu_Edit";
			this.Menu_Edit.Size = new System.Drawing.Size(57, 20);
			this.Menu_Edit.Text = "編集(E)";
			// 
			// Menu_Edit_Undo
			// 
			this.Menu_Edit_Undo.Name = "Menu_Edit_Undo";
			this.Menu_Edit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.Menu_Edit_Undo.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_Undo.Text = "元に戻す(U)";
			this.Menu_Edit_Undo.Click += new System.EventHandler(this.Menu_Edit_Undo_Click);
			// 
			// Menu_Edit_Redo
			// 
			this.Menu_Edit_Redo.Name = "Menu_Edit_Redo";
			this.Menu_Edit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.Menu_Edit_Redo.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_Redo.Text = "やり直し(R)";
			this.Menu_Edit_Redo.Click += new System.EventHandler(this.Menu_Edit_Redo_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
			// 
			// Menu_Edit_Cut
			// 
			this.Menu_Edit_Cut.Name = "Menu_Edit_Cut";
			this.Menu_Edit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.Menu_Edit_Cut.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_Cut.Text = "切り取り(X)";
			this.Menu_Edit_Cut.Click += new System.EventHandler(this.Menu_Edit_Cut_Click);
			// 
			// Menu_Edit_Copy
			// 
			this.Menu_Edit_Copy.Name = "Menu_Edit_Copy";
			this.Menu_Edit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.Menu_Edit_Copy.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_Copy.Text = "コピー(C)";
			this.Menu_Edit_Copy.Click += new System.EventHandler(this.Menu_Edit_Copy_Click);
			// 
			// Menu_Edit_Paste
			// 
			this.Menu_Edit_Paste.Name = "Menu_Edit_Paste";
			this.Menu_Edit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.Menu_Edit_Paste.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_Paste.Text = "貼り付け(P)";
			this.Menu_Edit_Paste.Click += new System.EventHandler(this.Menu_Edit_Paste_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
			// 
			// Menu_Edit_SelectGroup
			// 
			this.Menu_Edit_SelectGroup.Name = "Menu_Edit_SelectGroup";
			this.Menu_Edit_SelectGroup.Size = new System.Drawing.Size(173, 22);
			this.Menu_Edit_SelectGroup.Text = "グループ選択(G)";
			this.Menu_Edit_SelectGroup.Click += new System.EventHandler(this.Menu_Edit_SelectGroup_Click);
			// 
			// Menu_Display
			// 
			this.Menu_Display.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Display_ZoomIn,
            this.Menu_Display_ZoomOut,
            this.Menu_Display_Zoom100});
			this.Menu_Display.Name = "Menu_Display";
			this.Menu_Display.Size = new System.Drawing.Size(59, 20);
			this.Menu_Display.Text = "表示(D)";
			// 
			// Menu_Display_ZoomIn
			// 
			this.Menu_Display_ZoomIn.Name = "Menu_Display_ZoomIn";
			this.Menu_Display_ZoomIn.ShortcutKeyDisplayString = "Ctrl+(+)";
			this.Menu_Display_ZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
			this.Menu_Display_ZoomIn.Size = new System.Drawing.Size(161, 22);
			this.Menu_Display_ZoomIn.Text = "拡大(I)";
			this.Menu_Display_ZoomIn.Click += new System.EventHandler(this.Menu_Display_ZoomIn_Click);
			// 
			// Menu_Display_ZoomOut
			// 
			this.Menu_Display_ZoomOut.Name = "Menu_Display_ZoomOut";
			this.Menu_Display_ZoomOut.ShortcutKeyDisplayString = "Ctrl+(-)";
			this.Menu_Display_ZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
			this.Menu_Display_ZoomOut.Size = new System.Drawing.Size(161, 22);
			this.Menu_Display_ZoomOut.Text = "縮小(O)";
			this.Menu_Display_ZoomOut.Click += new System.EventHandler(this.Menu_Display_ZoomOut_Click);
			// 
			// Menu_Display_Zoom100
			// 
			this.Menu_Display_Zoom100.Name = "Menu_Display_Zoom100";
			this.Menu_Display_Zoom100.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
			this.Menu_Display_Zoom100.Size = new System.Drawing.Size(161, 22);
			this.Menu_Display_Zoom100.Text = "100%";
			this.Menu_Display_Zoom100.Click += new System.EventHandler(this.Menu_Display_Zoom100_Click);
			// 
			// vScrollBar
			// 
			this.vScrollBar.Location = new System.Drawing.Point(247, 27);
			this.vScrollBar.Name = "vScrollBar";
			this.vScrollBar.Size = new System.Drawing.Size(17, 180);
			this.vScrollBar.TabIndex = 1;
			// 
			// hScrollBar
			// 
			this.hScrollBar.Location = new System.Drawing.Point(9, 210);
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(235, 17);
			this.hScrollBar.TabIndex = 2;
			// 
			// PictureBox
			// 
			this.PictureBox.Location = new System.Drawing.Point(9, 27);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new System.Drawing.Size(235, 180);
			this.PictureBox.TabIndex = 3;
			this.PictureBox.TabStop = false;
			this.PictureBox.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
			this.PictureBox.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
			this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
			// 
			// Timer
			// 
			this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 263);
			this.Controls.Add(this.PictureBox);
			this.Controls.Add(this.hScrollBar);
			this.Controls.Add(this.vScrollBar);
			this.Controls.Add(this.Menu);
			this.MainMenuStrip = this.Menu;
			this.Name = "Main";
			this.Load += new System.EventHandler(this.Main_Load);
			this.Shown += new System.EventHandler(this.Main_Shown);
			this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem Menu_File;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_New;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_Open;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_Save;
		private System.Windows.Forms.ToolStripMenuItem Menu_File_SaveAs;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Undo;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Redo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Cut;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Copy;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_Paste;
		private System.Windows.Forms.ToolStripMenuItem Menu_Display;
		private System.Windows.Forms.VScrollBar vScrollBar;
		private System.Windows.Forms.HScrollBar hScrollBar;
		private System.Windows.Forms.PictureBox PictureBox;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.ToolStripMenuItem Menu_Display_ZoomIn;
		private System.Windows.Forms.ToolStripMenuItem Menu_Display_ZoomOut;
		private System.Windows.Forms.ToolStripMenuItem Menu_Display_Zoom100;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem Menu_Edit_SelectGroup;
	}
}

