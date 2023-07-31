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
            this.tsmFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFileOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmFileSavePDF = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.表示DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDisp100 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDispZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDispZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDispMoveToLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDispMoveToGlobalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmDispSetGridPitch = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDispLocalGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDispGlobalGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSnapGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSnapVert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSnapLine = new System.Windows.Forms.ToolStripMenuItem();
            this.モードMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModeSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmModeMoveLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmModePolyline = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModePolygonFill = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmModePolygonHole = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
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
            this.設定SToolStripMenuItem,
            this.モードMToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFileNew,
            this.toolStripSeparator1,
            this.tsmFileOpen,
            this.toolStripSeparator2,
            this.tsmFileOverwrite,
            this.tsmFileSave,
            this.toolStripSeparator3,
            this.tsmFileSavePDF});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(F)";
            // 
            // tsmFileNew
            // 
            this.tsmFileNew.Name = "tsmFileNew";
            this.tsmFileNew.Size = new System.Drawing.Size(170, 22);
            this.tsmFileNew.Text = "新規作成";
            this.tsmFileNew.Click += new System.EventHandler(this.tsmFileNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmFileOpen
            // 
            this.tsmFileOpen.Name = "tsmFileOpen";
            this.tsmFileOpen.Size = new System.Drawing.Size(170, 22);
            this.tsmFileOpen.Text = "開く";
            this.tsmFileOpen.Click += new System.EventHandler(this.tsmFileOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmFileOverwrite
            // 
            this.tsmFileOverwrite.Name = "tsmFileOverwrite";
            this.tsmFileOverwrite.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmFileOverwrite.Size = new System.Drawing.Size(170, 22);
            this.tsmFileOverwrite.Text = "上書き保存";
            this.tsmFileOverwrite.Click += new System.EventHandler(this.tsmFileOverwrite_Click);
            // 
            // tsmFileSave
            // 
            this.tsmFileSave.Name = "tsmFileSave";
            this.tsmFileSave.Size = new System.Drawing.Size(170, 22);
            this.tsmFileSave.Text = "名前を付けて保存";
            this.tsmFileSave.Click += new System.EventHandler(this.tsmFileSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmFileSavePDF
            // 
            this.tsmFileSavePDF.Name = "tsmFileSavePDF";
            this.tsmFileSavePDF.Size = new System.Drawing.Size(170, 22);
            this.tsmFileSavePDF.Text = "PDF出力";
            this.tsmFileSavePDF.Click += new System.EventHandler(this.tsmFileSavePDF_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmEditUndo,
            this.tsmEditRedo,
            this.tsmEditEsc,
            this.toolStripSeparator4,
            this.tsmEditCut,
            this.tsmEditCopy,
            this.tsmEditPaste,
            this.tsmEditDelete});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.編集EToolStripMenuItem.Text = "編集(E)";
            // 
            // tsmEditUndo
            // 
            this.tsmEditUndo.Name = "tsmEditUndo";
            this.tsmEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmEditUndo.Size = new System.Drawing.Size(157, 22);
            this.tsmEditUndo.Text = "元に戻す";
            this.tsmEditUndo.Click += new System.EventHandler(this.tsmEditUndo_Click);
            // 
            // tsmEditRedo
            // 
            this.tsmEditRedo.Name = "tsmEditRedo";
            this.tsmEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmEditRedo.Size = new System.Drawing.Size(157, 22);
            this.tsmEditRedo.Text = "やり直し";
            this.tsmEditRedo.Click += new System.EventHandler(this.tsmEditRedo_Click);
            // 
            // tsmEditEsc
            // 
            this.tsmEditEsc.Name = "tsmEditEsc";
            this.tsmEditEsc.ShortcutKeyDisplayString = "Esc";
            this.tsmEditEsc.Size = new System.Drawing.Size(157, 22);
            this.tsmEditEsc.Text = "取り消し";
            this.tsmEditEsc.Click += new System.EventHandler(this.tsmEditEsc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // tsmEditCut
            // 
            this.tsmEditCut.Name = "tsmEditCut";
            this.tsmEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmEditCut.Size = new System.Drawing.Size(157, 22);
            this.tsmEditCut.Text = "切り取り";
            this.tsmEditCut.Click += new System.EventHandler(this.tsmEditCut_Click);
            // 
            // tsmEditCopy
            // 
            this.tsmEditCopy.Name = "tsmEditCopy";
            this.tsmEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmEditCopy.Size = new System.Drawing.Size(157, 22);
            this.tsmEditCopy.Text = "コピー";
            this.tsmEditCopy.Click += new System.EventHandler(this.tsmEditCopy_Click);
            // 
            // tsmEditPaste
            // 
            this.tsmEditPaste.Name = "tsmEditPaste";
            this.tsmEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmEditPaste.Size = new System.Drawing.Size(157, 22);
            this.tsmEditPaste.Text = "貼り付け";
            this.tsmEditPaste.Click += new System.EventHandler(this.tsmEditPaste_Click);
            // 
            // tsmEditDelete
            // 
            this.tsmEditDelete.Name = "tsmEditDelete";
            this.tsmEditDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmEditDelete.Size = new System.Drawing.Size(157, 22);
            this.tsmEditDelete.Text = "削除";
            this.tsmEditDelete.Click += new System.EventHandler(this.tsmEditDelete_Click);
            // 
            // 表示DToolStripMenuItem
            // 
            this.表示DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDisp100,
            this.tsmDispZoomIn,
            this.tsmDispZoomOut,
            this.toolStripSeparator6,
            this.tsmDispMoveToLocalOrigin,
            this.tsmDispMoveToGlobalOrigin,
            this.toolStripSeparator9,
            this.tsmDispSetGridPitch,
            this.tsmDispLocalGrid,
            this.tsmDispGlobalGrid});
            this.表示DToolStripMenuItem.Name = "表示DToolStripMenuItem";
            this.表示DToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.表示DToolStripMenuItem.Text = "表示(D)";
            // 
            // tsmDisp100
            // 
            this.tsmDisp100.Name = "tsmDisp100";
            this.tsmDisp100.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.tsmDisp100.Size = new System.Drawing.Size(236, 22);
            this.tsmDisp100.Text = "等倍";
            this.tsmDisp100.Click += new System.EventHandler(this.tsmDisp100_Click);
            // 
            // tsmDispZoomIn
            // 
            this.tsmDispZoomIn.Name = "tsmDispZoomIn";
            this.tsmDispZoomIn.ShortcutKeyDisplayString = "Ctrl+(+)";
            this.tsmDispZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.tsmDispZoomIn.Size = new System.Drawing.Size(236, 22);
            this.tsmDispZoomIn.Text = "拡大";
            this.tsmDispZoomIn.Click += new System.EventHandler(this.tsmDispZoomIn_Click);
            // 
            // tsmDispZoomOut
            // 
            this.tsmDispZoomOut.Name = "tsmDispZoomOut";
            this.tsmDispZoomOut.ShortcutKeyDisplayString = "Ctrl+(-)";
            this.tsmDispZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.tsmDispZoomOut.Size = new System.Drawing.Size(236, 22);
            this.tsmDispZoomOut.Text = "縮小";
            this.tsmDispZoomOut.Click += new System.EventHandler(this.tsmDispZoomOut_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(233, 6);
            // 
            // tsmDispMoveToLocalOrigin
            // 
            this.tsmDispMoveToLocalOrigin.Name = "tsmDispMoveToLocalOrigin";
            this.tsmDispMoveToLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmDispMoveToLocalOrigin.Size = new System.Drawing.Size(236, 22);
            this.tsmDispMoveToLocalOrigin.Text = "ローカル原点に移動";
            this.tsmDispMoveToLocalOrigin.Click += new System.EventHandler(this.tsmDispMoveToLocalOrigin_Click);
            // 
            // tsmDispMoveToGlobalOrigin
            // 
            this.tsmDispMoveToGlobalOrigin.Name = "tsmDispMoveToGlobalOrigin";
            this.tsmDispMoveToGlobalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.tsmDispMoveToGlobalOrigin.Size = new System.Drawing.Size(236, 22);
            this.tsmDispMoveToGlobalOrigin.Text = "グローバル原点に移動";
            this.tsmDispMoveToGlobalOrigin.Click += new System.EventHandler(this.tsmDispMoveToGlobalOrigin_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(233, 6);
            // 
            // tsmDispSetGridPitch
            // 
            this.tsmDispSetGridPitch.Name = "tsmDispSetGridPitch";
            this.tsmDispSetGridPitch.Size = new System.Drawing.Size(236, 22);
            this.tsmDispSetGridPitch.Text = "グリッドのピッチを設定";
            this.tsmDispSetGridPitch.Click += new System.EventHandler(this.tsmDispSetGridPitch_Click);
            // 
            // tsmDispLocalGrid
            // 
            this.tsmDispLocalGrid.Name = "tsmDispLocalGrid";
            this.tsmDispLocalGrid.Size = new System.Drawing.Size(236, 22);
            this.tsmDispLocalGrid.Text = "グリッドをローカル座標に合わせる";
            this.tsmDispLocalGrid.Click += new System.EventHandler(this.tsmDispLocalGrid_Click);
            // 
            // tsmDispGlobalGrid
            // 
            this.tsmDispGlobalGrid.Name = "tsmDispGlobalGrid";
            this.tsmDispGlobalGrid.Size = new System.Drawing.Size(236, 22);
            this.tsmDispGlobalGrid.Text = "グリッドをグローバル座標に合わせる";
            this.tsmDispGlobalGrid.Click += new System.EventHandler(this.tsmDispGlobalGrid_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSnapGrid,
            this.tsmSnapVert,
            this.tsmSnapLine});
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.設定SToolStripMenuItem.Text = "スナップ(S)";
            // 
            // tsmSnapGrid
            // 
            this.tsmSnapGrid.Name = "tsmSnapGrid";
            this.tsmSnapGrid.Size = new System.Drawing.Size(151, 22);
            this.tsmSnapGrid.Text = "グリッドにスナップ";
            this.tsmSnapGrid.Click += new System.EventHandler(this.tsmSnap_Click);
            // 
            // tsmSnapVert
            // 
            this.tsmSnapVert.Name = "tsmSnapVert";
            this.tsmSnapVert.Size = new System.Drawing.Size(151, 22);
            this.tsmSnapVert.Text = "頂点にスナップ";
            this.tsmSnapVert.Click += new System.EventHandler(this.tsmSnap_Click);
            // 
            // tsmSnapLine
            // 
            this.tsmSnapLine.Name = "tsmSnapLine";
            this.tsmSnapLine.Size = new System.Drawing.Size(151, 22);
            this.tsmSnapLine.Text = "線にスナップ";
            this.tsmSnapLine.Click += new System.EventHandler(this.tsmSnap_Click);
            // 
            // モードMToolStripMenuItem
            // 
            this.モードMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmModeSelect,
            this.toolStripSeparator8,
            this.tsmModeMoveLocalOrigin,
            this.toolStripSeparator5,
            this.tsmModePolyline,
            this.tsmModePolygonFill,
            this.tsmModePolygonHole});
            this.モードMToolStripMenuItem.Name = "モードMToolStripMenuItem";
            this.モードMToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.モードMToolStripMenuItem.Text = "モード(M)";
            // 
            // tsmModeSelect
            // 
            this.tsmModeSelect.Name = "tsmModeSelect";
            this.tsmModeSelect.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmModeSelect.Size = new System.Drawing.Size(241, 22);
            this.tsmModeSelect.Text = "選択";
            this.tsmModeSelect.Click += new System.EventHandler(this.tsmMode_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmModeMoveLocalOrigin
            // 
            this.tsmModeMoveLocalOrigin.Name = "tsmModeMoveLocalOrigin";
            this.tsmModeMoveLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.tsmModeMoveLocalOrigin.Size = new System.Drawing.Size(241, 22);
            this.tsmModeMoveLocalOrigin.Text = "ローカル原点を移動";
            this.tsmModeMoveLocalOrigin.Click += new System.EventHandler(this.tsmMode_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmModePolyline
            // 
            this.tsmModePolyline.Name = "tsmModePolyline";
            this.tsmModePolyline.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.tsmModePolyline.Size = new System.Drawing.Size(241, 22);
            this.tsmModePolyline.Text = "ポリライン";
            this.tsmModePolyline.Click += new System.EventHandler(this.tsmMode_Click);
            // 
            // tsmModePolygonFill
            // 
            this.tsmModePolygonFill.Name = "tsmModePolygonFill";
            this.tsmModePolygonFill.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.tsmModePolygonFill.Size = new System.Drawing.Size(241, 22);
            this.tsmModePolygonFill.Text = "ポリゴン(塗りつぶし)";
            this.tsmModePolygonFill.Click += new System.EventHandler(this.tsmMode_Click);
            // 
            // tsmModePolygonHole
            // 
            this.tsmModePolygonHole.Name = "tsmModePolygonHole";
            this.tsmModePolygonHole.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.tsmModePolygonHole.Size = new System.Drawing.Size(241, 22);
            this.tsmModePolygonHole.Text = "ポリゴン(穴あけ)";
            this.tsmModePolygonHole.Click += new System.EventHandler(this.tsmMode_Click);
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
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(774, 27);
            this.vScrollBar1.Maximum = 2000;
            this.vScrollBar1.Minimum = -2000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 394);
            this.vScrollBar1.TabIndex = 3;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(0, 424);
            this.hScrollBar1.Maximum = 2000;
            this.hScrollBar1.Minimum = -2000;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(762, 17);
            this.hScrollBar1.TabIndex = 4;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
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
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(256, 256);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
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
        private System.Windows.Forms.ToolStripMenuItem tsmFileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmFileOverwrite;
        private System.Windows.Forms.ToolStripMenuItem tsmFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmFileSavePDF;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmEditUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmEditRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmEditCut;
        private System.Windows.Forms.ToolStripMenuItem tsmEditCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmEditPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmEditDelete;
        private System.Windows.Forms.ToolStripMenuItem モードMToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmModeMoveLocalOrigin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmModePolyline;
        private System.Windows.Forms.ToolStripMenuItem tsmModePolygonFill;
        private System.Windows.Forms.ToolStripMenuItem tsmModePolygonHole;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 表示DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmDisp100;
        private System.Windows.Forms.ToolStripMenuItem tsmDispZoomIn;
        private System.Windows.Forms.ToolStripMenuItem tsmDispZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmDispMoveToLocalOrigin;
        private System.Windows.Forms.ToolStripMenuItem tsmDispMoveToGlobalOrigin;
        private System.Windows.Forms.ToolStripMenuItem tsmModeSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSnapGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmSnapVert;
        private System.Windows.Forms.ToolStripMenuItem tsmSnapLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem tsmDispGlobalGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmDispLocalGrid;
        private System.Windows.Forms.ToolStripMenuItem tsmEditEsc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmDispSetGridPitch;
        private System.Windows.Forms.ToolStripStatusLabel tslPos;
    }
}

