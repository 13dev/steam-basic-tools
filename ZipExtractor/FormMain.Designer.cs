﻿namespace ZipExtractor
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.labelInformation = new System.Windows.Forms.Label();
			this.lbPercent = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(86, 53);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(446, 23);
			this.progressBar.TabIndex = 0;
			this.progressBar.UseWaitCursor = true;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Image = global::ZipExtractor.Properties.Resources.ZipExtractor;
			this.pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(64, 64);
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			this.pictureBoxIcon.UseWaitCursor = true;
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.labelInformation.Location = new System.Drawing.Point(82, 12);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(78, 19);
			this.labelInformation.TabIndex = 3;
			this.labelInformation.Text = "Extracting...";
			this.labelInformation.UseWaitCursor = true;
			// 
			// lbPercent
			// 
			this.lbPercent.BackColor = System.Drawing.Color.Transparent;
			this.lbPercent.Location = new System.Drawing.Point(433, 32);
			this.lbPercent.Name = "lbPercent";
			this.lbPercent.Size = new System.Drawing.Size(100, 23);
			this.lbPercent.TabIndex = 4;
			this.lbPercent.Text = "0% complete.";
			this.lbPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(544, 88);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.lbPercent);
			this.Controls.Add(this.labelInformation);
			this.Controls.Add(this.pictureBoxIcon);
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Installing update...";
			this.UseWaitCursor = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Shown += new System.EventHandler(this.FormMain_Shown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelInformation;
		private System.Windows.Forms.Label lbPercent;
	}
}

