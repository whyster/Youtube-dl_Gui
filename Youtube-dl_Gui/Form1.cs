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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_dl_Gui {
    public partial class Form1 : Form {
        private string youtubedl_path;
        private readonly string[] YOUTUBE_PATHS;
        private Random _random;
        public Form1() {
            InitializeComponent();
            _random = new Random();
            YOUTUBE_PATHS = new string[] {
                ""
            };
            youtubedl_path = find_youtubedl(YOUTUBE_PATHS);
            if (youtubedl_path is null) youtubedl_error();
            
        }

        private void youtubedl_error() {
            MessageBox.Show("Could not find youtube dl", "Youtube Downloader", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw new FileNotFoundException("Youtube-dl not found");
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
            string running_directory = Directory.GetCurrentDirectory();
            foreach (string start_path in paths_to_search) {
                
                string result = Recursive_Search(running_directory + start_path, "youtube-dl.exe");
                if (result != null) {
                    return result;
                }
            }
            return null;
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


            string json_path = get_video_data(url);
            Dictionary<string, object> video_data = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(json_path));

            string title = video_data["title"].ToString();
            test.Rich.Text = title;
            test.Rich.Select(0, title.Length);
            test.Rich.SelectionFont = new Font(test.Rich.Font, FontStyle.Bold);
            test.Selected = true;

            videos_panel.Controls.Add(test);
    

            // Debug.WriteLine(videos_panel.Controls.Count);
        }


        /// <summary>
        /// Uses youtube-dl to get video data
        /// </summary>
        /// <param name="url"> The url of the video to analyze</param>
        /// <returns> The path to the json </returns>
        private string get_video_data(string url) {
            string temp_path = Path.GetTempPath();
            string data_path = temp_path + "youtube-dl/video_data/";
            check_dir_make(data_path);
            string json_path = $"{data_path}{_random.Next(10 ^ 5)}.json";

            using (Process youtube_process = new Process()) {
                youtube_process.StartInfo.FileName = youtubedl_path;
                youtube_process.StartInfo.Arguments = $"-j {url}";
                youtube_process.StartInfo.RedirectStandardOutput = true;
                youtube_process.Start();
                using (StreamWriter file_writer = new StreamWriter(json_path)) {
                    file_writer.Write(youtube_process.StandardOutput.ReadToEnd());
                }
                youtube_process.WaitForExit();
                return json_path;
            }
            
            
        }

        /// <summary>
        /// Check if a directory exists. If it doesnt make one
        /// </summary>
        /// <param name="path"> The path to the directory </param>
        private void check_dir_make(string path) {
            if (!Directory.Exists(path)) 
                Directory.CreateDirectory(path);
        }

        private void clean_temp_files() {
            string temp_path = Path.GetTempPath();
            string data_path = temp_path + "youtube-dl/";
            Directory.Delete(data_path, true);
        }
    }
}

/*
 * 
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\pard\f0\fs18 hello\par
}
 */