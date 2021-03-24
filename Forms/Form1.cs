using Htmlhelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

// ----------------------------------------------------------------------------------------------------
// |                                This is Lab5 by Andreas Nilsson                                   |
// ----------------------------------------------------------------------------------------------------


namespace Forms
{
    public partial class Form1 : Form
    {


        public List<string> resultList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) //GO-button
        {
            string input = tb_URL.Text;
            if (input == "" || input == " ")
            {
                MessageBox.Show("URL can't be empty.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_URL.Text = "";
                return;
            }

            if (!Uri.IsWellFormedUriString(input, UriKind.Absolute))
            {
                MessageBox.Show("Invalid URL. Check and try again.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_URL.Text = input;                            //Keeps the previous input after warning message is shown.
                return;
            }
            HtmlExtract extract = new HtmlExtract();
            resultList = await extract.CallURL(input);

            if (resultList.Count <= 0)
            {
                MessageBox.Show("No images found.", "Zero images", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i].Contains("http://") || resultList[i].Contains("https://"))
                    {
                        continue;
                    }
                    else
                    {
                        resultList[i] = tb_URL.Text + resultList[i];
                    }
                }

                lb_Result.DataSource = resultList;
                lbl_NumberOfFoundImages.Visible = true;
                lbl_NumberOfFoundImages.Text = $"{resultList.Count} images found";

            }

        }

        private void btn_ClearSelection_Click(object sender, EventArgs e)
        {
            lb_Result.ClearSelected();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            //Varför fungerar inte lb_Result.SelectAll(); ???
            for (int i = 0; i < lb_Result.Items.Count; i++)
            {
                lb_Result.SetSelected(i, true);
            }

        }

        private async void btn_DownloadImages_ClickAsync(object sender, EventArgs e)
        {
            var selectedPics = lb_Result.SelectedItems.Cast<string>().ToList();
            if (lb_Result.SelectedItems.Count > 0)
            {

                var client = new HttpClient();
                Dictionary<Task<byte[]>, string> downloads = new Dictionary<Task<byte[]>, string>(); //Container for imagebytes
                string folder = FolderPath();
                int numOfPics = 0;
                int downloadedPics = 0;

                foreach (var url in selectedPics)
                {
                    string fileExtension = Regex.Match(url, @"(?<=\.)(jpg|jpeg|png|gif|bmp)(?=(""|\?|$))").Value;
                    downloads.Add(Task.Run(() => client.GetByteArrayAsync(url)), fileExtension);
                }
                if (downloads != null)
                {


                    while (downloads.Count > 0)
                    {
                        Task<byte[]> task = await Task.WhenAny(downloads.Keys);

                        numOfPics++;
                        if (task.Exception == null)
                        {

                            string fileExtension = downloads[task];
                            string fileName = $"Image{numOfPics,000}.{fileExtension}";
                            string fullPath = Path.Combine(folder, fileName);
                            await SaveImage(fullPath, task.Result);
                            downloadedPics++;
                            lbl_NumberOfFoundImages.Text = "Downloaded images: " + Convert.ToString(downloadedPics) + "/" + Convert.ToString(selectedPics.Count);
                        }
                        downloads.Remove(task);
                    }
                }
                else
                {
                    return;
                }
            }

        }

        private async Task SaveImage(string path, byte[] data)
        {
            var fs = new FileStream(path, FileMode.Create);
            await fs.WriteAsync(data, 0, data.Length);
            fs.Close();
        }
        public string FolderPath()
        {
            string folder = "";
            using (var folderBrowser = new FolderBrowserDialog())
            {
                DialogResult dialog = folderBrowser.ShowDialog();
                if (dialog == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    folder = folderBrowser.SelectedPath;
                    return folder;
                }
                else
                {
                    return null;
                }
            }
        }

        void wc_DownloadFilesCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Selected file(s) downloaded");
        }

        private void lb_Result_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
