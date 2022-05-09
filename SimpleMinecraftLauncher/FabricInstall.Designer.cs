namespace SimpleMinecraftLauncher
{
    partial class FabricInstall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnInstall = new System.Windows.Forms.Button();
            this.txtFabric = new System.Windows.Forms.TextBox();
            this.txtMC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "ex: 1.18.2 / 0.13.3";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(20, 153);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLog.Size = new System.Drawing.Size(312, 320);
            this.txtLog.TabIndex = 16;
            this.txtLog.Text = "";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(18, 132);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(35, 13);
            this.lbStatus.TabIndex = 15;
            this.lbStatus.Text = "label3";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(20, 104);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(311, 25);
            this.pbProgress.TabIndex = 14;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(267, 15);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(64, 52);
            this.btnInstall.TabIndex = 13;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // txtFabric
            // 
            this.txtFabric.Location = new System.Drawing.Point(123, 45);
            this.txtFabric.Name = "txtFabric";
            this.txtFabric.Size = new System.Drawing.Size(139, 20);
            this.txtFabric.TabIndex = 12;
            // 
            // txtMC
            // 
            this.txtMC.Location = new System.Drawing.Point(123, 15);
            this.txtMC.Name = "txtMC";
            this.txtMC.Size = new System.Drawing.Size(139, 20);
            this.txtMC.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fabric Version : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Minecraft Version : ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // FabricInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 488);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.txtFabric);
            this.Controls.Add(this.txtMC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FabricInstall";
            this.Text = "FabricInstall";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TextBox txtFabric;
        private System.Windows.Forms.TextBox txtMC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}