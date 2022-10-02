using System.Diagnostics;
using VideoLibrary;
namespace Youtube_MP3_and_MP4_Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (tbUrl.Text == "" || tbFolderPath == null)
            {
                MessageBox.Show("Set the url from youtube video or folder path !");
            }
            else
            {
                if (checkedListBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please check the file type u want to download !");
                }
                else if (checkedListBox1.SelectedItem.ToString() == "MP3")
                {

                    progressBar1.Value = 0;

                    string outputFolder = tbFolderPath.Text;
                    string url = $@"{tbUrl.Text}";


                    var youTube = YouTube.Default; // starting point for YouTube actions

                    lblStatus.Text = "Downloading...";
                    Cursor.Current = Cursors.WaitCursor;
                    var video = youTube.GetVideo(url); // gets a Video object with info about the video
                    File.WriteAllBytes(outputFolder + @"\" + video.FullName, video.GetBytes());
                    progressBar1.Value = 100;
                    lblPercent.Text = "100%";
                    lblStatus.Text = "Finished!";

                    string downloadedMp4Path = @$"{outputFolder}\{video.FullName}";
                    FileInfo mp4 = new FileInfo(downloadedMp4Path);

                    if (File.Exists(downloadedMp4Path) && mp4.Length > 0)
                    {
                        Cursor.Current = Cursors.Default;
                        var currentPathConverter = Path.GetDirectoryName(Application.ExecutablePath);
                        var inputFile = $@"{outputFolder}\{video.FullName}";

                        String nameFile = video.FullName;
                        var changeExtensionFile = nameFile.Replace(".mp4", "");
                        var outputFile = $@"{outputFolder}\{changeExtensionFile}.mp3";
                        var mp3out = "";

                        lblStatus.Text = "Converting to .mp3...";
                        lblPercent.Text = "0%";
                        progressBar1.Value = 0;
                        Cursor.Current = Cursors.WaitCursor;
                        var ffmpegProcess = new Process();
                        ffmpegProcess.StartInfo.UseShellExecute = false;
                        ffmpegProcess.StartInfo.RedirectStandardInput = true;
                        ffmpegProcess.StartInfo.RedirectStandardOutput = true;
                        ffmpegProcess.StartInfo.RedirectStandardError = true;
                        ffmpegProcess.StartInfo.CreateNoWindow = true;
                        ffmpegProcess.StartInfo.FileName = currentPathConverter + @"\FFmpeg.exe";
                        ffmpegProcess.StartInfo.Arguments = " -i " + "\"" + inputFile + "\"" + " -vn -f mp3 -ab 320k " + "\"" + outputFile + "\"";
                        ffmpegProcess.Start();
                        ffmpegProcess.StandardOutput.ReadToEnd();
                        mp3out = ffmpegProcess.StandardError.ReadToEnd();
                        ffmpegProcess.WaitForExit();
                        if (!ffmpegProcess.HasExited)
                        {
                            ffmpegProcess.Kill();
                        }

                        if (File.Exists(outputFile))
                        {
                            FileInfo mp3 = new FileInfo(outputFile);
                            if (mp3.Length > 0)
                            {
                                progressBar1.Value = 100;
                                lblPercent.Text = "100%";
                                lblStatus.Text = "Done !";
                                MessageBox.Show("Converting to .mp3 is done !");
                                Cursor.Current = Cursors.Default;
                                File.Delete(downloadedMp4Path);
                                Process.Start("explorer.exe", @$"/select, {outputFile}");
                            }
                            else
                            {
                                MessageBox.Show("Error with converting to .mp3. Try again !");
                            }
                        }
                    }
                }
                else if (checkedListBox1.SelectedItem.ToString() == "MP4")
                {
                    progressBar1.Value = 0;

                    string outputFolder = tbFolderPath.Text;
                    string url = $@"{tbUrl.Text}";


                    var youTube = YouTube.Default; // starting point for YouTube actions

                    lblStatus.Text = "Downloading...";
                    lblPercent.Text = "0%";
                    Cursor.Current = Cursors.WaitCursor;
                    var video = youTube.GetVideo(url); // gets a Video object with info about the video
                    File.WriteAllBytes(outputFolder + @"\" + video.FullName, video.GetBytes());
                    progressBar1.Value = 100;
                    lblPercent.Text = "100%";
                    lblStatus.Text = "Finished!";

                    string downloadedMp4Path = @$"{outputFolder}\{video.FullName}";
                    FileInfo mp4 = new FileInfo(downloadedMp4Path);

                    if (File.Exists(downloadedMp4Path) && mp4.Length > 0)
                    {
                        progressBar1.Value = 100;
                        lblStatus.Text = "Done !";
                        MessageBox.Show("Downloading .mp4 is done !");
                        Cursor.Current = Cursors.Default;
                        Process.Start("explorer.exe", @$"/select, {downloadedMp4Path}");
                    }
                    else
                    {
                        MessageBox.Show("Error with downloading .mp4. Try again !");
                    }
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex;

            int count = checkedListBox1.Items.Count;
            for (int x = 0; x < count; x++)
            {
                if (index != x)
                {
                    checkedListBox1.SetItemChecked(x, false);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDownload_MouseEnter(object sender, EventArgs e)
        {
            btnDownload.ForeColor = Color.White;
            btnDownload.BackColor = Color.FromArgb(192, 0, 0);
            btnDownload.Cursor = Cursors.Hand;
        }

        private void btnDownload_MouseLeave(object sender, EventArgs e)
        {
            btnDownload.ForeColor = Color.FromArgb(192, 0, 0);
            btnDownload.BackColor = Color.White;
            btnDownload.Cursor = Cursors.Default;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.White;
            btnExit.BackColor = Color.FromArgb(192, 0, 0);
            btnExit.Cursor = Cursors.Hand;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.FromArgb(192, 0, 0);
            btnExit.BackColor = Color.White;
            btnExit.Cursor = Cursors.Default;
        }
    }
}