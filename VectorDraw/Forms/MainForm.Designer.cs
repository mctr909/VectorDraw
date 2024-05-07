namespace VectorDraw.Forms {
    partial class MainForm {
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
			this.MenuItemFile_New = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemFile_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemFile_Overwrite = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemFile_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemFile_SavePDF = new System.Windows.Forms.ToolStripMenuItem();
			this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Cancel = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Redo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemEdit_Delete = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Cut = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemEdit_Paste = new System.Windows.Forms.ToolStripMenuItem();
			this.表示DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_100 = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_ZoomIn = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_ZoomOut = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemDisp_MoveToModelOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_MoveToGlobalOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemDisp_SetGridPitch = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_ModelGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_GlobalGrid = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemDisp_ModelList = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemDisp_LayerList = new System.Windows.Forms.ToolStripMenuItem();
			this.モードMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemMode_Select = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemMode_MoveModelOrigin = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemMode_Polyline = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemMode_PolygonFill = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemMode_PolygonHole = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemMode_Corner = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemPolyMode_Line = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemPolyMode_Arc = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemPolyMode_Bow = new System.Windows.Forms.ToolStripMenuItem();
			this.スナップSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemSnap_Grid = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemSnap_Vert = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemSnap_Line = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuTextPositionX = new System.Windows.Forms.ToolStripTextBox();
			this.MenuTextPositionY = new System.Windows.Forms.ToolStripTextBox();
			this.MenuTextHint = new System.Windows.Forms.ToolStripTextBox();
			this.DisplayArea = new System.Windows.Forms.PictureBox();
			this.ScrollBarY = new System.Windows.Forms.VScrollBar();
			this.ScrollBarX = new System.Windows.Forms.HScrollBar();
			this.DisplayTimer = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DisplayArea)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.表示DToolStripMenuItem,
            this.モードMToolStripMenuItem,
            this.スナップSToolStripMenuItem,
            this.MenuTextPositionX,
            this.MenuTextPositionY,
            this.MenuTextHint});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile_New,
            this.toolStripSeparator1,
            this.MenuItemFile_Open,
            this.toolStripSeparator2,
            this.MenuItemFile_Overwrite,
            this.MenuItemFile_Save,
            this.toolStripSeparator3,
            this.MenuItemFile_SavePDF});
			this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
			this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.ファイルFToolStripMenuItem.Text = "ファイル(F)";
			// 
			// MenuItemFile_New
			// 
			this.MenuItemFile_New.Name = "MenuItemFile_New";
			this.MenuItemFile_New.Size = new System.Drawing.Size(170, 22);
			this.MenuItemFile_New.Text = "新規作成";
			this.MenuItemFile_New.Click += new System.EventHandler(this.MenuItemFile_New_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
			// 
			// MenuItemFile_Open
			// 
			this.MenuItemFile_Open.Name = "MenuItemFile_Open";
			this.MenuItemFile_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.MenuItemFile_Open.Size = new System.Drawing.Size(170, 22);
			this.MenuItemFile_Open.Text = "開く";
			this.MenuItemFile_Open.Click += new System.EventHandler(this.MenuItemFile_Open_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
			// 
			// MenuItemFile_Overwrite
			// 
			this.MenuItemFile_Overwrite.Name = "MenuItemFile_Overwrite";
			this.MenuItemFile_Overwrite.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.MenuItemFile_Overwrite.Size = new System.Drawing.Size(170, 22);
			this.MenuItemFile_Overwrite.Text = "上書き保存";
			this.MenuItemFile_Overwrite.Click += new System.EventHandler(this.MenuItemFile_Overwrite_Click);
			// 
			// MenuItemFile_Save
			// 
			this.MenuItemFile_Save.Name = "MenuItemFile_Save";
			this.MenuItemFile_Save.Size = new System.Drawing.Size(170, 22);
			this.MenuItemFile_Save.Text = "名前を付けて保存";
			this.MenuItemFile_Save.Click += new System.EventHandler(this.MenuItemFile_Save_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
			// 
			// MenuItemFile_SavePDF
			// 
			this.MenuItemFile_SavePDF.Name = "MenuItemFile_SavePDF";
			this.MenuItemFile_SavePDF.Size = new System.Drawing.Size(170, 22);
			this.MenuItemFile_SavePDF.Text = "PDF出力";
			this.MenuItemFile_SavePDF.Click += new System.EventHandler(this.MenuItemFile_SavePDF_Click);
			// 
			// 編集EToolStripMenuItem
			// 
			this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEdit_Cancel,
            this.MenuItemEdit_Undo,
            this.MenuItemEdit_Redo,
            this.toolStripSeparator4,
            this.MenuItemEdit_Delete,
            this.MenuItemEdit_Cut,
            this.MenuItemEdit_Copy,
            this.MenuItemEdit_Paste});
			this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
			this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.編集EToolStripMenuItem.Text = "編集(E)";
			// 
			// MenuItemEdit_Cancel
			// 
			this.MenuItemEdit_Cancel.Name = "MenuItemEdit_Cancel";
			this.MenuItemEdit_Cancel.ShortcutKeyDisplayString = "Esc";
			this.MenuItemEdit_Cancel.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Cancel.Text = "取り消し";
			this.MenuItemEdit_Cancel.Click += new System.EventHandler(this.MenuItemEdit_Cancel_Click);
			// 
			// MenuItemEdit_Undo
			// 
			this.MenuItemEdit_Undo.Name = "MenuItemEdit_Undo";
			this.MenuItemEdit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.MenuItemEdit_Undo.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Undo.Text = "元に戻す";
			this.MenuItemEdit_Undo.Click += new System.EventHandler(this.MenuItemEdit_Undo_Click);
			// 
			// MenuItemEdit_Redo
			// 
			this.MenuItemEdit_Redo.Name = "MenuItemEdit_Redo";
			this.MenuItemEdit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.MenuItemEdit_Redo.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Redo.Text = "やり直し";
			this.MenuItemEdit_Redo.Click += new System.EventHandler(this.MenuItemEdit_Redo_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
			// 
			// MenuItemEdit_Delete
			// 
			this.MenuItemEdit_Delete.Name = "MenuItemEdit_Delete";
			this.MenuItemEdit_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.MenuItemEdit_Delete.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Delete.Text = "削除";
			this.MenuItemEdit_Delete.Click += new System.EventHandler(this.MenuItemEdit_Delete_Click);
			// 
			// MenuItemEdit_Cut
			// 
			this.MenuItemEdit_Cut.Name = "MenuItemEdit_Cut";
			this.MenuItemEdit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.MenuItemEdit_Cut.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Cut.Text = "切り取り";
			this.MenuItemEdit_Cut.Click += new System.EventHandler(this.MenuItemEdit_Cut_Click);
			// 
			// MenuItemEdit_Copy
			// 
			this.MenuItemEdit_Copy.Name = "MenuItemEdit_Copy";
			this.MenuItemEdit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.MenuItemEdit_Copy.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Copy.Text = "コピー";
			this.MenuItemEdit_Copy.Click += new System.EventHandler(this.MenuItemEdit_Copy_Click);
			// 
			// MenuItemEdit_Paste
			// 
			this.MenuItemEdit_Paste.Name = "MenuItemEdit_Paste";
			this.MenuItemEdit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.MenuItemEdit_Paste.Size = new System.Drawing.Size(157, 22);
			this.MenuItemEdit_Paste.Text = "貼り付け";
			this.MenuItemEdit_Paste.Click += new System.EventHandler(this.MenuItemEdit_Paste_Click);
			// 
			// 表示DToolStripMenuItem
			// 
			this.表示DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDisp_100,
            this.MenuItemDisp_ZoomIn,
            this.MenuItemDisp_ZoomOut,
            this.toolStripSeparator6,
            this.MenuItemDisp_MoveToModelOrigin,
            this.MenuItemDisp_MoveToGlobalOrigin,
            this.toolStripSeparator9,
            this.MenuItemDisp_ModelGrid,
            this.MenuItemDisp_GlobalGrid,
            this.MenuItemDisp_SetGridPitch,
            this.toolStripSeparator8,
            this.MenuItemDisp_ModelList,
            this.MenuItemDisp_LayerList});
			this.表示DToolStripMenuItem.Name = "表示DToolStripMenuItem";
			this.表示DToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.表示DToolStripMenuItem.Text = "表示(D)";
			// 
			// MenuItemDisp_100
			// 
			this.MenuItemDisp_100.Name = "MenuItemDisp_100";
			this.MenuItemDisp_100.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
			this.MenuItemDisp_100.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_100.Text = "等倍";
			this.MenuItemDisp_100.Click += new System.EventHandler(this.MenuItemDisp_100_Click);
			// 
			// MenuItemDisp_ZoomIn
			// 
			this.MenuItemDisp_ZoomIn.Name = "MenuItemDisp_ZoomIn";
			this.MenuItemDisp_ZoomIn.ShortcutKeyDisplayString = "Ctrl+(+)";
			this.MenuItemDisp_ZoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
			this.MenuItemDisp_ZoomIn.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_ZoomIn.Text = "拡大";
			this.MenuItemDisp_ZoomIn.Click += new System.EventHandler(this.MenuItemDisp_ZoomIn_Click);
			// 
			// MenuItemDisp_ZoomOut
			// 
			this.MenuItemDisp_ZoomOut.Name = "MenuItemDisp_ZoomOut";
			this.MenuItemDisp_ZoomOut.ShortcutKeyDisplayString = "Ctrl+(-)";
			this.MenuItemDisp_ZoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
			this.MenuItemDisp_ZoomOut.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_ZoomOut.Text = "縮小";
			this.MenuItemDisp_ZoomOut.Click += new System.EventHandler(this.MenuItemDisp_ZoomOut_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(233, 6);
			// 
			// MenuItemDisp_MoveToModelOrigin
			// 
			this.MenuItemDisp_MoveToModelOrigin.Name = "MenuItemDisp_MoveToModelOrigin";
			this.MenuItemDisp_MoveToModelOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.MenuItemDisp_MoveToModelOrigin.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_MoveToModelOrigin.Text = "モデル原点に移動";
			this.MenuItemDisp_MoveToModelOrigin.Click += new System.EventHandler(this.MenuItemDisp_MoveToObjectOrigin_Click);
			// 
			// MenuItemDisp_MoveToGlobalOrigin
			// 
			this.MenuItemDisp_MoveToGlobalOrigin.Name = "MenuItemDisp_MoveToGlobalOrigin";
			this.MenuItemDisp_MoveToGlobalOrigin.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_MoveToGlobalOrigin.Text = "グローバル原点に移動";
			this.MenuItemDisp_MoveToGlobalOrigin.Click += new System.EventHandler(this.MenuItemDisp_MoveToGlobalOrigin_Click);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(233, 6);
			// 
			// MenuItemDisp_SetGridPitch
			// 
			this.MenuItemDisp_SetGridPitch.Name = "MenuItemDisp_SetGridPitch";
			this.MenuItemDisp_SetGridPitch.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_SetGridPitch.Text = "グローバル座標のグリッドを設定";
			this.MenuItemDisp_SetGridPitch.Click += new System.EventHandler(this.MenuItemDisp_SetGridPitch_Click);
			// 
			// MenuItemDisp_ModelGrid
			// 
			this.MenuItemDisp_ModelGrid.Name = "MenuItemDisp_ModelGrid";
			this.MenuItemDisp_ModelGrid.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_ModelGrid.Text = "グリッドをモデル座標に合わせる";
			this.MenuItemDisp_ModelGrid.Click += new System.EventHandler(this.MenuItemDisp_ModelGrid_Click);
			// 
			// MenuItemDisp_GlobalGrid
			// 
			this.MenuItemDisp_GlobalGrid.Name = "MenuItemDisp_GlobalGrid";
			this.MenuItemDisp_GlobalGrid.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_GlobalGrid.Text = "グリッドをグローバル座標に合わせる";
			this.MenuItemDisp_GlobalGrid.Click += new System.EventHandler(this.MenuItemDisp_GlobalGrid_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(233, 6);
			// 
			// MenuItemDisp_ModelList
			// 
			this.MenuItemDisp_ModelList.Name = "MenuItemDisp_ModelList";
			this.MenuItemDisp_ModelList.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_ModelList.Text = "モデル一覧を表示";
			this.MenuItemDisp_ModelList.Click += new System.EventHandler(this.MenuItemDisp_ModelList_Click);
			// 
			// MenuItemDisp_LayerList
			// 
			this.MenuItemDisp_LayerList.Name = "MenuItemDisp_LayerList";
			this.MenuItemDisp_LayerList.Size = new System.Drawing.Size(236, 22);
			this.MenuItemDisp_LayerList.Text = "レイヤー一覧を表示";
			this.MenuItemDisp_LayerList.Click += new System.EventHandler(this.MenuItemDisp_LayerList_Click);
			// 
			// モードMToolStripMenuItem
			// 
			this.モードMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMode_Select,
            this.MenuItemMode_MoveModelOrigin,
            this.toolStripSeparator5,
            this.MenuItemMode_Polyline,
            this.MenuItemMode_PolygonFill,
            this.MenuItemMode_PolygonHole,
            this.MenuItemMode_Corner,
            this.toolStripSeparator7,
            this.MenuItemPolyMode_Line,
            this.MenuItemPolyMode_Arc,
            this.MenuItemPolyMode_Bow});
			this.モードMToolStripMenuItem.Name = "モードMToolStripMenuItem";
			this.モードMToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.モードMToolStripMenuItem.Text = "モード(M)";
			// 
			// MenuItemMode_Select
			// 
			this.MenuItemMode_Select.Name = "MenuItemMode_Select";
			this.MenuItemMode_Select.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.MenuItemMode_Select.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_Select.Text = "選択";
			this.MenuItemMode_Select.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// MenuItemMode_MoveModelOrigin
			// 
			this.MenuItemMode_MoveModelOrigin.Name = "MenuItemMode_MoveModelOrigin";
			this.MenuItemMode_MoveModelOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
			this.MenuItemMode_MoveModelOrigin.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_MoveModelOrigin.Text = "モデル原点を移動";
			this.MenuItemMode_MoveModelOrigin.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(228, 6);
			// 
			// MenuItemMode_Polyline
			// 
			this.MenuItemMode_Polyline.Name = "MenuItemMode_Polyline";
			this.MenuItemMode_Polyline.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.MenuItemMode_Polyline.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_Polyline.Text = "ポリライン";
			this.MenuItemMode_Polyline.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// MenuItemMode_PolygonFill
			// 
			this.MenuItemMode_PolygonFill.Name = "MenuItemMode_PolygonFill";
			this.MenuItemMode_PolygonFill.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.MenuItemMode_PolygonFill.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_PolygonFill.Text = "ポリゴン(塗りつぶし)";
			this.MenuItemMode_PolygonFill.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// MenuItemMode_PolygonHole
			// 
			this.MenuItemMode_PolygonHole.Name = "MenuItemMode_PolygonHole";
			this.MenuItemMode_PolygonHole.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.MenuItemMode_PolygonHole.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_PolygonHole.Text = "ポリゴン(穴あけ)";
			this.MenuItemMode_PolygonHole.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// MenuItemMode_Corner
			// 
			this.MenuItemMode_Corner.Name = "MenuItemMode_Corner";
			this.MenuItemMode_Corner.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.MenuItemMode_Corner.Size = new System.Drawing.Size(231, 22);
			this.MenuItemMode_Corner.Text = "R面取り";
			this.MenuItemMode_Corner.Click += new System.EventHandler(this.MenuItemMode_Select_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(228, 6);
			// 
			// MenuItemPolyMode_Line
			// 
			this.MenuItemPolyMode_Line.Name = "MenuItemPolyMode_Line";
			this.MenuItemPolyMode_Line.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
			this.MenuItemPolyMode_Line.Size = new System.Drawing.Size(231, 22);
			this.MenuItemPolyMode_Line.Text = "直線";
			this.MenuItemPolyMode_Line.Click += new System.EventHandler(this.MenuItemPolyMode_Click);
			// 
			// MenuItemPolyMode_Arc
			// 
			this.MenuItemPolyMode_Arc.Name = "MenuItemPolyMode_Arc";
			this.MenuItemPolyMode_Arc.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
			this.MenuItemPolyMode_Arc.Size = new System.Drawing.Size(231, 22);
			this.MenuItemPolyMode_Arc.Text = "円弧";
			this.MenuItemPolyMode_Arc.Click += new System.EventHandler(this.MenuItemPolyMode_Click);
			// 
			// MenuItemPolyMode_Bow
			// 
			this.MenuItemPolyMode_Bow.Name = "MenuItemPolyMode_Bow";
			this.MenuItemPolyMode_Bow.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
			this.MenuItemPolyMode_Bow.Size = new System.Drawing.Size(231, 22);
			this.MenuItemPolyMode_Bow.Text = "弓型";
			this.MenuItemPolyMode_Bow.Click += new System.EventHandler(this.MenuItemPolyMode_Click);
			// 
			// スナップSToolStripMenuItem
			// 
			this.スナップSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSnap_Grid,
            this.MenuItemSnap_Vert,
            this.MenuItemSnap_Line});
			this.スナップSToolStripMenuItem.Name = "スナップSToolStripMenuItem";
			this.スナップSToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.スナップSToolStripMenuItem.Text = "スナップ(S)";
			// 
			// MenuItemSnap_Grid
			// 
			this.MenuItemSnap_Grid.Name = "MenuItemSnap_Grid";
			this.MenuItemSnap_Grid.Size = new System.Drawing.Size(151, 22);
			this.MenuItemSnap_Grid.Text = "グリッドにスナップ";
			this.MenuItemSnap_Grid.Click += new System.EventHandler(this.MenuItemSnap_Click);
			// 
			// MenuItemSnap_Vert
			// 
			this.MenuItemSnap_Vert.Name = "MenuItemSnap_Vert";
			this.MenuItemSnap_Vert.Size = new System.Drawing.Size(151, 22);
			this.MenuItemSnap_Vert.Text = "頂点にスナップ";
			this.MenuItemSnap_Vert.Click += new System.EventHandler(this.MenuItemSnap_Click);
			// 
			// MenuItemSnap_Line
			// 
			this.MenuItemSnap_Line.Name = "MenuItemSnap_Line";
			this.MenuItemSnap_Line.Size = new System.Drawing.Size(151, 22);
			this.MenuItemSnap_Line.Text = "線にスナップ";
			this.MenuItemSnap_Line.Click += new System.EventHandler(this.MenuItemSnap_Click);
			// 
			// MenuTextPositionX
			// 
			this.MenuTextPositionX.AcceptsTab = true;
			this.MenuTextPositionX.AutoSize = false;
			this.MenuTextPositionX.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MenuTextPositionX.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MenuTextPositionX.Name = "MenuTextPositionX";
			this.MenuTextPositionX.ReadOnly = true;
			this.MenuTextPositionX.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuTextPositionX.Size = new System.Drawing.Size(45, 20);
			this.MenuTextPositionX.Text = "200.00";
			this.MenuTextPositionX.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MenuTextPositionY
			// 
			this.MenuTextPositionY.AcceptsTab = true;
			this.MenuTextPositionY.AutoSize = false;
			this.MenuTextPositionY.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MenuTextPositionY.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MenuTextPositionY.Name = "MenuTextPositionY";
			this.MenuTextPositionY.ReadOnly = true;
			this.MenuTextPositionY.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.MenuTextPositionY.Size = new System.Drawing.Size(45, 20);
			this.MenuTextPositionY.Text = "200.00";
			this.MenuTextPositionY.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MenuTextHint
			// 
			this.MenuTextHint.AcceptsTab = true;
			this.MenuTextHint.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.MenuTextHint.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MenuTextHint.Name = "MenuTextHint";
			this.MenuTextHint.ReadOnly = true;
			this.MenuTextHint.Size = new System.Drawing.Size(300, 20);
			// 
			// DisplayArea
			// 
			this.DisplayArea.BackColor = System.Drawing.Color.Black;
			this.DisplayArea.Location = new System.Drawing.Point(0, 27);
			this.DisplayArea.Name = "DisplayArea";
			this.DisplayArea.Size = new System.Drawing.Size(762, 394);
			this.DisplayArea.TabIndex = 2;
			this.DisplayArea.TabStop = false;
			this.DisplayArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayArea_MouseDown);
			this.DisplayArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayArea_MouseMove);
			this.DisplayArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayArea_MouseUp);
			// 
			// ScrollBarY
			// 
			this.ScrollBarY.Location = new System.Drawing.Point(774, 27);
			this.ScrollBarY.Maximum = 512;
			this.ScrollBarY.Minimum = -512;
			this.ScrollBarY.Name = "ScrollBarY";
			this.ScrollBarY.Size = new System.Drawing.Size(17, 394);
			this.ScrollBarY.TabIndex = 3;
			this.ScrollBarY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarY_Scroll);
			// 
			// ScrollBarX
			// 
			this.ScrollBarX.Location = new System.Drawing.Point(0, 424);
			this.ScrollBarX.Maximum = 512;
			this.ScrollBarX.Minimum = -512;
			this.ScrollBarX.Name = "ScrollBarX";
			this.ScrollBarX.Size = new System.Drawing.Size(762, 17);
			this.ScrollBarX.TabIndex = 4;
			this.ScrollBarX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarX_Scroll);
			// 
			// DisplayTimer
			// 
			this.DisplayTimer.Tick += new System.EventHandler(this.DisplayTimer_Tick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 474);
			this.Controls.Add(this.ScrollBarX);
			this.Controls.Add(this.ScrollBarY);
			this.Controls.Add(this.DisplayArea);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(256, 256);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DisplayArea)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile_New;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile_Open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile_Overwrite;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile_SavePDF;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Undo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Cut;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Copy;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Paste;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Delete;
        private System.Windows.Forms.ToolStripMenuItem モードMToolStripMenuItem;
        private System.Windows.Forms.PictureBox DisplayArea;
        private System.Windows.Forms.VScrollBar ScrollBarY;
        private System.Windows.Forms.HScrollBar ScrollBarX;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMode_MoveModelOrigin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMode_Polyline;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMode_PolygonFill;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMode_PolygonHole;
        private System.Windows.Forms.Timer DisplayTimer;
        private System.Windows.Forms.ToolStripMenuItem 表示DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_100;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_ZoomIn;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_ZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_MoveToModelOrigin;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_MoveToGlobalOrigin;
        private System.Windows.Forms.ToolStripMenuItem スナップSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSnap_Grid;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSnap_Vert;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSnap_Line;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_GlobalGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_ModelGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit_Cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_SetGridPitch;
		private System.Windows.Forms.ToolStripMenuItem MenuItemMode_Corner;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem MenuItemPolyMode_Line;
		private System.Windows.Forms.ToolStripMenuItem MenuItemMode_Select;
		private System.Windows.Forms.ToolStripMenuItem MenuItemPolyMode_Arc;
		private System.Windows.Forms.ToolStripMenuItem MenuItemPolyMode_Bow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripTextBox MenuTextPositionX;
		private System.Windows.Forms.ToolStripTextBox MenuTextPositionY;
		private System.Windows.Forms.ToolStripTextBox MenuTextHint;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_ModelList;
		private System.Windows.Forms.ToolStripMenuItem MenuItemDisp_LayerList;
	}
}

