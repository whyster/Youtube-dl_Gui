using System.Drawing;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class ThumbNail : UserControl {
        public string url { get; set; }
        private bool _Selected;

        public bool Selected {
            get => _Selected;
            set {
                _Selected = value;
                BackPanel.BackColor = _Selected ? Color.Chartreuse : Color.Red;
            }
        }

        public ThumbNail() {
            InitializeComponent();
        }

        public Image Image {
            get => this.ThumbPicture.Image;
            set => this.ThumbPicture.Image = value;
        }
        //
        public RichTextBox Rich => this.RichText;

        // public Panel Panel => this.BackPanel;
    }
}