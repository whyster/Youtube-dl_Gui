namespace Youtube_dl_Gui {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this._url_label = new System.Windows.Forms.Label();
            this.video_textbox = new System.Windows.Forms.TextBox();
            this.add_url_button = new System.Windows.Forms.Button();
            this.videos_panel = new System.Windows.Forms.Panel();
            this.download_button = new System.Windows.Forms.Button();
            this.path_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _url_label
            // 
            this._url_label.Location = new System.Drawing.Point(12, 20);
            this._url_label.Name = "_url_label";
            this._url_label.Size = new System.Drawing.Size(119, 20);
            this._url_label.TabIndex = 1;
            this._url_label.Text = "Video Url";
            // 
            // video_textbox
            // 
            this.video_textbox.Location = new System.Drawing.Point(12, 32);
            this.video_textbox.Name = "video_textbox";
            this.video_textbox.Size = new System.Drawing.Size(553, 20);
            this.video_textbox.TabIndex = 2;
            // 
            // add_url_button
            // 
            this.add_url_button.Location = new System.Drawing.Point(439, 58);
            this.add_url_button.Name = "add_url_button";
            this.add_url_button.Size = new System.Drawing.Size(126, 30);
            this.add_url_button.TabIndex = 3;
            this.add_url_button.Text = "Add Url";
            this.add_url_button.UseVisualStyleBackColor = true;
            this.add_url_button.Click += new System.EventHandler(this.add_url_click);
            // 
            // videos_panel
            // 
            this.videos_panel.AutoScroll = true;
            this.videos_panel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.videos_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.videos_panel.Location = new System.Drawing.Point(12, 58);
            this.videos_panel.Name = "videos_panel";
            this.videos_panel.Size = new System.Drawing.Size(421, 302);
            this.videos_panel.TabIndex = 4;
            // 
            // download_button
            // 
            this.download_button.Location = new System.Drawing.Point(439, 94);
            this.download_button.Name = "download_button";
            this.download_button.Size = new System.Drawing.Size(126, 30);
            this.download_button.TabIndex = 5;
            this.download_button.Text = "Download";
            this.download_button.UseVisualStyleBackColor = true;
            this.download_button.Click += new System.EventHandler(this.download_button_Click);
            // 
            // path_button
            // 
            this.path_button.Location = new System.Drawing.Point(439, 134);
            this.path_button.Name = "path_button";
            this.path_button.Size = new System.Drawing.Size(126, 26);
            this.path_button.TabIndex = 6;
            this.path_button.Text = "Set Save Location";
            this.path_button.UseVisualStyleBackColor = true;
            this.path_button.Click += new System.EventHandler(this.path_button_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Save Folder Location";
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(439, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 20);
            this.textBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 372);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.path_button);
            this.Controls.Add(this.download_button);
            this.Controls.Add(this.videos_panel);
            this.Controls.Add(this.add_url_button);
            this.Controls.Add(this.video_textbox);
            this.Controls.Add(this._url_label);
            this.Name = "Form1";
            this.Text = "Youtube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        private System.Windows.Forms.Button path_button;

        private System.Windows.Forms.Button download_button;

        private System.Windows.Forms.Panel videos_panel;

        

        private System.Windows.Forms.Button add_url_button;

        private System.Windows.Forms.TextBox video_textbox;
        private System.Windows.Forms.Label _url_label;

        #endregion
    }
}