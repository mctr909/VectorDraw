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
            this.toolStripMenuItem_file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_file_open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_file_overwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_file_save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_file_pdf = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_esc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_edit_cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_edit_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.表示DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_disp_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_disp_zoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_disp_zoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_disp_moveToLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_disp_moveToGlobalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_disp_localGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_disp_globalGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.設定SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_snap_grid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_snap_vert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_snap_line = new System.Windows.Forms.ToolStripMenuItem();
            this.モードMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_mode_select = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_mode_moveLocalOrigin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_mode_polyline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_mode_polygonFill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_mode_polygonHole = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.toolStripMenuItem_file_new,
            this.toolStripSeparator1,
            this.toolStripMenuItem_file_open,
            this.toolStripSeparator2,
            this.toolStripMenuItem_file_overwrite,
            this.toolStripMenuItem_file_save,
            this.toolStripSeparator3,
            this.toolStripMenuItem_file_pdf});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.ファイルFToolStripMenuItem.Text = "ファイル(F)";
            // 
            // toolStripMenuItem_file_new
            // 
            this.toolStripMenuItem_file_new.Name = "toolStripMenuItem_file_new";
            this.toolStripMenuItem_file_new.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem_file_new.Text = "新規作成";
            this.toolStripMenuItem_file_new.Click += new System.EventHandler(this.toolStripMenuItem_file_new_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItem_file_open
            // 
            this.toolStripMenuItem_file_open.Name = "toolStripMenuItem_file_open";
            this.toolStripMenuItem_file_open.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem_file_open.Text = "開く";
            this.toolStripMenuItem_file_open.Click += new System.EventHandler(this.toolStripMenuItem_file_open_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItem_file_overwrite
            // 
            this.toolStripMenuItem_file_overwrite.Name = "toolStripMenuItem_file_overwrite";
            this.toolStripMenuItem_file_overwrite.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_file_overwrite.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem_file_overwrite.Text = "上書き保存";
            this.toolStripMenuItem_file_overwrite.Click += new System.EventHandler(this.toolStripMenuItem_file_overwrite_Click);
            // 
            // toolStripMenuItem_file_save
            // 
            this.toolStripMenuItem_file_save.Name = "toolStripMenuItem_file_save";
            this.toolStripMenuItem_file_save.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem_file_save.Text = "名前を付けて保存";
            this.toolStripMenuItem_file_save.Click += new System.EventHandler(this.toolStripMenuItem_file_save_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItem_file_pdf
            // 
            this.toolStripMenuItem_file_pdf.Name = "toolStripMenuItem_file_pdf";
            this.toolStripMenuItem_file_pdf.Size = new System.Drawing.Size(170, 22);
            this.toolStripMenuItem_file_pdf.Text = "PDF出力";
            this.toolStripMenuItem_file_pdf.Click += new System.EventHandler(this.toolStripMenuItem_file_pdf_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_edit_undo,
            this.toolStripMenuItem_edit_redo,
            this.toolStripMenuItem_edit_esc,
            this.toolStripSeparator4,
            this.toolStripMenuItem_edit_cut,
            this.toolStripMenuItem_edit_copy,
            this.toolStripMenuItem_edit_paste,
            this.toolStripMenuItem_edit_delete});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.編集EToolStripMenuItem.Text = "編集(E)";
            // 
            // toolStripMenuItem_edit_undo
            // 
            this.toolStripMenuItem_edit_undo.Name = "toolStripMenuItem_edit_undo";
            this.toolStripMenuItem_edit_undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem_edit_undo.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_undo.Text = "元に戻す";
            this.toolStripMenuItem_edit_undo.Click += new System.EventHandler(this.toolStripMenuItem_edit_undo_Click);
            // 
            // toolStripMenuItem_edit_redo
            // 
            this.toolStripMenuItem_edit_redo.Name = "toolStripMenuItem_edit_redo";
            this.toolStripMenuItem_edit_redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.toolStripMenuItem_edit_redo.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_redo.Text = "やり直し";
            this.toolStripMenuItem_edit_redo.Click += new System.EventHandler(this.toolStripMenuItem_edit_redo_Click);
            // 
            // toolStripMenuItem_edit_esc
            // 
            this.toolStripMenuItem_edit_esc.Name = "toolStripMenuItem_edit_esc";
            this.toolStripMenuItem_edit_esc.ShortcutKeyDisplayString = "Esc";
            this.toolStripMenuItem_edit_esc.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_esc.Text = "取り消し";
            this.toolStripMenuItem_edit_esc.Click += new System.EventHandler(this.toolStripMenuItem_edit_esc_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // toolStripMenuItem_edit_cut
            // 
            this.toolStripMenuItem_edit_cut.Name = "toolStripMenuItem_edit_cut";
            this.toolStripMenuItem_edit_cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItem_edit_cut.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_cut.Text = "切り取り";
            this.toolStripMenuItem_edit_cut.Click += new System.EventHandler(this.toolStripMenuItem_edit_cut_Click);
            // 
            // toolStripMenuItem_edit_copy
            // 
            this.toolStripMenuItem_edit_copy.Name = "toolStripMenuItem_edit_copy";
            this.toolStripMenuItem_edit_copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItem_edit_copy.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_copy.Text = "コピー";
            this.toolStripMenuItem_edit_copy.Click += new System.EventHandler(this.toolStripMenuItem_edit_copy_Click);
            // 
            // toolStripMenuItem_edit_paste
            // 
            this.toolStripMenuItem_edit_paste.Name = "toolStripMenuItem_edit_paste";
            this.toolStripMenuItem_edit_paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem_edit_paste.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_paste.Text = "貼り付け";
            this.toolStripMenuItem_edit_paste.Click += new System.EventHandler(this.toolStripMenuItem_edit_paste_Click);
            // 
            // toolStripMenuItem_edit_delete
            // 
            this.toolStripMenuItem_edit_delete.Name = "toolStripMenuItem_edit_delete";
            this.toolStripMenuItem_edit_delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItem_edit_delete.Size = new System.Drawing.Size(157, 22);
            this.toolStripMenuItem_edit_delete.Text = "削除";
            this.toolStripMenuItem_edit_delete.Click += new System.EventHandler(this.toolStripMenuItem_edit_delete_Click);
            // 
            // 表示DToolStripMenuItem
            // 
            this.表示DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_disp_100,
            this.toolStripMenuItem_disp_zoomIn,
            this.toolStripMenuItem_disp_zoomOut,
            this.toolStripSeparator6,
            this.toolStripMenuItem_disp_moveToLocalOrigin,
            this.toolStripMenuItem_disp_moveToGlobalOrigin,
            this.toolStripSeparator9,
            this.toolStripMenuItem_disp_localGrid,
            this.toolStripMenuItem_disp_globalGrid});
            this.表示DToolStripMenuItem.Name = "表示DToolStripMenuItem";
            this.表示DToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.表示DToolStripMenuItem.Text = "表示(D)";
            // 
            // toolStripMenuItem_disp_100
            // 
            this.toolStripMenuItem_disp_100.Name = "toolStripMenuItem_disp_100";
            this.toolStripMenuItem_disp_100.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.toolStripMenuItem_disp_100.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_100.Text = "等倍";
            this.toolStripMenuItem_disp_100.Click += new System.EventHandler(this.toolStripMenuItem_disp_100_Click);
            // 
            // toolStripMenuItem_disp_zoomIn
            // 
            this.toolStripMenuItem_disp_zoomIn.Name = "toolStripMenuItem_disp_zoomIn";
            this.toolStripMenuItem_disp_zoomIn.ShortcutKeyDisplayString = "Ctrl+(+)";
            this.toolStripMenuItem_disp_zoomIn.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.toolStripMenuItem_disp_zoomIn.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_zoomIn.Text = "拡大";
            this.toolStripMenuItem_disp_zoomIn.Click += new System.EventHandler(this.toolStripMenuItem_disp_zoomIn_Click);
            // 
            // toolStripMenuItem_disp_zoomOut
            // 
            this.toolStripMenuItem_disp_zoomOut.Name = "toolStripMenuItem_disp_zoomOut";
            this.toolStripMenuItem_disp_zoomOut.ShortcutKeyDisplayString = "Ctrl+(-)";
            this.toolStripMenuItem_disp_zoomOut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.toolStripMenuItem_disp_zoomOut.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_zoomOut.Text = "縮小";
            this.toolStripMenuItem_disp_zoomOut.Click += new System.EventHandler(this.toolStripMenuItem_disp_zoomOut_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(233, 6);
            // 
            // toolStripMenuItem_disp_moveToLocalOrigin
            // 
            this.toolStripMenuItem_disp_moveToLocalOrigin.Name = "toolStripMenuItem_disp_moveToLocalOrigin";
            this.toolStripMenuItem_disp_moveToLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem_disp_moveToLocalOrigin.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_moveToLocalOrigin.Text = "ローカル原点に移動";
            this.toolStripMenuItem_disp_moveToLocalOrigin.Click += new System.EventHandler(this.toolStripMenuItem_disp_moveToLocalOrigin_Click);
            // 
            // toolStripMenuItem_disp_moveToGlobalOrigin
            // 
            this.toolStripMenuItem_disp_moveToGlobalOrigin.Name = "toolStripMenuItem_disp_moveToGlobalOrigin";
            this.toolStripMenuItem_disp_moveToGlobalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.toolStripMenuItem_disp_moveToGlobalOrigin.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_moveToGlobalOrigin.Text = "グローバル原点に移動";
            this.toolStripMenuItem_disp_moveToGlobalOrigin.Click += new System.EventHandler(this.toolStripMenuItem_disp_moveToGlobalOrigin_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(233, 6);
            // 
            // toolStripMenuItem_disp_localGrid
            // 
            this.toolStripMenuItem_disp_localGrid.Name = "toolStripMenuItem_disp_localGrid";
            this.toolStripMenuItem_disp_localGrid.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_localGrid.Text = "グリッドをローカル座標に合わせる";
            this.toolStripMenuItem_disp_localGrid.Click += new System.EventHandler(this.toolStripMenuItem_disp_localGrid_Click);
            // 
            // toolStripMenuItem_disp_globalGrid
            // 
            this.toolStripMenuItem_disp_globalGrid.Name = "toolStripMenuItem_disp_globalGrid";
            this.toolStripMenuItem_disp_globalGrid.Size = new System.Drawing.Size(236, 22);
            this.toolStripMenuItem_disp_globalGrid.Text = "グリッドをグローバル座標に合わせる";
            this.toolStripMenuItem_disp_globalGrid.Click += new System.EventHandler(this.toolStripMenuItem_disp_globalGrid_Click);
            // 
            // 設定SToolStripMenuItem
            // 
            this.設定SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_snap_grid,
            this.toolStripMenuItem_snap_vert,
            this.toolStripMenuItem_snap_line});
            this.設定SToolStripMenuItem.Name = "設定SToolStripMenuItem";
            this.設定SToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.設定SToolStripMenuItem.Text = "スナップ(S)";
            // 
            // toolStripMenuItem_snap_grid
            // 
            this.toolStripMenuItem_snap_grid.Name = "toolStripMenuItem_snap_grid";
            this.toolStripMenuItem_snap_grid.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem_snap_grid.Text = "グリッドにスナップ";
            this.toolStripMenuItem_snap_grid.Click += new System.EventHandler(this.toolStripMenuItem_snap_grid_Click);
            // 
            // toolStripMenuItem_snap_vert
            // 
            this.toolStripMenuItem_snap_vert.Name = "toolStripMenuItem_snap_vert";
            this.toolStripMenuItem_snap_vert.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem_snap_vert.Text = "頂点にスナップ";
            this.toolStripMenuItem_snap_vert.Click += new System.EventHandler(this.toolStripMenuItem_snap_vert_Click);
            // 
            // toolStripMenuItem_snap_line
            // 
            this.toolStripMenuItem_snap_line.Name = "toolStripMenuItem_snap_line";
            this.toolStripMenuItem_snap_line.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem_snap_line.Text = "線にスナップ";
            this.toolStripMenuItem_snap_line.Click += new System.EventHandler(this.toolStripMenuItem_snap_line_Click);
            // 
            // モードMToolStripMenuItem
            // 
            this.モードMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_mode_select,
            this.toolStripSeparator8,
            this.toolStripMenuItem_mode_moveLocalOrigin,
            this.toolStripSeparator5,
            this.toolStripMenuItem_mode_polyline,
            this.toolStripMenuItem_mode_polygonFill,
            this.toolStripMenuItem_mode_polygonHole});
            this.モードMToolStripMenuItem.Name = "モードMToolStripMenuItem";
            this.モードMToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.モードMToolStripMenuItem.Text = "モード(M)";
            // 
            // toolStripMenuItem_mode_select
            // 
            this.toolStripMenuItem_mode_select.Name = "toolStripMenuItem_mode_select";
            this.toolStripMenuItem_mode_select.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_mode_select.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem_mode_select.Text = "選択";
            this.toolStripMenuItem_mode_select.Click += new System.EventHandler(this.toolStripMenuItem_mode_select_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(238, 6);
            // 
            // toolStripMenuItem_mode_moveLocalOrigin
            // 
            this.toolStripMenuItem_mode_moveLocalOrigin.Name = "toolStripMenuItem_mode_moveLocalOrigin";
            this.toolStripMenuItem_mode_moveLocalOrigin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem_mode_moveLocalOrigin.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem_mode_moveLocalOrigin.Text = "ローカル原点を移動";
            this.toolStripMenuItem_mode_moveLocalOrigin.Click += new System.EventHandler(this.toolStripMenuItem_mode_moveLocalOrigin_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(238, 6);
            // 
            // toolStripMenuItem_mode_polyline
            // 
            this.toolStripMenuItem_mode_polyline.Name = "toolStripMenuItem_mode_polyline";
            this.toolStripMenuItem_mode_polyline.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItem_mode_polyline.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem_mode_polyline.Text = "ポリライン";
            this.toolStripMenuItem_mode_polyline.Click += new System.EventHandler(this.toolStripMenuItem_mode_polyline_Click);
            // 
            // toolStripMenuItem_mode_polygonFill
            // 
            this.toolStripMenuItem_mode_polygonFill.Name = "toolStripMenuItem_mode_polygonFill";
            this.toolStripMenuItem_mode_polygonFill.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem_mode_polygonFill.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem_mode_polygonFill.Text = "ポリゴン塗りつぶし";
            this.toolStripMenuItem_mode_polygonFill.Click += new System.EventHandler(this.toolStripMenuItem_mode_polygonFill_Click);
            // 
            // toolStripMenuItem_mode_polygonHole
            // 
            this.toolStripMenuItem_mode_polygonHole.Name = "toolStripMenuItem_mode_polygonHole";
            this.toolStripMenuItem_mode_polygonHole.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
            this.toolStripMenuItem_mode_polygonHole.Size = new System.Drawing.Size(241, 22);
            this.toolStripMenuItem_mode_polygonHole.Text = "ポリゴン穴あけ";
            this.toolStripMenuItem_mode_polygonHole.Click += new System.EventHandler(this.toolStripMenuItem_mode_polygonHole_Click);
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
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(0, 424);
            this.hScrollBar1.Maximum = 2000;
            this.hScrollBar1.Minimum = -2000;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(762, 17);
            this.hScrollBar1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file_new;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file_open;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file_overwrite;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_file_pdf;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_undo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_paste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_delete;
        private System.Windows.Forms.ToolStripMenuItem モードMToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mode_moveLocalOrigin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mode_polyline;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mode_polygonFill;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mode_polygonHole;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 表示DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_100;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_zoomIn;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_zoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_moveToLocalOrigin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_moveToGlobalOrigin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_mode_select;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 設定SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_snap_grid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_snap_vert;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_snap_line;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_globalGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_disp_localGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_edit_esc;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

