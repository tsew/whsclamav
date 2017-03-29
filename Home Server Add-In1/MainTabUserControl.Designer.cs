namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    partial class MainTabUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabUserControl));
            this.consoleToolBar1 = new Microsoft.HomeServer.Controls.ConsoleToolBar();
            this.ClearToolBarButton = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.RefreshToolBarButton = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.QuarantineToolBarButton = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.ScanDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ScanMemoryToolBarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanToolBarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ScanSharesToolBarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.userDefinedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolBarButton = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.StopToolBarButton = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClamScanStatusLabel = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.ClamUpdateStatusLabel = new Microsoft.HomeServer.Controls.ConsoleToolBarButton();
            this.ScanLogUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateLogUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckClamAVComponentStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.ClamWinVerTabPage = new System.Windows.Forms.TabPage();
            this.VersionPropertyPageNonEditableTextBoxField = new Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField();
            this.ConfigFileTabPage = new System.Windows.Forms.TabPage();
            this.ConfigFilePropertyPageNonEditableTextBoxField = new Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField();
            this.LogUpdateTabPage = new System.Windows.Forms.TabPage();
            this.LogUpdatePropertyPageNonEditableTextBoxField = new Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField();
            this.LogScanTabPage = new System.Windows.Forms.TabPage();
            this.LogScanPropertyPageNonEditableTextBoxField = new Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField();
            this.LogTabControl = new Microsoft.HomeServer.Controls.CustomTabControl();
            this.ScanBackupToolBarButton = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolBar1.SuspendLayout();
            this.ClamWinVerTabPage.SuspendLayout();
            this.ConfigFileTabPage.SuspendLayout();
            this.LogUpdateTabPage.SuspendLayout();
            this.LogScanTabPage.SuspendLayout();
            this.LogTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleToolBar1
            // 
            this.consoleToolBar1.AutoSize = false;
            this.consoleToolBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("consoleToolBar1.BackgroundImage")));
            this.consoleToolBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.consoleToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.consoleToolBar1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolBarButton,
            this.RefreshToolBarButton,
            this.QuarantineToolBarButton,
            this.ScanDropDownButton,
            this.UpdateToolBarButton,
            this.StopToolBarButton,
            this.toolStripSeparator1,
            this.ClamScanStatusLabel,
            this.ClamUpdateStatusLabel});
            this.consoleToolBar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.consoleToolBar1.Location = new System.Drawing.Point(0, 0);
            this.consoleToolBar1.Name = "consoleToolBar1";
            this.consoleToolBar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.consoleToolBar1.Size = new System.Drawing.Size(982, 31);
            this.consoleToolBar1.TabIndex = 5;
            this.consoleToolBar1.Text = "consoleToolBar1";
            // 
            // ClearToolBarButton
            // 
            this.ClearToolBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClearToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.DefaultToolBarIcon;
            this.ClearToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearToolBarButton.Name = "ClearToolBarButton";
            this.ClearToolBarButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ClearToolBarButton.Size = new System.Drawing.Size(72, 28);
            this.ClearToolBarButton.Text = "&Clear";
            this.ClearToolBarButton.ToolTipText = "Clear Selected Log File";
            this.ClearToolBarButton.Click += new System.EventHandler(this.ClearToolBarButton_Click);
            // 
            // RefreshToolBarButton
            // 
            this.RefreshToolBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.RefreshToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.RefreshIcon;
            this.RefreshToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolBarButton.Name = "RefreshToolBarButton";
            this.RefreshToolBarButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.RefreshToolBarButton.Size = new System.Drawing.Size(85, 28);
            this.RefreshToolBarButton.Text = "&Refresh";
            this.RefreshToolBarButton.ToolTipText = "Refresh Selected Tab";
            this.RefreshToolBarButton.Click += new System.EventHandler(this.RefreshToolBarButton_Click);
            // 
            // QuarantineToolBarButton
            // 
            this.QuarantineToolBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.QuarantineToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Control;
            this.QuarantineToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuarantineToolBarButton.Name = "QuarantineToolBarButton";
            this.QuarantineToolBarButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.QuarantineToolBarButton.Size = new System.Drawing.Size(101, 28);
            this.QuarantineToolBarButton.Text = "&Quarantine";
            this.QuarantineToolBarButton.ToolTipText = "View The Anti Virus Quarantine";
            this.QuarantineToolBarButton.Click += new System.EventHandler(this.QuarantineToolBarButton_Click);
            // 
            // ScanDropDownButton
            // 
            this.ScanDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScanMemoryToolBarButton,
            this.ScanToolBarButton,
            this.ScanSharesToolBarButton,
            this.ScanBackupToolBarButton,
            this.userDefinedToolStripMenuItem,
            this.shareToolStripMenuItem});
            this.ScanDropDownButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ScanDropDownButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Scan;
            this.ScanDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ScanDropDownButton.Name = "ScanDropDownButton";
            this.ScanDropDownButton.Size = new System.Drawing.Size(71, 28);
            this.ScanDropDownButton.Text = "&Scan...";
            this.ScanDropDownButton.ToolTipText = "Scanning Options";
            this.ScanDropDownButton.Click += new System.EventHandler(this.ScanDropDownButton_Click);
            // 
            // ScanMemoryToolBarButton
            // 
            this.ScanMemoryToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.ScanMem;
            this.ScanMemoryToolBarButton.Name = "ScanMemoryToolBarButton";
            this.ScanMemoryToolBarButton.Size = new System.Drawing.Size(152, 22);
            this.ScanMemoryToolBarButton.Text = "&Memory";
            this.ScanMemoryToolBarButton.ToolTipText = "Scan Memory For Viruses";
            this.ScanMemoryToolBarButton.Click += new System.EventHandler(this.ScanMemoryToolBarButton_Click);
            // 
            // ScanToolBarButton
            // 
            this.ScanToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Scan;
            this.ScanToolBarButton.Name = "ScanToolBarButton";
            this.ScanToolBarButton.Size = new System.Drawing.Size(152, 22);
            this.ScanToolBarButton.Text = "&System";
            this.ScanToolBarButton.ToolTipText = "Scan System Drive For Viruses";
            this.ScanToolBarButton.Click += new System.EventHandler(this.ScanToolBarButton_Click);
            // 
            // ScanSharesToolBarButton
            // 
            this.ScanSharesToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Scan;
            this.ScanSharesToolBarButton.Name = "ScanSharesToolBarButton";
            this.ScanSharesToolBarButton.Size = new System.Drawing.Size(152, 22);
            this.ScanSharesToolBarButton.Text = "&Data";
            this.ScanSharesToolBarButton.ToolTipText = "Scan Data Drive For Viruses";
            this.ScanSharesToolBarButton.Click += new System.EventHandler(this.ScanSharesToolBarButton_Click);
            // 
            // userDefinedToolStripMenuItem
            // 
            this.userDefinedToolStripMenuItem.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Scan;
            this.userDefinedToolStripMenuItem.Name = "userDefinedToolStripMenuItem";
            this.userDefinedToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userDefinedToolStripMenuItem.Text = "&User Defined";
            this.userDefinedToolStripMenuItem.Click += new System.EventHandler(this.userDefinedToolStripMenuItem_Click);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shareToolStripMenuItem.Text = "Share";
            // 
            // UpdateToolBarButton
            // 
            this.UpdateToolBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.UpdateToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.World;
            this.UpdateToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateToolBarButton.Name = "UpdateToolBarButton";
            this.UpdateToolBarButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.UpdateToolBarButton.Size = new System.Drawing.Size(82, 28);
            this.UpdateToolBarButton.Text = "&Update";
            this.UpdateToolBarButton.ToolTipText = "Update Virus Definition Files";
            this.UpdateToolBarButton.Click += new System.EventHandler(this.UpdateToolBarButton_Click);
            // 
            // StopToolBarButton
            // 
            this.StopToolBarButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.StopToolBarButton.Image = ((System.Drawing.Image)(resources.GetObject("StopToolBarButton.Image")));
            this.StopToolBarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopToolBarButton.Name = "StopToolBarButton";
            this.StopToolBarButton.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.StopToolBarButton.Size = new System.Drawing.Size(69, 28);
            this.StopToolBarButton.Text = "&Stop";
            this.StopToolBarButton.ToolTipText = "Stop All ClamWin Processes";
            this.StopToolBarButton.Click += new System.EventHandler(this.StopToolBarButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // ClamScanStatusLabel
            // 
            this.ClamScanStatusLabel.Enabled = false;
            this.ClamScanStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClamScanStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("ClamScanStatusLabel.Image")));
            this.ClamScanStatusLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClamScanStatusLabel.Name = "ClamScanStatusLabel";
            this.ClamScanStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ClamScanStatusLabel.Size = new System.Drawing.Size(104, 28);
            this.ClamScanStatusLabel.Text = "Scan Status";
            this.ClamScanStatusLabel.ToolTipText = "Shows status of WHSClamAV Scanning";
            this.ClamScanStatusLabel.Visible = false;
            // 
            // ClamUpdateStatusLabel
            // 
            this.ClamUpdateStatusLabel.Enabled = false;
            this.ClamUpdateStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClamUpdateStatusLabel.Image = ((System.Drawing.Image)(resources.GetObject("ClamUpdateStatusLabel.Image")));
            this.ClamUpdateStatusLabel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClamUpdateStatusLabel.Name = "ClamUpdateStatusLabel";
            this.ClamUpdateStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ClamUpdateStatusLabel.Size = new System.Drawing.Size(116, 28);
            this.ClamUpdateStatusLabel.Text = "Update Status";
            this.ClamUpdateStatusLabel.ToolTipText = "Shows status of WHSClamAV Updater";
            this.ClamUpdateStatusLabel.Visible = false;
            // 
            // ScanLogUpdateTimer
            // 
            this.ScanLogUpdateTimer.Interval = 333;
            this.ScanLogUpdateTimer.Tick += new System.EventHandler(this.ScanLogUpdateTimer_Tick);
            // 
            // UpdateLogUpdateTimer
            // 
            this.UpdateLogUpdateTimer.Interval = 333;
            this.UpdateLogUpdateTimer.Tick += new System.EventHandler(this.UpdateLogUpdateTimer_Tick);
            // 
            // CheckClamAVComponentStatusTimer
            // 
            this.CheckClamAVComponentStatusTimer.Enabled = true;
            this.CheckClamAVComponentStatusTimer.Interval = 5000;
            this.CheckClamAVComponentStatusTimer.Tick += new System.EventHandler(this.CheckClamAVComponentStatusTimer_Tick);
            // 
            // ClamWinVerTabPage
            // 
            this.ClamWinVerTabPage.Controls.Add(this.VersionPropertyPageNonEditableTextBoxField);
            this.ClamWinVerTabPage.Location = new System.Drawing.Point(4, 22);
            this.ClamWinVerTabPage.Name = "ClamWinVerTabPage";
            this.ClamWinVerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ClamWinVerTabPage.Size = new System.Drawing.Size(974, 505);
            this.ClamWinVerTabPage.TabIndex = 3;
            this.ClamWinVerTabPage.Text = "Version";
            this.ClamWinVerTabPage.UseVisualStyleBackColor = true;
            // 
            // VersionPropertyPageNonEditableTextBoxField
            // 
            this.VersionPropertyPageNonEditableTextBoxField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.VersionPropertyPageNonEditableTextBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VersionPropertyPageNonEditableTextBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VersionPropertyPageNonEditableTextBoxField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.VersionPropertyPageNonEditableTextBoxField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.VersionPropertyPageNonEditableTextBoxField.Location = new System.Drawing.Point(3, 3);
            this.VersionPropertyPageNonEditableTextBoxField.Multiline = true;
            this.VersionPropertyPageNonEditableTextBoxField.Name = "VersionPropertyPageNonEditableTextBoxField";
            this.VersionPropertyPageNonEditableTextBoxField.ReadOnly = true;
            this.VersionPropertyPageNonEditableTextBoxField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VersionPropertyPageNonEditableTextBoxField.Size = new System.Drawing.Size(968, 499);
            this.VersionPropertyPageNonEditableTextBoxField.TabIndex = 0;
            // 
            // ConfigFileTabPage
            // 
            this.ConfigFileTabPage.Controls.Add(this.ConfigFilePropertyPageNonEditableTextBoxField);
            this.ConfigFileTabPage.Location = new System.Drawing.Point(4, 22);
            this.ConfigFileTabPage.Name = "ConfigFileTabPage";
            this.ConfigFileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigFileTabPage.Size = new System.Drawing.Size(974, 505);
            this.ConfigFileTabPage.TabIndex = 2;
            this.ConfigFileTabPage.Text = "Config File";
            this.ConfigFileTabPage.UseVisualStyleBackColor = true;
            // 
            // ConfigFilePropertyPageNonEditableTextBoxField
            // 
            this.ConfigFilePropertyPageNonEditableTextBoxField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ConfigFilePropertyPageNonEditableTextBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigFilePropertyPageNonEditableTextBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigFilePropertyPageNonEditableTextBoxField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ConfigFilePropertyPageNonEditableTextBoxField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfigFilePropertyPageNonEditableTextBoxField.Location = new System.Drawing.Point(3, 3);
            this.ConfigFilePropertyPageNonEditableTextBoxField.Multiline = true;
            this.ConfigFilePropertyPageNonEditableTextBoxField.Name = "ConfigFilePropertyPageNonEditableTextBoxField";
            this.ConfigFilePropertyPageNonEditableTextBoxField.ReadOnly = true;
            this.ConfigFilePropertyPageNonEditableTextBoxField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConfigFilePropertyPageNonEditableTextBoxField.Size = new System.Drawing.Size(968, 499);
            this.ConfigFilePropertyPageNonEditableTextBoxField.TabIndex = 0;
            // 
            // LogUpdateTabPage
            // 
            this.LogUpdateTabPage.Controls.Add(this.LogUpdatePropertyPageNonEditableTextBoxField);
            this.LogUpdateTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogUpdateTabPage.Name = "LogUpdateTabPage";
            this.LogUpdateTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogUpdateTabPage.Size = new System.Drawing.Size(974, 505);
            this.LogUpdateTabPage.TabIndex = 1;
            this.LogUpdateTabPage.Text = "Update Log";
            this.LogUpdateTabPage.UseVisualStyleBackColor = true;
            // 
            // LogUpdatePropertyPageNonEditableTextBoxField
            // 
            this.LogUpdatePropertyPageNonEditableTextBoxField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LogUpdatePropertyPageNonEditableTextBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogUpdatePropertyPageNonEditableTextBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogUpdatePropertyPageNonEditableTextBoxField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.LogUpdatePropertyPageNonEditableTextBoxField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogUpdatePropertyPageNonEditableTextBoxField.Location = new System.Drawing.Point(3, 3);
            this.LogUpdatePropertyPageNonEditableTextBoxField.Multiline = true;
            this.LogUpdatePropertyPageNonEditableTextBoxField.Name = "LogUpdatePropertyPageNonEditableTextBoxField";
            this.LogUpdatePropertyPageNonEditableTextBoxField.ReadOnly = true;
            this.LogUpdatePropertyPageNonEditableTextBoxField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogUpdatePropertyPageNonEditableTextBoxField.Size = new System.Drawing.Size(968, 499);
            this.LogUpdatePropertyPageNonEditableTextBoxField.TabIndex = 1;
            // 
            // LogScanTabPage
            // 
            this.LogScanTabPage.Controls.Add(this.LogScanPropertyPageNonEditableTextBoxField);
            this.LogScanTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogScanTabPage.Name = "LogScanTabPage";
            this.LogScanTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogScanTabPage.Size = new System.Drawing.Size(974, 505);
            this.LogScanTabPage.TabIndex = 0;
            this.LogScanTabPage.Text = "Scanning Log";
            this.LogScanTabPage.UseVisualStyleBackColor = true;
            // 
            // LogScanPropertyPageNonEditableTextBoxField
            // 
            this.LogScanPropertyPageNonEditableTextBoxField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LogScanPropertyPageNonEditableTextBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogScanPropertyPageNonEditableTextBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogScanPropertyPageNonEditableTextBoxField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.LogScanPropertyPageNonEditableTextBoxField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LogScanPropertyPageNonEditableTextBoxField.Location = new System.Drawing.Point(3, 3);
            this.LogScanPropertyPageNonEditableTextBoxField.Multiline = true;
            this.LogScanPropertyPageNonEditableTextBoxField.Name = "LogScanPropertyPageNonEditableTextBoxField";
            this.LogScanPropertyPageNonEditableTextBoxField.ReadOnly = true;
            this.LogScanPropertyPageNonEditableTextBoxField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogScanPropertyPageNonEditableTextBoxField.Size = new System.Drawing.Size(968, 499);
            this.LogScanPropertyPageNonEditableTextBoxField.TabIndex = 0;
            this.LogScanPropertyPageNonEditableTextBoxField.TextChanged += new System.EventHandler(this.LogScanPropertyPageNonEditableTextBoxField_TextChanged);
            // 
            // LogTabControl
            // 
            this.LogTabControl.Controls.Add(this.LogScanTabPage);
            this.LogTabControl.Controls.Add(this.LogUpdateTabPage);
            this.LogTabControl.Controls.Add(this.ConfigFileTabPage);
            this.LogTabControl.Controls.Add(this.ClamWinVerTabPage);
            this.LogTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.LogTabControl.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.LogTabControl.HeaderFont = new System.Drawing.Font("Tahoma", 8F);
            this.LogTabControl.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LogTabControl.Location = new System.Drawing.Point(0, 34);
            this.LogTabControl.Name = "LogTabControl";
            this.LogTabControl.SelectedIndex = 0;
            this.LogTabControl.Size = new System.Drawing.Size(982, 531);
            this.LogTabControl.TabHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.LogTabControl.TabIndex = 6;
            this.LogTabControl.SelectedIndexChanged += new System.EventHandler(this.LogTabControl_SelectedIndexChanged);
            // 
            // ScanBackupToolBarButton
            // 
            this.ScanBackupToolBarButton.Image = global::Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1.Properties.Resources.Scan;
            this.ScanBackupToolBarButton.Name = "ScanBackupToolBarButton";
            this.ScanBackupToolBarButton.Size = new System.Drawing.Size(152, 22);
            this.ScanBackupToolBarButton.Text = "&Backup";
            this.ScanBackupToolBarButton.Click += new System.EventHandler(this.ScanBackupToolBarButton_Click);
            // 
            // MainTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogTabControl);
            this.Controls.Add(this.consoleToolBar1);
            this.Name = "MainTabUserControl";
            this.Size = new System.Drawing.Size(982, 565);
            this.Load += new System.EventHandler(this.MainTabUserControl_Load);
            this.consoleToolBar1.ResumeLayout(false);
            this.consoleToolBar1.PerformLayout();
            this.ClamWinVerTabPage.ResumeLayout(false);
            this.ClamWinVerTabPage.PerformLayout();
            this.ConfigFileTabPage.ResumeLayout(false);
            this.ConfigFileTabPage.PerformLayout();
            this.LogUpdateTabPage.ResumeLayout(false);
            this.LogUpdateTabPage.PerformLayout();
            this.LogScanTabPage.ResumeLayout(false);
            this.LogScanTabPage.PerformLayout();
            this.LogTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.HomeServer.Controls.ConsoleToolBar consoleToolBar1;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton ClearToolBarButton;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton RefreshToolBarButton;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton QuarantineToolBarButton;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton UpdateToolBarButton;
        private System.Windows.Forms.Timer ScanLogUpdateTimer;
        private System.Windows.Forms.Timer UpdateLogUpdateTimer;
        private System.Windows.Forms.Timer CheckClamAVComponentStatusTimer;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton StopToolBarButton;
        private System.Windows.Forms.ToolStripDropDownButton ScanDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem ScanMemoryToolBarButton;
        private System.Windows.Forms.ToolStripMenuItem ScanToolBarButton;
        private System.Windows.Forms.ToolStripMenuItem ScanSharesToolBarButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton ClamScanStatusLabel;
        private Microsoft.HomeServer.Controls.ConsoleToolBarButton ClamUpdateStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem userDefinedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
        private System.Windows.Forms.TabPage ClamWinVerTabPage;
        private Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField VersionPropertyPageNonEditableTextBoxField;
        private System.Windows.Forms.TabPage ConfigFileTabPage;
        private Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField ConfigFilePropertyPageNonEditableTextBoxField;
        private System.Windows.Forms.TabPage LogUpdateTabPage;
        private Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField LogUpdatePropertyPageNonEditableTextBoxField;
        private System.Windows.Forms.TabPage LogScanTabPage;
        private Microsoft.HomeServer.Controls.PropertyPageNonEditableTextBoxField LogScanPropertyPageNonEditableTextBoxField;
        private Microsoft.HomeServer.Controls.CustomTabControl LogTabControl;
        private System.Windows.Forms.ToolStripMenuItem ScanBackupToolBarButton;

    }
}
