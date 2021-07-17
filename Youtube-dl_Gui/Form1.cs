using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imazen.WebP;


namespace Youtube_dl_Gui {
    public partial class Form1 : Form {
        private readonly Random _random;
        private readonly string _youtubedl_path;
        private HttpClient web_client;
        private string download_path;

        public Form1() {
            InitializeComponent();
            clean_temp_files();
            _random = new Random();
            string[] youtube_paths = {
                ""
            };
            _youtubedl_path = Find_Youtubedl(youtube_paths);
            if (_youtubedl_path is null) youtubedl_error();
            
            
            
            web_client = new HttpClient();
            
            web_client.DefaultRequestHeaders.Add("User-agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");
        }

        private void youtubedl_error() {
            MessageBox.Show("Could not find youtube dl", "Youtube Downloader", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            throw new FileNotFoundException("Youtube-dl not found");
        }
    

        /// <summary>
        ///     Finds the location of youtube-dl
        /// </summary>
        /// <returns> The path of youtube-dl executable </returns>
        private string Find_Youtubedl(string[] paths_to_search) {
            string running_directory = Directory.GetCurrentDirectory();
            return paths_to_search
                .Select(start_path => Recursive_Search(running_directory + start_path, "youtube-dl.exe"))
                .FirstOrDefault(result => result != null);
        }

        private string Recursive_Search(string path, string name) {
            foreach (string entry in Directory.EnumerateFileSystemEntries(path)) {
                string[] split_entry = entry.Split('.');

                Console.WriteLine(entry);

                if (split_entry.Length > 1 && split_entry[^1].Length > 0) {
                    string filename = entry.Split('\\')[^1];
                    if (filename == name) return entry;

                    continue;
                }

                string result = Recursive_Search(entry, name);
                if (result != null) return result;
            }

            return null;
        }
        
        
        
        private void add_url_click(object sender, EventArgs e) {
            add_url_background(); // TODO Rework thumbnail generator to not suspend UI thread
        }

        private async void add_url_background() {
            string url = video_textbox.Text;

            IEnumerable<ThumbNail> thumbnails = Generate_Thumbnails(url);

            int counter = 0;
            foreach (ThumbNail thumbnail in thumbnails) {
                videos_panel.Controls.Add(thumbnail);
                if (counter++ % 20 == 0)
                    await Task.Delay(20); // A small delay un-suspends ui control 
            }
            Debug.WriteLine("Finished Work");
        }
        
        
        private IEnumerable<ThumbNail> Generate_Thumbnails(string playlist_url) {
            string json_path = Get_video_json(playlist_url);
            var json_object = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(json_path));
            var entries = json_object.GetValueOrDefault("entries", null);
            if (entries is null) {
                // Single video
                yield return Generate_From_Data(json_object["webpage_url"].ToString(), json_object["title"].ToString(),
                    json_object["channel"].ToString(), json_object["thumbnail"].ToString());
            }
            else {
                var entry_array = JsonSerializer.Deserialize<Dictionary<string, object>[]>(entries.ToString());
                foreach (var entry in entry_array) {
                    yield return Generate_From_Data(entry["webpage_url"].ToString(), entry["title"].ToString(),
                        entry["channel"].ToString(), entry["thumbnail"].ToString());
                }
            }
        }


        /// <summary>
        ///     Generate a thumbnail from a video url
        /// </summary>
        /// <param name="url"> Video URL </param>
        /// <returns> A thumbnail with formatted title </returns>
        private ThumbNail Generate_From_Data(string url, string title, string channel, string thumbnail) {
            ThumbNail ret = new();

            if (title != null) {
                ret.Rich.Text = title;
            }

            ret.Dock = DockStyle.Top;

            ret.Rich.Text += $"\n{channel}";

            ret.Rich.Select(0, title.Length);
            ret.Rich.SelectionFont = new Font(new FontFamily("Arial"), 14f, FontStyle.Bold);
            ret.Rich.Select(title.Length + 1, ret.Rich.Text.Length);
            
            ret.Rich.SelectionFont = new Font(new FontFamily("Arial"), 12f, FontStyle.Regular);

            ret.Image = Get_Formatted_Image(thumbnail);

            
            ret.Selected = true;
            ret.url = url;
            
            // ret.MouseClick += Select_Click;
            // ret.Rich.Click += Select_Click;
            
            
            return ret;
        }

        private Image Get_Formatted_Image(string url) {
            Image image = null;

            var valid_urls = new Dictionary<string, Func<string, Image>>();
            valid_urls.Add(".jpg", value: (url) => {
                Stream stream = web_client.GetStreamAsync(url).Result;
                
                try {
                    return Image.FromStream(stream);
                }
                catch (Exception e) {
                    return new Bitmap(168, 94);
                }
            });
            valid_urls.Add(".png", (url) => {
                return Image.FromStream(web_client.GetStreamAsync(url).Result);
            });

            valid_urls.Add(".webp", (url) => {
                byte[] arry = web_client.GetByteArrayAsync(url).Result;
                Image temp_image = new SimpleDecoder().DecodeFromBytes(arry, arry.Length);
                return temp_image;
            });

            string extension_result = valid_urls.Keys.FirstOrDefault(extension => url.Contains(extension));
            var possible_func = valid_urls.GetValueOrDefault(extension_result, null);
            if (possible_func is not null) {
                image = possible_func(url);
            }

            

            return image ?? throw new FormatException("Unsupported image format");
        }
        private void download_button_Click(object sender, EventArgs e) {
            Download_Videos();
            // throw new System.NotImplementedException();
        }

        private void Download_Videos() {
            foreach (ThumbNail selected_video in Get_Selected_Videos()) {
                Download_Video_From_Url(selected_video.url);
            }
        }

        private void Download_Video_From_Url(string url) {
            using Process youtubeProcess = new Process {
                StartInfo = {
                    // WorkingDirectory = download_path,
                    FileName = _youtubedl_path,
                    Arguments = $"-o \"{download_path}\"\\%(title)s.%(ext)s {url}",
                    RedirectStandardOutput = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = false
                }
            };
            youtubeProcess.Start();
            youtubeProcess.WaitForExit();
        }
        
        private IEnumerable<ThumbNail> Get_Selected_Videos() {
            Stack<ThumbNail> ThumbNail_Stack = new Stack<ThumbNail>();
            foreach (ThumbNail control in videos_panel.Controls.OfType<ThumbNail>()) {
                if (control.Selected) {
                    ThumbNail_Stack.Push(control);
                }
            }

            return ThumbNail_Stack;
        }
        



        /// <summary>
        ///     Uses youtube-dl to get video data
        /// </summary>
        /// <param name="url"> The url of the video to analyze</param>
        /// <returns> The path to the json </returns>
        private string Get_video_json(string url) {
            string temp_path = Path.GetTempPath();
            string data_path = temp_path + "youtube-dl/video_data/";
            check_dir_make(data_path);
            string json_path = $"{data_path}{_random.Next(10 ^ 5)}.json";

            using Process youtubeProcess = new Process {
                StartInfo = {
                    FileName = _youtubedl_path,
                    Arguments = $"-J {url}",
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };



            youtubeProcess.Start();
            using (StreamWriter fileWriter = new StreamWriter(json_path)) {
                fileWriter.Write(youtubeProcess.StandardOutput.ReadToEnd());
            }

            youtubeProcess.WaitForExit();
            return json_path;
        }

        /// <summary>
        ///     Check if a directory exists. If it doesnt make one
        /// </summary>
        /// <param name="path"> The path to the directory </param>
        private void check_dir_make(string path) {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void clean_temp_files() {
            string temp_path = Path.GetTempPath();
            string data_path = temp_path + "youtube-dl/";
            if (!Directory.Exists(data_path))
                return;
            Directory.Delete(data_path, true);
        }


        private void path_button_Click(object sender, EventArgs e) {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                download_path = folderBrowserDialog1.SelectedPath;
                textBox1.Text = download_path;
            }
        }
    }
}
