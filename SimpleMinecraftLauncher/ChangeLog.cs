using CmlLib.Utils;
using System;
using System.Windows.Forms;

namespace SimpleMinecraftLauncher
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private Changelogs changelogs;
        
        private async void ChangeLog_Load(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            changelogs = await Changelogs.GetChangelogs();
            listBox1.Items.AddRange(changelogs.GetAvailableVersions());
            btnLoad.Enabled = true;
        }
        
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            var version = listBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(version))
                return;
            
            btnLoad.Enabled = false;

            var body = await changelogs.GetChangelogHtml(version);
            body = "<style>* {font-family: Segoe UI}</style>\n" + body;
            webBrowser1.DocumentText = body;
            Console.WriteLine(body);

            btnLoad.Enabled = true;
        }
    }
}
