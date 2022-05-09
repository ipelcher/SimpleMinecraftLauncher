﻿using CmlLib.Core.Mojang;
using System;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMinecraftLauncher
{
    public partial class MojangServerForm : Form
    {
        public MojangServerForm()
        {
            InitializeComponent();
        }

        private void MojangServerForm_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    var status = MojangServerStatus.GetStatus();
                    var properties = status.GetType().GetProperties();

                    Invoke(new Action(() =>
                    {
                        foreach (var item in properties)
                        {
                            listView1.Items.Add(new ListViewItem(new[]
                            {
                            item.Name,
                            item.GetValue(status).ToString()
                        }));
                        }
                    }));
                }
                catch (System.Net.WebException ex)
                {
                    MessageBox.Show("Unable to access Mojang servers! \n\n" + ex);
                    Invoke(new Action(() =>
                    {
                        this.Close();
                    }));
                    this.Close();
                }
            }).Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
