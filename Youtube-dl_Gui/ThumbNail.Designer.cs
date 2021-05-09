using System.ComponentModel;

namespace Youtube_dl_Gui {
    partial class ThumbNail {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.BackPanel = new System.Windows.Forms.Panel();
            this.RichText = new System.Windows.Forms.RichTextBox();
            this.ThumbPicture = new System.Windows.Forms.PictureBox();
            this.BackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ThumbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BackPanel
            // 
            this.BackPanel.Controls.Add(this.RichText);
            this.BackPanel.Controls.Add(this.ThumbPicture);
            this.BackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPanel.Location = new System.Drawing.Point(0, 0);
            this.BackPanel.Margin = new System.Windows.Forms.Padding(1000, 0, 0, 0);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(402, 94);
            this.BackPanel.TabIndex = 0;
            // 
            // RichText
            // 
            this.RichText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RichText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichText.Dock = System.Windows.Forms.DockStyle.Right;
            this.RichText.Location = new System.Drawing.Point(176, 0);
            this.RichText.Margin = new System.Windows.Forms.Padding(0);
            this.RichText.MaximumSize = new System.Drawing.Size(226, 94);
            this.RichText.MinimumSize = new System.Drawing.Size(226, 94);
            this.RichText.Name = "RichText";
            this.RichText.ReadOnly = true;
            this.RichText.Size = new System.Drawing.Size(226, 94);
            this.RichText.TabIndex = 3;
            this.RichText.Text = "";
            // 
            // ThumbPicture
            // 
            this.ThumbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ThumbPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.ThumbPicture.Location = new System.Drawing.Point(0, 0);
            this.ThumbPicture.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.ThumbPicture.MaximumSize = new System.Drawing.Size(168, 94);
            this.ThumbPicture.MinimumSize = new System.Drawing.Size(168, 94);
            this.ThumbPicture.Name = "ThumbPicture";
            this.ThumbPicture.Size = new System.Drawing.Size(168, 94);
            this.ThumbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ThumbPicture.TabIndex = 2;
            this.ThumbPicture.TabStop = false;
            // 
            // ThumbNail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BackPanel);
            this.MaximumSize = new System.Drawing.Size(404, 98);
            this.MinimumSize = new System.Drawing.Size(402, 94);
            this.Name = "ThumbNail";
            this.Size = new System.Drawing.Size(402, 94);
            this.BackPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ThumbPicture)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox ThumbPicture;
        private System.Windows.Forms.RichTextBox RichText;

        private System.Windows.Forms.Panel BackPanel;

        #endregion
    }
}