using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class ThumbNail : UserControl {
        private bool _Selected;

        public ThumbNail() {
            InitializeComponent();
        }

        public string url { get; set; }

        public bool Selected {
            get => _Selected;
            set {
                _Selected = value;
                BackPanel.BackColor = _Selected ? Color.Chartreuse : Color.Red;
            }
        }

        public Image Image {
            get => ThumbPicture.Image;
            set => ThumbPicture.Image = value;
        }

        // This caused so many designer bugs 
        // ReSharper disable once ConvertToAutoProperty
        public RichTextBox Rich => this.RichText;

        // public Panel Panel => this.BackPanel;

        private void ThumbPicture_Click(object sender, EventArgs e) {
            Debug.WriteLine("Clicked");
            Selected = !Selected;
        }

        private void RichText_Click(object sender, EventArgs e) {
            Debug.WriteLine("Clicked");
            Selected = !Selected;
        }

        private void BackPanel_Click(object sender, EventArgs e) { 
            Debug.WriteLine("Clicked");
            Selected = !Selected;
        }
    }
}