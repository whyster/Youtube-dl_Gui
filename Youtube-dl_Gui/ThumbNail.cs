using System.Drawing;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class ThumbNail : UserControl {
        public ThumbNail() {
            InitializeComponent();
        }

        public Image Image {
            get => this.thumbnail_box.Image;
            set => this.thumbnail_box.Image = value;
        }

        public RichTextBox Rich {
            get => this.description_rich;
        }

        public Panel panel { // TODO: Show selection with panel
            get => this.panel1;
        }
    }
}