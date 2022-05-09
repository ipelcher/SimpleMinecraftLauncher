﻿using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.Installer;
using CmlLib.Core.Files;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core.Downloader;
using Downloader;
using System.Net;

namespace SimpleMinecraftLauncher
{
    public partial class MainForm : Form
    {
        public MainForm(MSession session)
        {
            this.session = session;
            InitializeComponent();
        }

        CMLauncher launcher;
        readonly MSession session;
        MinecraftPath gamePath; 
        string javaPath;
        
        GameLog logForm;

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            // Initialize launcher
            var defaultPath = new MinecraftPath(MinecraftPath.GetOSDefaultPath());
            await initializeLauncher(defaultPath);
            lbUsername.Text = session.Username;
        }

        private async Task initializeLauncher(MinecraftPath path)
        {
            txtPath.Text = path.BasePath;
            this.gamePath = path;
            
            launcher = new CMLauncher(path);
            launcher.FileChanged += Launcher_FileChanged;
            launcher.ProgressChanged += Launcher_ProgressChanged;
            await refreshVersions(null);
        }

        private async void btnRefreshVersion_Click(object sender, EventArgs e)
        {
            await refreshVersions(null);
        }

        private async Task refreshVersions(string showVersion)
        {
            cbVersion.Items.Clear();

            var versions = await launcher.GetAllVersionsAsync();

            bool showVersionExist = false;
            foreach (var item in versions)
            {
                if (showVersion != null && item.Name == showVersion)
                    showVersionExist = true;
                cbVersion.Items.Add(item.Name);
            }

            if (showVersion == null || !showVersionExist)
                btnSetLastVersion_Click(null, null);
            else
                cbVersion.Text = showVersion;
        }

        private void btnSetLastVersion_Click(object sender, EventArgs e)
        {
            cbVersion.Text = launcher.Versions?.LatestReleaseVersion?.Name;
        }

        // Start Game
        private async void Btn_Launch_Click(object sender, EventArgs e)
        {
            if (session == null)
            {
                MessageBox.Show("Login First");
                return;
            }

            if (cbVersion.Text == "")
            {
                MessageBox.Show("Select Version");
                return;
            }

            // disable ui
            setUIEnabled(false);

            try
            {
                // create LaunchOption
                var launchOption = new MLaunchOption()
                {
                    MaximumRamMb = int.Parse(TxtXmx.Text),
                    Session = this.session,

                    VersionType = Txt_VersionType.Text,
                    GameLauncherName = Txt_GLauncherName.Text,
                    GameLauncherVersion = Txt_GLauncherVersion.Text,

                    FullScreen = cbFullscreen.Checked,

                    ServerIp = Txt_ServerIp.Text,

                    DockName = Txt_DockName.Text,
                    DockIcon = Txt_DockIcon.Text
                };

                if (!string.IsNullOrEmpty(javaPath))
                    launchOption.JavaPath = javaPath;
                
                if (!string.IsNullOrEmpty(txtXms.Text))
                    launchOption.MinimumRamMb = int.Parse(txtXms.Text);

                if (!string.IsNullOrEmpty(Txt_ServerPort.Text))
                    launchOption.ServerPort = int.Parse(Txt_ServerPort.Text);

                if (!string.IsNullOrEmpty(Txt_ScWd.Text) && !string.IsNullOrEmpty(Txt_ScHt.Text))
                {
                    launchOption.ScreenHeight = int.Parse(Txt_ScHt.Text);
                    launchOption.ScreenWidth = int.Parse(Txt_ScWd.Text);
                }

                if (!string.IsNullOrEmpty(Txt_JavaArgs.Text))
                    launchOption.JVMArguments = Txt_JavaArgs.Text.Split(' ');

                if (rbParallelDownload.Checked)
                {
                    System.Net.ServicePointManager.DefaultConnectionLimit = 256;
                    launcher.FileDownloader = new AsyncParallelDownloader();
                }
                else
                    launcher.FileDownloader = new SequenceDownloader();

                if (cbSkipAssetsDownload.Checked)
                    launcher.GameFileCheckers.AssetFileChecker = null;
                else if (launcher.GameFileCheckers.AssetFileChecker == null)
                    launcher.GameFileCheckers.AssetFileChecker = new AssetChecker();
                
                // check file hash or don't check
                if (launcher.GameFileCheckers.AssetFileChecker != null)
                    launcher.GameFileCheckers.AssetFileChecker.CheckHash = !cbSkipHashCheck.Checked;
                if (launcher.GameFileCheckers.ClientFileChecker != null)
                    launcher.GameFileCheckers.ClientFileChecker.CheckHash = !cbSkipHashCheck.Checked;
                if (launcher.GameFileCheckers.LibraryFileChecker != null)
                    launcher.GameFileCheckers.LibraryFileChecker.CheckHash = !cbSkipHashCheck.Checked;

                var process = await launcher.CreateProcessAsync(cbVersion.Text, launchOption); // Create Arguments and Process

                // process.Start(); // Just start game, or
                StartProcess(process); // Start Process with debug options
            }
            catch (FormatException fex) // int.Parse exception
            {
                MessageBox.Show("Failed to create MLaunchOption\n\n" + fex);
            }
            catch (MDownloadFileException mex) // download exception
            {
                MessageBox.Show(
                    $"FileName : {mex.ExceptionFile.Name}\n" +
                    $"FilePath : {mex.ExceptionFile.Path}\n" +
                    $"FileUrl : {mex.ExceptionFile.Url}\n" +
                    $"FileType : {mex.ExceptionFile.Type}\n\n" +
                    mex.ToString());
            }
            catch (Win32Exception wex) // java exception
            {
                MessageBox.Show(wex + "\n\nIt seems your java setting has problem");
            }
            catch (Exception ex) // all exception
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // re open log form
                if (logForm != null)
                    logForm.Close();

                logForm = new GameLog();
                logForm.Show();

                // enable ui
                setUIEnabled(true);
            }
        }
        
        private int uiThreadId = Thread.CurrentThread.ManagedThreadId;

        // Event Handler. Show download progress
        private void Launcher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Thread.CurrentThread.ManagedThreadId != uiThreadId)
            {
                Debug.WriteLine(e);
            }

            //TODO: FIX THIS
            //Pb_Progress.Maximum = 100;
            //Pb_Progress.Value = e.ProgressPercentage;
        }

        private void Launcher_FileChanged(DownloadFileChangedEventArgs e)
        {
            if (Thread.CurrentThread.ManagedThreadId != uiThreadId)
            {
                Debug.WriteLine(e);
            }
            Pb_File.Maximum = e.TotalFileCount;
            Pb_File.Value = e.ProgressedFileCount;
            Lv_Status.Text = $"{e.FileKind} : {e.FileName} ({e.ProgressedFileCount}/{e.TotalFileCount})";
            //Debug.WriteLine(Lv_Status.Text);
        }

        private async void btnChangePath_Click(object sender, EventArgs e)
        {
            var form = new PathForm(this.gamePath);
            form.ShowDialog();
            await initializeLauncher(form.MinecraftPath);
        }

        private void btnChangeJava_Click(object sender, EventArgs e)
        {
            var form = new JavaForm(javaPath);
            form.ShowDialog();
            javaPath = form.JavaBinaryPath;
            
            if (string.IsNullOrEmpty(javaPath))
                lbJavaPath.Text = "Use default java";
            else
                lbJavaPath.Text = javaPath;
        }

        private void btnAutoRamSet_Click(object sender, EventArgs e)
        {
            var computerMemory = Util.GetMemoryMb();
            if (computerMemory == null)
            {
                MessageBox.Show("Failed to get computer memory");
                return;
            }

            var max = computerMemory / 2;
            if (max < 1024)
                max = 1024;
            else if (max > 8192)
                max = 8192;

            var min = max / 10;

            TxtXmx.Text = max.ToString();
            txtXms.Text = min.ToString();
        }

        private void setUIEnabled(bool value)
        {
            groupBox1.Enabled = value;
            groupBox2.Enabled = value;
            groupBox3.Enabled = value;
            groupBox4.Enabled = value;
        }

        // not stable
        private void btnForgeInstall_Click(object sender, EventArgs e)
        {
            setUIEnabled(false);
            new Thread(() =>
            {
                var forgeJava = "";
                var java = new MJava();
                java.ProgressChanged += Launcher_ProgressChanged;
                forgeJava = java.CheckJava();

                Invoke(new Action(async () =>
                {
                    var forgeForm = new ForgeInstall(gamePath, forgeJava);
                    forgeForm.ShowDialog();
                    setUIEnabled(true);
                    await refreshVersions(forgeForm.LastInstalledVersion);
                }));
            }).Start();
        }

        private void btnFabricInstall_Click(object sender, EventArgs e)
        {
            setUIEnabled(false);
            new Thread(() =>
            {
                var fabricJava = "";
                var java = new MJava();
                java.ProgressChanged += Launcher_ProgressChanged;
                fabricJava = java.CheckJava();

                Invoke(new Action(async () =>
                {
                    var fabricForm = new FabricInstall(gamePath, fabricJava);
                    fabricForm.ShowDialog();
                    setUIEnabled(true);
                    await refreshVersions(fabricForm.LastInstalledVersion);
                }));
            }).Start();
        }

        private void StartProcess(Process process)
        {
            File.WriteAllText("launcher.txt", process.StartInfo.Arguments);
            output(process.StartInfo.Arguments);

            // process options to display game log

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = true;
            process.ErrorDataReceived += Process_ErrorDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            output(e.Data);
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            output(e.Data);
        }

        void output(string msg)
        {
            GameLog.AddLog(msg);
        }

        private void btnChangelog_Click(object sender, EventArgs e)
        {
            // Game Changelog
            var f = new ChangeLog();
            f.Show();
        }

        private void btnMojangServer_Click(object sender, EventArgs e)
        {
            // Mojang Server
            var f = new MojangServerForm();
            f.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            // options.txt
            var path = System.IO.Path.Combine(gamePath.BasePath, "options.txt");
            var f = new GameOptions(path);
            f.Show();
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            start("https://github.com/AlphaBs/CmlLib.Core");
        }

        private void btnWiki_Click(object sender, EventArgs e)
        {
            start("https://github.com/AlphaBs/CmlLib.Core/wiki/");
        }

        private void start(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string getLibraryVersion()
        {
            try
            {
                return Assembly.GetAssembly(typeof(CMLauncher)).GetName().Version.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private async void testBtn_Click(object sender, EventArgs e)
        {
            var downloadOpt = new DownloadConfiguration()
            {
                BufferBlockSize = 10240, // usually, hosts support max to 8000 bytes, default values is 8000
                ChunkCount = 8, // file parts to download, default value is 1
                MaximumBytesPerSecond = int.MaxValue, // download speed limited to 1MB/s, default values is zero or unlimited
                MaxTryAgainOnFailover = int.MaxValue, // the maximum number of times to fail
                OnTheFlyDownload = false, // caching in-memory or not? default values is true
                ParallelDownload = true, // download parts of file as parallel or not. Default value is false
                TempDirectory = Path.GetTempPath(), // Set the temp path for buffering chunk files, the default path is Path.GetTempPath()
                Timeout = 1000, // timeout (millisecond) per stream block reader, default values is 1000
                RequestConfiguration = // config and customize request headers
                {
                    Accept = "*/*",
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                    CookieContainer =  new CookieContainer(), // Add your cookies
                    Headers = new WebHeaderCollection(), // Add your custom headers
                    KeepAlive = false,
                    ProtocolVersion = HttpVersion.Version11, // Default value is HTTP 1.1
                    UseDefaultCredentials = false,
                    UserAgent = $"DownloaderSample/{Assembly.GetExecutingAssembly().GetName().Version.ToString(3)}"
                }
            };

            var downloader = new DownloadService(downloadOpt);

            // Provide `FileName` and `TotalBytesToReceive` at the start of each downloads
            downloader.DownloadStarted += OnDownloadStarted;

            // Provide any information about chunker downloads, like progress percentage per chunk, speed, total received bytes and received bytes array to live streaming.
            downloader.ChunkDownloadProgressChanged += OnChunkDownloadProgressChanged;

            // Provide any information about download progress, like progress percentage of sum of chunks, total speed, average speed, total received bytes and received bytes array to live streaming.
            downloader.DownloadProgressChanged += OnDownloadProgressChanged;

            // Download completed event that can include occurred errors or cancelled or download completed successfully.
            downloader.DownloadFileCompleted += OnDownloadFileCompleted;

            string file = @"D:\\lytiyflexhype\\1GB.bin";
            string url = @"https://speed.hetzner.de/1GB.bin";
            await downloader.DownloadFileTaskAsync(url, file);
        }

        private void OnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Downloaded: " + sender.ToString());
        }

        private void OnDownloadProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Changed: " + sender.ToString());
        }

        private void OnChunkDownloadProgressChanged(object sender, Downloader.DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("ChunkChanged: " + sender.ToString());
        }

        private void OnDownloadStarted(object sender, DownloadStartedEventArgs e)
        {
            Console.WriteLine("Started: " + sender.ToString());
        }
    }
}
