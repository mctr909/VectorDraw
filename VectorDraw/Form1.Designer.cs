namespace VectorDraw {
    partial class Form1 {
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.FileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.FileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.FileOverwrite = new System.Windows.Forms.ToolStripMenuItem();
			this.FileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.EditRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.EditCut = new System.Windows.Forms.ToolStripMenuItem();
			this.EditCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.EditPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.EditDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.表示DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Disp100 = new System.Windows.Forms.ToolStripMenuItem();
			this.DispZoomIn = new System.Windows.Forms.ToolStripMenuItem();
			this.DispZoomOut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.DispMoveToLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.DispMoveToGlobalOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.DispLocalGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.DispGlobalGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.モードMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeSelect = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeMoveLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ModePolyline = new System.Windows.Forms.ToolStripMenuItem();
			this.ModePolygonFill = new System.Windows.Forms.ToolStripMenuItem();
			this.ModePolygonHole = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.ModeLine = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeCurve = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeArc = new System.Windows.Forms.ToolStripMenuItem();
			this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SnapGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.SnapVert = new System.Windows.Forms.ToolStripMenuItem();
			this.SnapLine = new System.Windows.Forms.ToolStripMenuItem();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.VSB = new System.Windows.Forms.VScrollBar();
			this.HSB = new System.Windows.Forms.HScrollBar();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslPos = new System.Windows.Forms.ToolStripStatusLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.表示DToolStripMenuItem,
            this.モードMToolStripMenuItem,
            this.設定SToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileNew,
            this.toolStripSeparator1,
            this.FileOpen,
            this.toolStripSeparator2,
            this.FileOverwrite,
            this.FileSave});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(F)";
			// 
			// FileNew
			// 
			this.FileNew.Name = "FileNew";
			this.FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.FileNew.Size = new System.Drawing.Size(170, 22);
			this.FileNew.Text = "新規作成";
			this.FileNew.Click += new System.EventHandler(this.FileNew_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
			// 
			// FileOpen
			// 
			this.FileOpen.Name = "FileOpen";
			this.FileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.FileOpen.Size = new System.Drawing.Size(170, 22);
			this.FileOpen.Text = "開く";
			this.FileOpen.Click += new System.EventHandler(this.FileOpen_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
			// 
			// FileOverwrite
			// 
			this.FileOverwrite.Name = "FileOverwrite";
			this.FileOverwrite.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.FileOverwrite.Size = new System.Drawing.Size(170, 22);
			this.FileOverwrite.Text = "上書き保存";
			this.FileOverwrite.Click += new System.EventHandler(this.FileOverwrite_Click);
			// 
			// FileSave
			// 
			this.FileSave.Name = "FileSave";
			this.FileSave.Size = new System.Drawing.Size(170, 22);
			this.FileSave.Text = "名前を付けて保存";
			this.FileSave.Click += new System.EventHandler(this.FileSave_Click);
			// 
			// 編集EToolStripMenuItem
			// 
			this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditUndo,
            this.EditRedo,
            this.toolStripSeparator4,
            this.EditCut,
            this.EditCopy,
            this.EditPaste,
            this.EditDelete});
			this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
			this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.編集EToolStripMenuItem.Text = "編集(E)";
			// 
			// EditUndo
			// 
			this.EditUndo.Name = "EditUndo";
			this.EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.EditUndo.Size = new System.Drawing.Size(180, 22);
			this.EditUndo.Text = "元に戻す";
			this.EditUndo.Click += new System.EventHandler(this.EditUndo_Click);
			// 
			// EditRedo
			// 
			this.EditRedo.Name = "EditRedo";
			this.EditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.EditRedo.Size = new System.Drawing.Size(180, 22);
			this.EditRedo.Text = "やり直し";
			this.EditRedo.Click += new System.EventHandler(this.EditRedo_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
			// 
			// EditCut
			// 
			this.EditCut.Name = "EditCut";
			this.EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.EditCut.Size = new System.Drawing.Size(180, 22);
			this.EditCut.Text = "切り取り";
			this.EditCut.Click += new System.EventHandler(this.EditCut_Click);
			// 
			// EditCopy
			// 
			this.EditCopy.Name = "EditCopy";
			this.EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.EditCopy.Size = new System.Drawing.Size(180, 22);
			this.EditCopy.Text = "コピー";
			this.EditCopy.Click += new System.EventHandler(this.EditCopy_Click);
			// 
			// EditPaste
			// 
			this.EditPaste.Name = "EditPaste";
			this.EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.EditPaste.Size = new System.Drawing.Size(180, 22);
			this.EditPaste.Text = "貼り付け";
			this.EditPaste.Click += new System.EventHandler(this.EditPaste_Click);
			// 
			// EditDelete
			// 
			this.EditDelete.Name = "EditDelete";
			this.EditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.EditDelete.Size = new System.Drawing.Size(180, 22);
			this.EditDelete.Text = "削除";
			this.EditDelete.Click += new System.EventHandler(this.EditDelete_Click);
			// 
			// 表示DToolStripMenuItem
			// 
			this.表示DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Disp100,
            this.DispZoomIn,
            this.DispZoomOut,
            this.toolStripSeparator6,
            this.DispMoveToLocalOrigin,
            this.DispMoveToGlobalOrigin,
            this.toolStripSeparator9,
            this.DispLocalGrid,
            this.DispGlobalGrid});
			this.表示DToolStripMenuItem.Name = "表示DToolStripMenuItem";
			this.表示DToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.表示DToolStripMenuItem.Text = "表示(D)";
			// 
			// Disp100
			// 
			this.Disp100.Name = "Disp100";
			this.Disp100.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
			this.Disp100.Size = new System.Drawing.Size(250, 22);
			this.Disp100.Text = "等倍";
			this.Disp100.Click += new System.EventHandler(this.Disp100_Click);
			// 
			// DispZoomIn
			// 
			this.DispZoomIn.Name = "DispZoomIn";
			this.DispZoomIn.ShortcutKeyDisplayString = "Ctrl+(+)";
			this.DispZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
			this.DispZoomIn.Size = new System.Drawing.Size(250, 22);
			this.DispZoomIn.Text = "拡大";
			this.DispZoomIn.Click += new System.EventHandler(this.DispZoomIn_Click);
			// 
			// DispZoomOut
			// 
			this.DispZoomOut.Name = "DispZoomOut";
			this.DispZoomOut.ShortcutKeyDisplayString = "Ctrl+(-)";
			this.DispZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
			this.DispZoomOut.Size = new System.Drawing.Size(250, 22);
			this.DispZoomOut.Text = "縮小";
			this.DispZoomOut.Click += new System.EventHandler(this.DispZoomOut_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(247, 6);
			// 
			// DispMoveToLocalOrigin
			// 
			this.DispMoveToLocalOrigin.Name = "DispMoveToLocalOrigin";
			this.DispMoveToLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
			this.DispMoveToLocalOrigin.Size = new System.Drawing.Size(250, 22);
			this.DispMoveToLocalOrigin.Text = "ローカル原点に移動";
			this.DispMoveToLocalOrigin.Click += new System.EventHandler(this.DispMoveToLocalOrigin_Click);
			// 
			// DispMoveToGlobalOrigin
			// 
			this.DispMoveToGlobalOrigin.Name = "DispMoveToGlobalOrigin";
			this.DispMoveToGlobalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
			this.DispMoveToGlobalOrigin.Size = new System.Drawing.Size(250, 22);
			this.DispMoveToGlobalOrigin.Text = "グローバル原点に移動";
			this.DispMoveToGlobalOrigin.Click += new System.EventHandler(this.DispMoveToGlobalOrigin_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(247, 6);
			// 
			// DispLocalGrid
			// 
			this.DispLocalGrid.Name = "DispLocalGrid";
			this.DispLocalGrid.Size = new System.Drawing.Size(250, 22);
			this.DispLocalGrid.Text = "グリッドをローカル座標に合わせる";
			this.DispLocalGrid.Click += new System.EventHandler(this.DispLocalGrid_Click);
			// 
			// DispGlobalGrid
			// 
			this.DispGlobalGrid.Name = "DispGlobalGrid";
			this.DispGlobalGrid.Size = new System.Drawing.Size(250, 22);
			this.DispGlobalGrid.Text = "グリッドをグローバル座標に合わせる";
			this.DispGlobalGrid.Click += new System.EventHandler(this.DispGlobalGrid_Click);
			// 
			// モードMToolStripMenuItem
			// 
			this.モードMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeSelect,
            this.ModeMoveLocalOrigin,
            this.toolStripSeparator3,
            this.ModePolyline,
            this.ModePolygonFill,
            this.ModePolygonHole,
            this.toolStripSeparator7,
            this.ModeLine,
            this.ModeArc,
            this.ModeCurve});
			this.モードMToolStripMenuItem.Name = "モードMToolStripMenuItem";
			this.モードMToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.モードMToolStripMenuItem.Text = "モード(M)";
			// 
			// ModeSelect
			// 
			this.ModeSelect.Name = "ModeSelect";
			this.ModeSelect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.ModeSelect.Size = new System.Drawing.Size(207, 22);
			this.ModeSelect.Text = "選択";
			this.ModeSelect.Click += new System.EventHandler(this.Mode_Click);
			// 
			// ModeMoveLocalOrigin
			// 
			this.ModeMoveLocalOrigin.Name = "ModeMoveLocalOrigin";
			this.ModeMoveLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.ModeMoveLocalOrigin.Size = new System.Drawing.Size(207, 22);
			this.ModeMoveLocalOrigin.Text = "ローカル原点を移動";
			this.ModeMoveLocalOrigin.Click += new System.EventHandler(this.Mode_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
			// 
			// ModePolyline
			// 
			this.ModePolyline.Name = "ModePolyline";
			this.ModePolyline.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.ModePolyline.Size = new System.Drawing.Size(207, 22);
			this.ModePolyline.Text = "多角形(線)";
			this.ModePolyline.Click += new System.EventHandler(this.Mode_Click);
			// 
			// ModePolygonFill
			// 
			this.ModePolygonFill.Name = "ModePolygonFill";
			this.ModePolygonFill.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.ModePolygonFill.Size = new System.Drawing.Size(207, 22);
			this.ModePolygonFill.Text = "多角形(塗りつぶし)";
			this.ModePolygonFill.Click += new System.EventHandler(this.Mode_Click);
			// 
			// ModePolygonHole
			// 
			this.ModePolygonHole.Name = "ModePolygonHole";
			this.ModePolygonHole.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.ModePolygonHole.Size = new System.Drawing.Size(207, 22);
			this.ModePolygonHole.Text = "多角形(穴あけ)";
			this.ModePolygonHole.Click += new System.EventHandler(this.Mode_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(204, 6);
			// 
			// ModeLine
			// 
			this.ModeLine.Name = "ModeLine";
			this.ModeLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
			this.ModeLine.Size = new System.Drawing.Size(207, 22);
			this.ModeLine.Text = "直線";
			this.ModeLine.Click += new System.EventHandler(this.ModeLineType_Click);
			// 
			// ModeCurve
			// 
			this.ModeCurve.Name = "ModeCurve";
			this.ModeCurve.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			this.ModeCurve.Size = new System.Drawing.Size(207, 22);
			this.ModeCurve.Text = "曲線";
			this.ModeCurve.Click += new System.EventHandler(this.ModeLineType_Click);
			// 
			// ModeArc
			// 
			this.ModeArc.Name = "ModeArc";
			this.ModeArc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
			this.ModeArc.Size = new System.Drawing.Size(207, 22);
			this.ModeArc.Text = "円弧";
			this.ModeArc.Click += new System.EventHandler(this.ModeLineType_Click);
			// 
			// 設定SToolStripMenuItem
			// 
			this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SnapGrid,
            this.SnapVert,
            this.SnapLine});
			this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
			this.設定SToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.設定SToolStripMenuItem.Text = "スナップ(S)";
			// 
			// SnapGrid
			// 
			this.SnapGrid.Name = "SnapGrid";
			this.SnapGrid.Size = new System.Drawing.Size(151, 22);
			this.SnapGrid.Text = "グリッドにスナップ";
			this.SnapGrid.Click += new System.EventHandler(this.Snap_Click);
			// 
			// SnapVert
			// 
			this.SnapVert.Name = "SnapVert";
			this.SnapVert.Size = new System.Drawing.Size(151, 22);
			this.SnapVert.Text = "頂点にスナップ";
			this.SnapVert.Click += new System.EventHandler(this.Snap_Click);
			// 
			// SnapLine
			// 
			this.SnapLine.Name = "SnapLine";
			this.SnapLine.Size = new System.Drawing.Size(151, 22);
			this.SnapLine.Text = "線にスナップ";
			this.SnapLine.Click += new System.EventHandler(this.Snap_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(0, 27);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(762, 394);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// VSB
			// 
			this.VSB.Location = new System.Drawing.Point(774, 27);
			this.VSB.Maximum = 200;
			this.VSB.Minimum = -200;
			this.VSB.Name = "VSB";
			this.VSB.Size = new System.Drawing.Size(17, 394);
			this.VSB.TabIndex = 3;
			this.VSB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VSB_Scroll);
			// 
			// HSB
			// 
			this.HSB.Location = new System.Drawing.Point(0, 424);
			this.HSB.Maximum = 200;
			this.HSB.Minimum = -200;
			this.HSB.Name = "HSB";
			this.HSB.Size = new System.Drawing.Size(762, 17);
			this.HSB.TabIndex = 4;
			this.HSB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HSB_Scroll);
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslPos});
			this.statusStrip1.Location = new System.Drawing.Point(0, 449);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 25);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslPos
			// 
			this.tslPos.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tslPos.Name = "tslPos";
			this.tslPos.Size = new System.Drawing.Size(122, 20);
			this.tslPos.Text = "0.00mm, 0.00mm";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 474);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.HSB);
			this.Controls.Add(this.VSB);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(256, 256);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem FileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem FileOverwrite;
        private System.Windows.Forms.ToolStripMenuItem FileSave;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditUndo;
        private System.Windows.Forms.ToolStripMenuItem EditRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem EditCut;
        private System.Windows.Forms.ToolStripMenuItem EditCopy;
        private System.Windows.Forms.ToolStripMenuItem EditPaste;
        private System.Windows.Forms.ToolStripMenuItem EditDelete;
        private System.Windows.Forms.ToolStripMenuItem モードMToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar VSB;
        private System.Windows.Forms.HScrollBar HSB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem ModeMoveLocalOrigin;
        private System.Windows.Forms.ToolStripMenuItem ModePolyline;
        private System.Windows.Forms.ToolStripMenuItem ModePolygonFill;
        private System.Windows.Forms.ToolStripMenuItem ModePolygonHole;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 表示DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Disp100;
        private System.Windows.Forms.ToolStripMenuItem DispZoomIn;
        private System.Windows.Forms.ToolStripMenuItem DispZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem DispMoveToLocalOrigin;
        private System.Windows.Forms.ToolStripMenuItem DispMoveToGlobalOrigin;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SnapGrid;
        private System.Windows.Forms.ToolStripMenuItem SnapVert;
        private System.Windows.Forms.ToolStripMenuItem SnapLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem DispGlobalGrid;
        private System.Windows.Forms.ToolStripMenuItem DispLocalGrid;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel tslPos;
		private System.Windows.Forms.ToolStripMenuItem ModeCurve;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem ModeArc;
		private System.Windows.Forms.ToolStripMenuItem ModeLine;
		private System.Windows.Forms.ToolStripMenuItem ModeSelect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}

