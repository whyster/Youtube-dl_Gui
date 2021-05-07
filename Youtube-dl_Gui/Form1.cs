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
        public Form1() {
            InitializeComponent();
            
        }

        // private void highlight_click(object sender, EventArgs e) {
        //     ThumbNail thumb_control = sender as ThumbNail;
        //     thumb_control.panel.
        // }

        private void add_url_Click(object sender, EventArgs e) {
            
            string url = video_textbox.Text;
            ThumbNail test = new ThumbNail();
            
            test.Dock = DockStyle.Top;
            
            test.Rich.Text = url;
            test.Rich.Select(0, url.Length);
            test.Rich.SelectionFont = new Font(test.Rich.Font, FontStyle.Bold);
            test.panel.BackColor = Color.Chartreuse; 


            videos_panel.Controls.Add(test);
            
            
            // Debug.WriteLine(videos_panel.Controls.Count);
        }
    }
}

/*
 * 
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 hello\par
}
 */