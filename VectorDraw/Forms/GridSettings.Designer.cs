
namespace VectorDraw.Forms {
	partial class GridSettings {
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
			this.numPix = new System.Windows.Forms.NumericUpDown();
			this.numScale = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numPix)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
			this.SuspendLayout();
			// 
			// numPix
			// 
			this.numPix.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numPix.Location = new System.Drawing.Point(12, 12);
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
			this.numPix.Size = new System.Drawing.Size(63, 22);
			this.numPix.TabIndex = 0;
			this.numPix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numPix.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numScale
			// 
			this.numScale.DecimalPlaces = 2;
			this.numScale.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.numScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.numScale.Location = new System.Drawing.Point(12, 40);
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
			this.numScale.Size = new System.Drawing.Size(63, 22);
			this.numScale.TabIndex = 1;
			this.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(77, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "ピクセルあたり";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(77, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "mm";
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(125, 40);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(55, 23);
			this.btnApply.TabIndex = 4;
			this.btnApply.Text = "反映";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// GridSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(192, 73);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numScale);
			this.Controls.Add(this.numPix);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GridSettings";
			this.Text = "グローバル座標のグリッドを設定";
			((System.ComponentModel.ISupportInitialize)(this.numPix)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numPix;
		private System.Windows.Forms.NumericUpDown numScale;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnApply;
	}
}