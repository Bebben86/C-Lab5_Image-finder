using Htmlhelper;
using System;
using System.Collections.Generic;
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

        private async void button1_Click(object sender, EventArgs e) //Extract-button, where the journey begins...
        {
            string input = "https://" + tb_URL.Text;
            if (input == "" || input == " ")
            {
                MessageBox.Show("URL can't be empty.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_URL.Text = "";                               //Clears the URL-field for user after message is shown.
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
                //Adds the URL provided by the user if the item doesn't start with http*.
                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i].Contains("http"))
                    {
                        continue;
                    }
                    else
                    {
                        resultList[i] = input + resultList[i];
                    }
                }

                lb_Result.DataSource = resultList; //Sets the list resultList as source for the listbox.
                lbl_imageLable.Visible = true;
                lbl_imageLable.Text = $"{resultList.Count} images found";

            }

        }

        private void btn_ClearSelection_Click(object sender, EventArgs e)
        {
            lb_Result.ClearSelected(); //De-select selected items.
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            //Selects all items in the list box.
            //lb_Result.SelectAll(); doesn't work. Why?
            for (int i = 0; i < lb_Result.Items.Count; i++)
            {
                lb_Result.SetSelected(i, true);
            }

        }

        private async void btn_DownloadImages_ClickAsync(object sender, EventArgs e) //Download button, where the journey ends.
        {
            btn_extract.Enabled = false; //Disables the GO-button so the user can't change URL in the middle of saving pictures.
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

                while (downloads.Count > 0)
                {
                    Task<byte[]> task = await Task.WhenAny(downloads.Keys);

                    numOfPics++;
                    if (task.Exception == null)
                    {

                        string fileExtension = downloads[task];
                        string fileName = $"Image{numOfPics,000}.{fileExtension}"; //Decides the name and filetype the saved file will have.
                        string fullPath = Path.Combine(folder, fileName);
                        await SavePic(fullPath, task.Result);
                        downloadedPics++;
                        lbl_imageLable.Text = "Saved images: " + Convert.ToString(downloadedPics) +
                           " of " + Convert.ToString(selectedPics.Count) + " selected";
                    }
                    downloads.Remove(task);

                }
                if (downloadedPics.ToString() != selectedPics.ToString())
                {
                    MessageBox.Show("Couldn't download all the selected images.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("All images downloaded!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            //Re-enables the GO-button after task is completed.
            btn_extract.Enabled = true;

        }

        private async Task SavePic(string path, byte[] data)
        {
            using (var fs = new FileStream(path, FileMode.Create)) //Writes the bytes to files
            {
                await fs.WriteAsync(data, 0, data.Length);
            }
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
                    MessageBox.Show("Path can't be empty. Program will now exit."); //Avoiding crash by closing the application.
                    Close();
                    return null;
                }
            }
        }
    }
}
