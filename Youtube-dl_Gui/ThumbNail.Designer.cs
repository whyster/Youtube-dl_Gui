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
            this.thumbnail_box = new System.Windows.Forms.PictureBox();
            this.description_rich = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize) (this.thumbnail_box)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnail_box
            // 
            this.thumbnail_box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thumbnail_box.Dock = System.Windows.Forms.DockStyle.Left;
            this.thumbnail_box.Location = new System.Drawing.Point(0, 0);
            this.thumbnail_box.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.thumbnail_box.MaximumSize = new System.Drawing.Size(168, 94);
            this.thumbnail_box.MinimumSize = new System.Drawing.Size(168, 94);
            this.thumbnail_box.Name = "thumbnail_box";
            this.thumbnail_box.Size = new System.Drawing.Size(168, 94);
            this.thumbnail_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.thumbnail_box.TabIndex = 0;
            this.thumbnail_box.TabStop = false;
            // 
            // description_rich
            // 
            this.description_rich.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description_rich.Dock = System.Windows.Forms.DockStyle.Right;
            this.description_rich.Location = new System.Drawing.Point(174, 0);
            this.description_rich.Margin = new System.Windows.Forms.Padding(0);
            this.description_rich.MaximumSize = new System.Drawing.Size(226, 94);
            this.description_rich.MinimumSize = new System.Drawing.Size(226, 94);
            this.description_rich.Name = "description_rich";
            this.description_rich.Size = new System.Drawing.Size(226, 94);
            this.description_rich.TabIndex = 1;
            this.description_rich.Text = "";
            // 
            // ThumbNail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.description_rich);
            this.Controls.Add(this.thumbnail_box);
            this.MaximumSize = new System.Drawing.Size(402, 94);
            this.MinimumSize = new System.Drawing.Size(402, 94);
            this.Name = "ThumbNail";
            this.Size = new System.Drawing.Size(400, 92);
            ((System.ComponentModel.ISupportInitialize) (this.thumbnail_box)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox thumbnail_box;
        private System.Windows.Forms.RichTextBox description_rich;

        private System.Windows.Forms.RichTextBox richTextBox1;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}