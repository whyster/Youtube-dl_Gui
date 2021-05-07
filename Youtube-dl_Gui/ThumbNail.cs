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

        public string RichText {
            get => this.description_rich.Text;
            set => this.description_rich.Text = value;
        }
    }
}