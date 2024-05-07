
namespace VectorDraw.Forms {
	partial class ModelList {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.モデル追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.グループ追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.コピーToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.貼り付けToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numScale = new System.Windows.Forms.NumericUpDown();
			this.numPix = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbLayer = new System.Windows.Forms.ComboBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numPix)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.編集EToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(496, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 編集EToolStripMenuItem
			// 
			this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.モデル追加ToolStripMenuItem,
            this.グループ追加ToolStripMenuItem,
            this.toolStripSeparator1,
            this.削除ToolStripMenuItem,
            this.コピーToolStripMenuItem,
            this.貼り付けToolStripMenuItem});
			this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
			this.編集EToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.編集EToolStripMenuItem.Text = "編集(E)";
			// 
			// モデル追加ToolStripMenuItem
			// 
			this.モデル追加ToolStripMenuItem.Name = "モデル追加ToolStripMenuItem";
			this.モデル追加ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.モデル追加ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.モデル追加ToolStripMenuItem.Text = "モデル追加";
			this.モデル追加ToolStripMenuItem.Click += new System.EventHandler(this.モデル追加ToolStripMenuItem_Click);
			// 
			// グループ追加ToolStripMenuItem
			// 
			this.グループ追加ToolStripMenuItem.Name = "グループ追加ToolStripMenuItem";
			this.グループ追加ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.グループ追加ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.グループ追加ToolStripMenuItem.Text = "グループ追加";
			this.グループ追加ToolStripMenuItem.Click += new System.EventHandler(this.グループ追加ToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
			// 
			// 削除ToolStripMenuItem
			// 
			this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
			this.削除ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.削除ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.削除ToolStripMenuItem.Text = "削除";
			this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
			// 
			// コピーToolStripMenuItem
			// 
			this.コピーToolStripMenuItem.Name = "コピーToolStripMenuItem";
			this.コピーToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.コピーToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.コピーToolStripMenuItem.Text = "コピー";
			this.コピーToolStripMenuItem.Click += new System.EventHandler(this.コピーToolStripMenuItem_Click);
			// 
			// 貼り付けToolStripMenuItem
			// 
			this.貼り付けToolStripMenuItem.Name = "貼り付けToolStripMenuItem";
			this.貼り付けToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.貼り付けToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
			this.貼り付けToolStripMenuItem.Text = "貼り付け";
			this.貼り付けToolStripMenuItem.Click += new System.EventHandler(this.貼り付けToolStripMenuItem_Click);
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.treeView1.Location = new System.Drawing.Point(12, 27);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(121, 97);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.numScale);
			this.panel1.Controls.Add(this.numPix);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cmbLayer);
			this.panel1.Controls.Add(this.txtName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(243, 27);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 165);
			this.panel1.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(67, 139);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "mm";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(67, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "ピクセルあたり";
			// 
			// numScale
			// 
			this.numScale.DecimalPlaces = 2;
			this.numScale.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numScale.Location = new System.Drawing.Point(6, 137);
			this.numScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numScale.Name = "numScale";
			this.numScale.Size = new System.Drawing.Size(59, 20);
			this.numScale.TabIndex = 6;
			this.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numScale.ValueChanged += new System.EventHandler(this.numScale_ValueChanged);
			// 
			// numPix
			// 
			this.numPix.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numPix.Location = new System.Drawing.Point(6, 111);
			this.numPix.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.numPix.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numPix.Name = "numPix";
			this.numPix.Size = new System.Drawing.Size(59, 20);
			this.numPix.TabIndex = 5;
			this.numPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numPix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numPix.ValueChanged += new System.EventHandler(this.numPix_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(3, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "グリッド設定";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(3, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "レイヤー";
			// 
			// cmbLayer
			// 
			this.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLayer.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbLayer.FormattingEnabled = true;
			this.cmbLayer.Location = new System.Drawing.Point(6, 64);
			this.cmbLayer.Name = "cmbLayer";
			this.cmbLayer.Size = new System.Drawing.Size(191, 21);
			this.cmbLayer.TabIndex = 2;
			this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.cmbLayer_SelectedIndexChanged);
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtName.Location = new System.Drawing.Point(6, 18);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(191, 20);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "名称";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// ModelList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 361);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(128, 128);
			this.Name = "ModelList";
			this.Text = "モデル一覧";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModelList_FormClosed);
			this.Load += new System.EventHandler(this.ModelList_Load);
			this.SizeChanged += new System.EventHandler(this.ModelList_SizeChanged);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numPix)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem モデル追加ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem コピーToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 貼り付けToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStripMenuItem グループ追加ToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbLayer;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numPix;
		private System.Windows.Forms.NumericUpDown numScale;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}