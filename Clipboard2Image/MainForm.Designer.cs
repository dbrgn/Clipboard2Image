namespace Clipboard2Image
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.cbxFileFormat = new System.Windows.Forms.ComboBox();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.pbxFilePreview = new System.Windows.Forms.PictureBox();
            this.lblFileFormat = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnQuicksaveFile = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxFileFormat
            // 
            this.cbxFileFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFileFormat.FormattingEnabled = true;
            this.cbxFileFormat.Items.AddRange(new object[] {
            "png",
            "jpg",
            "gif",
            "bmp"});
            this.cbxFileFormat.Location = new System.Drawing.Point(86, 9);
            this.cbxFileFormat.Name = "cbxFileFormat";
            this.cbxFileFormat.Size = new System.Drawing.Size(81, 21);
            this.cbxFileFormat.TabIndex = 0;
            this.cbxFileFormat.SelectedIndexChanged += new System.EventHandler(this.cbxFileFormat_SelectedIndexChanged);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Enabled = false;
            this.btnSaveFile.Location = new System.Drawing.Point(12, 36);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(155, 33);
            this.btnSaveFile.TabIndex = 1;
            this.btnSaveFile.Text = "Save Image";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // pbxFilePreview
            // 
            this.pbxFilePreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbxFilePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxFilePreview.Location = new System.Drawing.Point(174, 9);
            this.pbxFilePreview.Name = "pbxFilePreview";
            this.pbxFilePreview.Size = new System.Drawing.Size(100, 100);
            this.pbxFilePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFilePreview.TabIndex = 2;
            this.pbxFilePreview.TabStop = false;
            // 
            // lblFileFormat
            // 
            this.lblFileFormat.AutoSize = true;
            this.lblFileFormat.Location = new System.Drawing.Point(9, 12);
            this.lblFileFormat.Name = "lblFileFormat";
            this.lblFileFormat.Size = new System.Drawing.Size(71, 13);
            this.lblFileFormat.TabIndex = 3;
            this.lblFileFormat.Text = "Image Format";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "All files|*.*";
            // 
            // btnQuicksaveFile
            // 
            this.btnQuicksaveFile.Enabled = false;
            this.btnQuicksaveFile.Location = new System.Drawing.Point(12, 76);
            this.btnQuicksaveFile.Name = "btnQuicksaveFile";
            this.btnQuicksaveFile.Size = new System.Drawing.Size(155, 33);
            this.btnQuicksaveFile.TabIndex = 7;
            this.btnQuicksaveFile.Text = "Quicksave to Desktop";
            this.btnQuicksaveFile.UseVisualStyleBackColor = true;
            this.btnQuicksaveFile.Click += new System.EventHandler(this.btnQuicksaveImage_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(240, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(279, 114);
            this.Controls.Add(this.btnQuicksaveFile);
            this.Controls.Add(this.lblFileFormat);
            this.Controls.Add(this.pbxFilePreview);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.cbxFileFormat);
            this.Controls.Add(this.btnClose);
            this.MaximumSize = new System.Drawing.Size(295, 152);
            this.MinimumSize = new System.Drawing.Size(295, 152);
            this.Name = "MainForm";
            this.Text = "Clipboard2Image";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFilePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxFileFormat;
		private System.Windows.Forms.Button btnSaveFile;
		private System.Windows.Forms.PictureBox pbxFilePreview;
		private System.Windows.Forms.Label lblFileFormat;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnQuicksaveFile;
		private System.Windows.Forms.Button btnClose;
	}
}

