using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class Form1 : Form {
        private string youtubedl_path;
        private readonly string[] YOUTUBE_PATHS; 
        public Form1() {
            InitializeComponent();
            YOUTUBE_PATHS = new string[] {
                "./"
            };
            youtubedl_path = find_youtubedl(YOUTUBE_PATHS);
        }

        // private void highlight_click(object sender, EventArgs e) {
        //     ThumbNail thumb_control = sender as ThumbNail;
        //     thumb_control.panel.
        // }


        /// <summary>
        /// Finds the location of youtube-dl 
        /// </summary>
        /// <returns> The path of youtube-dl executable </returns>
        private string find_youtubedl(string[] paths_to_search) {
            foreach (string start_path in paths_to_search) {
                string result = Recursive_Search(start_path, "youtube-dl.exe");
                if (result != null) {
                    return result;
                }
            }

            throw new FileNotFoundException("Youtube-dl not found");
            
        }

        private string Recursive_Search(string path, string name) {
            foreach (string entry in Directory.EnumerateFileSystemEntries(path)) {
                string[] split_entry = entry.Split('.');
                
                Console.WriteLine(entry);
                
                if (split_entry.Length > 1 && split_entry[^1].Length > 0) {
                    string filename = entry.Split('\\')[^1];
                    if (filename == name) {
                        return entry;
                    }

                    continue;
                }

                string result = Recursive_Search(entry, name);
                if (result != null) {
                    return result;
                }
            }

            return null;
        }


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


        /// <summary>
        /// Uses youtube-dl to get video data
        /// </summary>
        /// <param name="url"> The url of the video to analyze</param>
        /// <returns> The path to the json </returns>
        // private string get_video_data(string url)
        // {
        //     
        // }
    }
}

/*
 * 
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 hello\par
}
 */