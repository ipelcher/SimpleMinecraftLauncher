using CmlLib.Core;
using CmlLib.Core.Downloader;
using CmlLib.Core.Installer;
using CmlLib.Core.Installer.FabricMC;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMinecraftLauncher
{
    public partial class FabricInstall : Form
    {
        public FabricInstall(MinecraftPath path, string java)
        {
            this.javapath = java;
            this.Path = path;
            logQueue = new ConcurrentQueue<string>();
            InitializeComponent();
        }

        public string LastInstalledVersion { get; private set; }
        MinecraftPath Path;
        string javapath;

        ConcurrentQueue<string> logQueue;

        private void btnInstall_Click(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            txtMC.Enabled = false;
            txtFabric.Enabled = false;

            new Thread(async () =>
            {
                try
                {
                    var launcher = new CMLauncher(Path);
                    launcher.FileChanged += Fabric_FileChanged;

                    // initialize fabric version loader
                    var fabricVersionLoader = new FabricVersionLoader();
                    var fabricVersions = await fabricVersionLoader.GetVersionMetadatasAsync();


                    foreach (var v in fabricVersions)
                    {
                        Console.WriteLine(v.Name);
                    }

                    var fabricVersionName = "fabric-loader-" + txtFabric.Text + "-" + txtMC.Text;
                    Console.WriteLine(fabricVersionName);

                    var fabric = fabricVersions.GetVersionMetadata(fabricVersionName);
                    await fabric.SaveAsync(Path);

                    LastInstalledVersion = fabricVersionName;

                    MessageBox.Show($"{fabricVersionName} was successfully installed");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        btnInstall.Enabled = true;
                        txtMC.Enabled = true;
                        txtFabric.Enabled = true;
                    }));
                }
            }).Start();
        }

        private void Fabric_InstallerOutput(object sender, string e)
        {
            if (e != null)
                logQueue.Enqueue(e);
        }

        private void Fabric_FileChanged(DownloadFileChangedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                lbStatus.Text = $"{e.FileKind} - {e.FileName}";
                pbProgress.Maximum = e.TotalFileCount;
                pbProgress.Value = e.ProgressedFileCount;
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string item;
            while (logQueue.TryDequeue(out item))
            {
                txtLog.AppendText(item);
                txtLog.AppendText("\n");
            }
        }
    }
}
