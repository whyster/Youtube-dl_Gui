using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class Form1 : Form {
        private int counter = 0;
        public Form1() {
            InitializeComponent();
        }

        private void add_url_Click(object sender, EventArgs e) {
            // throw new System.NotImplementedException();
            
            string url = video_textbox.Text;
            ThumbNail test = new ThumbNail();
            
            // TextBox test = new TextBox();
            //
            // test.Name = $"test{counter++}";
            // test.Text = $"test{counter}";
            //
            test.Dock = DockStyle.Top;
            test.RichText = $"test{counter++}";
            
            videos_panel.Controls.Add(test);
            
            // Debug.WriteLine(videos_panel.Controls.Count);
        }
    }
}