namespace VectorDraw {
	partial class Group {
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
			this.Menu = new System.Windows.Forms.MenuStrip();
			this.MenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_EditAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_EditDel = new System.Windows.Forms.ToolStripMenuItem();
			this.TreeView = new System.Windows.Forms.TreeView();
			this.Menu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Menu
			// 
			this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Edit});
			this.Menu.Location = new System.Drawing.Point(0, 0);
			this.Menu.Name = "Menu";
			this.Menu.Size = new System.Drawing.Size(229, 24);
			this.Menu.TabIndex = 0;
			this.Menu.Text = "menuStrip1";
			// 
			// MenuItem_Edit
			// 
			this.MenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_EditAdd,
            this.MenuItem_EditDel});
			this.MenuItem_Edit.Name = "MenuItem_Edit";
			this.MenuItem_Edit.Size = new System.Drawing.Size(57, 20);
			this.MenuItem_Edit.Text = "編集(E)";
			// 
			// MenuItem_EditAdd
			// 
			this.MenuItem_EditAdd.Name = "MenuItem_EditAdd";
			this.MenuItem_EditAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
			this.MenuItem_EditAdd.Size = new System.Drawing.Size(137, 22);
			this.MenuItem_EditAdd.Text = "追加";
			this.MenuItem_EditAdd.Click += new System.EventHandler(this.MenuItem_EditAdd_Click);
			// 
			// MenuItem_EditDel
			// 
			this.MenuItem_EditDel.Name = "MenuItem_EditDel";
			this.MenuItem_EditDel.ShortcutKeyDisplayString = "";
			this.MenuItem_EditDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.MenuItem_EditDel.Size = new System.Drawing.Size(137, 22);
			this.MenuItem_EditDel.Text = "削除";
			this.MenuItem_EditDel.Click += new System.EventHandler(this.MenuItem_EditDel_Click);
			// 
			// TreeView
			// 
			this.TreeView.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TreeView.Location = new System.Drawing.Point(12, 27);
			this.TreeView.Name = "TreeView";
			this.TreeView.Size = new System.Drawing.Size(121, 97);
			this.TreeView.TabIndex = 1;
			// 
			// Group
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(229, 266);
			this.ControlBox = false;
			this.Controls.Add(this.TreeView);
			this.Controls.Add(this.Menu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MainMenuStrip = this.Menu;
			this.MinimumSize = new System.Drawing.Size(100, 100);
			this.Name = "Group";
			this.Text = "グループ編集";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Group_FormClosing);
			this.Load += new System.EventHandler(this.Group_Load);
			this.SizeChanged += new System.EventHandler(this.Group_SizeChanged);
			this.Menu.ResumeLayout(false);
			this.Menu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip Menu;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Edit;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_EditAdd;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_EditDel;
		private System.Windows.Forms.TreeView TreeView;
	}
}