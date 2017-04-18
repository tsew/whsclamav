namespace Microsoft.HomeServer.HomeServerConsoleTab.Home_Server_Add_In1
{
    partial class SettingsTabUserControl
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
            this.tabPageInstall = new System.Windows.Forms.TabPage();
            this.propertyPageGroupBox3 = new Microsoft.HomeServer.Controls.PropertyPageGroupBox();
            this.ClamAVScanEnableButton = new Microsoft.HomeServer.Controls.QButton();
            this.ClamAVScanEnabledLabel = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.ClamAVUpdateEnableButton = new Microsoft.HomeServer.Controls.QButton();
            this.ClamAVUpdateEnabledLabel = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.propertyPageGroupBox2 = new Microsoft.HomeServer.Controls.PropertyPageGroupBox();
            this.DownloadProgressBar = new Microsoft.HomeServer.Controls.StandardProgressBar();
            this.ClamAVInstallLabel = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.DeleteButton = new Microsoft.HomeServer.Controls.QButton();
            this.DownloadButton = new Microsoft.HomeServer.Controls.QButton();
            this.propertyPageGroupBox1 = new Microsoft.HomeServer.Controls.PropertyPageGroupBox();
            this.ProxySaveButton = new Microsoft.HomeServer.Controls.QButton();
            this.ProxyServerTextBox = new System.Windows.Forms.TextBox();
            this.textImageLabel4 = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.ProxyPortTextBox = new System.Windows.Forms.TextBox();
            this.textImageLabel3 = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.ProxyUserTextBox = new System.Windows.Forms.TextBox();
            this.textImageLabel2 = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.ProxyPasswordTextBox = new System.Windows.Forms.TextBox();
            this.textImageLabel1 = new Microsoft.HomeServer.Controls.TextImageLabel();
            this.tabControlSettings = new Microsoft.HomeServer.Controls.CustomTabControl();
            this.tabPageScheduling = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.serviceUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPageInstall.SuspendLayout();
            this.propertyPageGroupBox3.SuspendLayout();
            this.propertyPageGroupBox2.SuspendLayout();
            this.propertyPageGroupBox1.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageScheduling.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageInstall
            // 
            this.tabPageInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tabPageInstall.Controls.Add(this.propertyPageGroupBox3);
            this.tabPageInstall.Controls.Add(this.propertyPageGroupBox2);
            this.tabPageInstall.Controls.Add(this.propertyPageGroupBox1);
            this.tabPageInstall.Location = new System.Drawing.Point(4, 22);
            this.tabPageInstall.Name = "tabPageInstall";
            this.tabPageInstall.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInstall.Size = new System.Drawing.Size(376, 381);
            this.tabPageInstall.TabIndex = 1;
            this.tabPageInstall.Text = "Install";
            // 
            // propertyPageGroupBox3
            // 
            this.propertyPageGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.propertyPageGroupBox3.Controls.Add(this.ClamAVScanEnableButton);
            this.propertyPageGroupBox3.Controls.Add(this.ClamAVScanEnabledLabel);
            this.propertyPageGroupBox3.Controls.Add(this.ClamAVUpdateEnableButton);
            this.propertyPageGroupBox3.Controls.Add(this.ClamAVUpdateEnabledLabel);
            this.propertyPageGroupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.propertyPageGroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.propertyPageGroupBox3.Location = new System.Drawing.Point(6, 91);
            this.propertyPageGroupBox3.Name = "propertyPageGroupBox3";
            this.propertyPageGroupBox3.Size = new System.Drawing.Size(364, 81);
            this.propertyPageGroupBox3.TabIndex = 23;
            this.propertyPageGroupBox3.TabStop = false;
            this.propertyPageGroupBox3.Text = "WHSClamAV Services";
            // 
            // ClamAVScanEnableButton
            // 
            this.ClamAVScanEnableButton.AutoSize = true;
            this.ClamAVScanEnableButton.BackColor = System.Drawing.Color.Transparent;
            this.ClamAVScanEnableButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ClamAVScanEnableButton.FlatAppearance.BorderSize = 0;
            this.ClamAVScanEnableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ClamAVScanEnableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ClamAVScanEnableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClamAVScanEnableButton.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ClamAVScanEnableButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClamAVScanEnableButton.IsHovered = false;
            this.ClamAVScanEnableButton.IsPressed = false;
            this.ClamAVScanEnableButton.Location = new System.Drawing.Point(278, 49);
            this.ClamAVScanEnableButton.Margins = 0;
            this.ClamAVScanEnableButton.MaximumSize = new System.Drawing.Size(360, 21);
            this.ClamAVScanEnableButton.MinimumSize = new System.Drawing.Size(72, 21);
            this.ClamAVScanEnableButton.Name = "ClamAVScanEnableButton";
            this.ClamAVScanEnableButton.Size = new System.Drawing.Size(80, 21);
            this.ClamAVScanEnableButton.TabIndex = 16;
            this.ClamAVScanEnableButton.Text = "Enable";
            this.ClamAVScanEnableButton.UseVisualStyleBackColor = true;
            this.ClamAVScanEnableButton.Click += new System.EventHandler(this.ClamAVScanEnableButton_Click);
            // 
            // ClamAVScanEnabledLabel
            // 
            this.ClamAVScanEnabledLabel.AutoSize = true;
            this.ClamAVScanEnabledLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClamAVScanEnabledLabel.FlatAppearance.BorderSize = 0;
            this.ClamAVScanEnabledLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClamAVScanEnabledLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ClamAVScanEnabledLabel.Location = new System.Drawing.Point(6, 48);
            this.ClamAVScanEnabledLabel.Name = "ClamAVScanEnabledLabel";
            this.ClamAVScanEnabledLabel.Size = new System.Drawing.Size(266, 23);
            this.ClamAVScanEnabledLabel.TabIndex = 15;
            this.ClamAVScanEnabledLabel.TabStop = false;
            this.ClamAVScanEnabledLabel.Text = "textImageLabel1";
            this.ClamAVScanEnabledLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClamAVScanEnabledLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClamAVScanEnabledLabel.UseVisualStyleBackColor = true;
            // 
            // ClamAVUpdateEnableButton
            // 
            this.ClamAVUpdateEnableButton.AutoSize = true;
            this.ClamAVUpdateEnableButton.BackColor = System.Drawing.Color.Transparent;
            this.ClamAVUpdateEnableButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ClamAVUpdateEnableButton.FlatAppearance.BorderSize = 0;
            this.ClamAVUpdateEnableButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ClamAVUpdateEnableButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ClamAVUpdateEnableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClamAVUpdateEnableButton.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ClamAVUpdateEnableButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClamAVUpdateEnableButton.IsHovered = false;
            this.ClamAVUpdateEnableButton.IsPressed = false;
            this.ClamAVUpdateEnableButton.Location = new System.Drawing.Point(278, 20);
            this.ClamAVUpdateEnableButton.Margins = 0;
            this.ClamAVUpdateEnableButton.MaximumSize = new System.Drawing.Size(360, 21);
            this.ClamAVUpdateEnableButton.MinimumSize = new System.Drawing.Size(72, 21);
            this.ClamAVUpdateEnableButton.Name = "ClamAVUpdateEnableButton";
            this.ClamAVUpdateEnableButton.Size = new System.Drawing.Size(80, 21);
            this.ClamAVUpdateEnableButton.TabIndex = 14;
            this.ClamAVUpdateEnableButton.Text = "Enable";
            this.ClamAVUpdateEnableButton.UseVisualStyleBackColor = true;
            this.ClamAVUpdateEnableButton.Click += new System.EventHandler(this.ClamAVUpdateEnableButton_Click);
            // 
            // ClamAVUpdateEnabledLabel
            // 
            this.ClamAVUpdateEnabledLabel.AutoSize = true;
            this.ClamAVUpdateEnabledLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClamAVUpdateEnabledLabel.FlatAppearance.BorderSize = 0;
            this.ClamAVUpdateEnabledLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClamAVUpdateEnabledLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ClamAVUpdateEnabledLabel.Location = new System.Drawing.Point(6, 19);
            this.ClamAVUpdateEnabledLabel.Name = "ClamAVUpdateEnabledLabel";
            this.ClamAVUpdateEnabledLabel.Size = new System.Drawing.Size(266, 23);
            this.ClamAVUpdateEnabledLabel.TabIndex = 13;
            this.ClamAVUpdateEnabledLabel.TabStop = false;
            this.ClamAVUpdateEnabledLabel.Text = "textImageLabel1";
            this.ClamAVUpdateEnabledLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClamAVUpdateEnabledLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClamAVUpdateEnabledLabel.UseVisualStyleBackColor = true;
            // 
            // propertyPageGroupBox2
            // 
            this.propertyPageGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.propertyPageGroupBox2.Controls.Add(this.DownloadProgressBar);
            this.propertyPageGroupBox2.Controls.Add(this.ClamAVInstallLabel);
            this.propertyPageGroupBox2.Controls.Add(this.DeleteButton);
            this.propertyPageGroupBox2.Controls.Add(this.DownloadButton);
            this.propertyPageGroupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.propertyPageGroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.propertyPageGroupBox2.Location = new System.Drawing.Point(6, 6);
            this.propertyPageGroupBox2.Name = "propertyPageGroupBox2";
            this.propertyPageGroupBox2.Size = new System.Drawing.Size(364, 79);
            this.propertyPageGroupBox2.TabIndex = 22;
            this.propertyPageGroupBox2.TabStop = false;
            this.propertyPageGroupBox2.Text = "ClamAV Installation";
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DownloadProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(155)))), ((int)(((byte)(49)))));
            this.DownloadProgressBar.Location = new System.Drawing.Point(40, 47);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(232, 16);
            this.DownloadProgressBar.TabIndex = 12;
            this.DownloadProgressBar.Visible = false;
            this.DownloadProgressBar.Click += new System.EventHandler(this.DownloadProgressBar_Click);
            // 
            // ClamAVInstallLabel
            // 
            this.ClamAVInstallLabel.AutoSize = true;
            this.ClamAVInstallLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClamAVInstallLabel.FlatAppearance.BorderSize = 0;
            this.ClamAVInstallLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClamAVInstallLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ClamAVInstallLabel.Location = new System.Drawing.Point(6, 18);
            this.ClamAVInstallLabel.Name = "ClamAVInstallLabel";
            this.ClamAVInstallLabel.Size = new System.Drawing.Size(266, 23);
            this.ClamAVInstallLabel.TabIndex = 3;
            this.ClamAVInstallLabel.TabStop = false;
            this.ClamAVInstallLabel.Text = "textImageLabel1";
            this.ClamAVInstallLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClamAVInstallLabel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClamAVInstallLabel.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.AutoSize = true;
            this.DeleteButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.DeleteButton.FlatAppearance.BorderSize = 0;
            this.DeleteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteButton.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DeleteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteButton.IsHovered = false;
            this.DeleteButton.IsPressed = false;
            this.DeleteButton.Location = new System.Drawing.Point(278, 48);
            this.DeleteButton.Margins = 0;
            this.DeleteButton.MaximumSize = new System.Drawing.Size(360, 21);
            this.DeleteButton.MinimumSize = new System.Drawing.Size(72, 21);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(80, 21);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.AutoSize = true;
            this.DownloadButton.BackColor = System.Drawing.Color.Transparent;
            this.DownloadButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.DownloadButton.FlatAppearance.BorderSize = 0;
            this.DownloadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.DownloadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DownloadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DownloadButton.IsHovered = false;
            this.DownloadButton.IsPressed = false;
            this.DownloadButton.Location = new System.Drawing.Point(278, 21);
            this.DownloadButton.Margins = 0;
            this.DownloadButton.MaximumSize = new System.Drawing.Size(360, 21);
            this.DownloadButton.MinimumSize = new System.Drawing.Size(72, 21);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(80, 21);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Installing";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // propertyPageGroupBox1
            // 
            this.propertyPageGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.propertyPageGroupBox1.Controls.Add(this.ProxySaveButton);
            this.propertyPageGroupBox1.Controls.Add(this.ProxyServerTextBox);
            this.propertyPageGroupBox1.Controls.Add(this.textImageLabel4);
            this.propertyPageGroupBox1.Controls.Add(this.ProxyPortTextBox);
            this.propertyPageGroupBox1.Controls.Add(this.textImageLabel3);
            this.propertyPageGroupBox1.Controls.Add(this.ProxyUserTextBox);
            this.propertyPageGroupBox1.Controls.Add(this.textImageLabel2);
            this.propertyPageGroupBox1.Controls.Add(this.ProxyPasswordTextBox);
            this.propertyPageGroupBox1.Controls.Add(this.textImageLabel1);
            this.propertyPageGroupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.propertyPageGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.propertyPageGroupBox1.Location = new System.Drawing.Point(6, 178);
            this.propertyPageGroupBox1.Name = "propertyPageGroupBox1";
            this.propertyPageGroupBox1.Size = new System.Drawing.Size(364, 125);
            this.propertyPageGroupBox1.TabIndex = 21;
            this.propertyPageGroupBox1.TabStop = false;
            this.propertyPageGroupBox1.Text = "Proxy Server Settings";
            // 
            // ProxySaveButton
            // 
            this.ProxySaveButton.AutoSize = true;
            this.ProxySaveButton.BackColor = System.Drawing.Color.Transparent;
            this.ProxySaveButton.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ProxySaveButton.FlatAppearance.BorderSize = 0;
            this.ProxySaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProxySaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProxySaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProxySaveButton.Font = new System.Drawing.Font("Tahoma", 8F);
            this.ProxySaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ProxySaveButton.IsHovered = false;
            this.ProxySaveButton.IsPressed = false;
            this.ProxySaveButton.Location = new System.Drawing.Point(278, 98);
            this.ProxySaveButton.Margins = 0;
            this.ProxySaveButton.MaximumSize = new System.Drawing.Size(360, 21);
            this.ProxySaveButton.MinimumSize = new System.Drawing.Size(72, 21);
            this.ProxySaveButton.Name = "ProxySaveButton";
            this.ProxySaveButton.Size = new System.Drawing.Size(80, 21);
            this.ProxySaveButton.TabIndex = 21;
            this.ProxySaveButton.Text = "Save";
            this.ProxySaveButton.UseVisualStyleBackColor = true;
            this.ProxySaveButton.Click += new System.EventHandler(this.ProxySaveButton_Click);
            // 
            // ProxyServerTextBox
            // 
            this.ProxyServerTextBox.Location = new System.Drawing.Point(93, 21);
            this.ProxyServerTextBox.Name = "ProxyServerTextBox";
            this.ProxyServerTextBox.Size = new System.Drawing.Size(179, 20);
            this.ProxyServerTextBox.TabIndex = 13;
            this.ProxyServerTextBox.TextChanged += new System.EventHandler(this.ProxyServerTextBox_TextChanged);
            // 
            // textImageLabel4
            // 
            this.textImageLabel4.AutoSize = true;
            this.textImageLabel4.BackColor = System.Drawing.Color.Transparent;
            this.textImageLabel4.FlatAppearance.BorderSize = 0;
            this.textImageLabel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textImageLabel4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.textImageLabel4.Location = new System.Drawing.Point(6, 97);
            this.textImageLabel4.Name = "textImageLabel4";
            this.textImageLabel4.Size = new System.Drawing.Size(81, 23);
            this.textImageLabel4.TabIndex = 20;
            this.textImageLabel4.TabStop = false;
            this.textImageLabel4.Text = "Password";
            this.textImageLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textImageLabel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textImageLabel4.UseVisualStyleBackColor = true;
            // 
            // ProxyPortTextBox
            // 
            this.ProxyPortTextBox.Location = new System.Drawing.Point(93, 47);
            this.ProxyPortTextBox.Name = "ProxyPortTextBox";
            this.ProxyPortTextBox.Size = new System.Drawing.Size(76, 20);
            this.ProxyPortTextBox.TabIndex = 14;
            this.ProxyPortTextBox.TextChanged += new System.EventHandler(this.ProxyPortTextBox_TextChanged);
            // 
            // textImageLabel3
            // 
            this.textImageLabel3.AutoSize = true;
            this.textImageLabel3.BackColor = System.Drawing.Color.Transparent;
            this.textImageLabel3.FlatAppearance.BorderSize = 0;
            this.textImageLabel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textImageLabel3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.textImageLabel3.Location = new System.Drawing.Point(6, 71);
            this.textImageLabel3.Name = "textImageLabel3";
            this.textImageLabel3.Size = new System.Drawing.Size(81, 23);
            this.textImageLabel3.TabIndex = 19;
            this.textImageLabel3.TabStop = false;
            this.textImageLabel3.Text = "User Name";
            this.textImageLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textImageLabel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textImageLabel3.UseVisualStyleBackColor = true;
            // 
            // ProxyUserTextBox
            // 
            this.ProxyUserTextBox.Location = new System.Drawing.Point(93, 73);
            this.ProxyUserTextBox.Name = "ProxyUserTextBox";
            this.ProxyUserTextBox.Size = new System.Drawing.Size(179, 20);
            this.ProxyUserTextBox.TabIndex = 15;
            this.ProxyUserTextBox.TextChanged += new System.EventHandler(this.ProxyUserTextBox_TextChanged);
            // 
            // textImageLabel2
            // 
            this.textImageLabel2.AutoSize = true;
            this.textImageLabel2.BackColor = System.Drawing.Color.Transparent;
            this.textImageLabel2.FlatAppearance.BorderSize = 0;
            this.textImageLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textImageLabel2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.textImageLabel2.Location = new System.Drawing.Point(6, 45);
            this.textImageLabel2.Name = "textImageLabel2";
            this.textImageLabel2.Size = new System.Drawing.Size(81, 23);
            this.textImageLabel2.TabIndex = 18;
            this.textImageLabel2.TabStop = false;
            this.textImageLabel2.Text = "Port";
            this.textImageLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textImageLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textImageLabel2.UseVisualStyleBackColor = true;
            // 
            // ProxyPasswordTextBox
            // 
            this.ProxyPasswordTextBox.Location = new System.Drawing.Point(93, 99);
            this.ProxyPasswordTextBox.Name = "ProxyPasswordTextBox";
            this.ProxyPasswordTextBox.Size = new System.Drawing.Size(179, 20);
            this.ProxyPasswordTextBox.TabIndex = 16;
            this.ProxyPasswordTextBox.TextChanged += new System.EventHandler(this.ProxyPasswordTextBox_TextChanged);
            // 
            // textImageLabel1
            // 
            this.textImageLabel1.AutoSize = true;
            this.textImageLabel1.BackColor = System.Drawing.Color.Transparent;
            this.textImageLabel1.FlatAppearance.BorderSize = 0;
            this.textImageLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textImageLabel1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.textImageLabel1.Location = new System.Drawing.Point(6, 19);
            this.textImageLabel1.Name = "textImageLabel1";
            this.textImageLabel1.Size = new System.Drawing.Size(81, 23);
            this.textImageLabel1.TabIndex = 17;
            this.textImageLabel1.TabStop = false;
            this.textImageLabel1.Text = "Server";
            this.textImageLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.textImageLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.textImageLabel1.UseVisualStyleBackColor = true;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageInstall);
            this.tabControlSettings.Controls.Add(this.tabPageScheduling);
            this.tabControlSettings.Controls.Add(this.tabPageSettings);
            this.tabControlSettings.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlSettings.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.tabControlSettings.HeaderFont = new System.Drawing.Font("Tahoma", 8F);
            this.tabControlSettings.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabControlSettings.Location = new System.Drawing.Point(3, 3);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(384, 407);
            this.tabControlSettings.TabHeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tabControlSettings.TabIndex = 23;
            // 
            // tabPageScheduling
            // 
            this.tabPageScheduling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tabPageScheduling.Controls.Add(this.label1);
            this.tabPageScheduling.Location = new System.Drawing.Point(4, 22);
            this.tabPageScheduling.Name = "tabPageScheduling";
            this.tabPageScheduling.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScheduling.Size = new System.Drawing.Size(376, 381);
            this.tabPageScheduling.TabIndex = 2;
            this.tabPageScheduling.Text = "Scheduling";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not Yet Implemented";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(243)))));
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(376, 381);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Not Yet Implemented";
            // 
            // serviceUpdateTimer
            // 
            this.serviceUpdateTimer.Enabled = true;
            this.serviceUpdateTimer.Interval = 3333;
            this.serviceUpdateTimer.Tick += new System.EventHandler(this.serviceUpdateTimer_Tick);
            // 
            // SettingsTabUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tabControlSettings);
            this.Name = "SettingsTabUserControl";
            this.Size = new System.Drawing.Size(390, 410);
            this.Load += new System.EventHandler(this.SettingsTabUserControl_Load);
            this.tabPageInstall.ResumeLayout(false);
            this.propertyPageGroupBox3.ResumeLayout(false);
            this.propertyPageGroupBox3.PerformLayout();
            this.propertyPageGroupBox2.ResumeLayout(false);
            this.propertyPageGroupBox2.PerformLayout();
            this.propertyPageGroupBox1.ResumeLayout(false);
            this.propertyPageGroupBox1.PerformLayout();
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageScheduling.ResumeLayout(false);
            this.tabPageScheduling.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageInstall;
        private Microsoft.HomeServer.Controls.PropertyPageGroupBox propertyPageGroupBox2;
        private Microsoft.HomeServer.Controls.StandardProgressBar DownloadProgressBar;
        private Microsoft.HomeServer.Controls.TextImageLabel ClamAVInstallLabel;
        private Microsoft.HomeServer.Controls.QButton DeleteButton;
        private Microsoft.HomeServer.Controls.QButton DownloadButton;
        private Microsoft.HomeServer.Controls.PropertyPageGroupBox propertyPageGroupBox1;
        private Microsoft.HomeServer.Controls.QButton ProxySaveButton;
        private System.Windows.Forms.TextBox ProxyServerTextBox;
        private Microsoft.HomeServer.Controls.TextImageLabel textImageLabel4;
        private System.Windows.Forms.TextBox ProxyPortTextBox;
        private Microsoft.HomeServer.Controls.TextImageLabel textImageLabel3;
        private System.Windows.Forms.TextBox ProxyUserTextBox;
        private Microsoft.HomeServer.Controls.TextImageLabel textImageLabel2;
        private System.Windows.Forms.TextBox ProxyPasswordTextBox;
        private Microsoft.HomeServer.Controls.TextImageLabel textImageLabel1;
        private Microsoft.HomeServer.Controls.CustomTabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageScheduling;
        private System.Windows.Forms.TabPage tabPageSettings;
        private Microsoft.HomeServer.Controls.PropertyPageGroupBox propertyPageGroupBox3;
        private Microsoft.HomeServer.Controls.QButton ClamAVUpdateEnableButton;
        private Microsoft.HomeServer.Controls.TextImageLabel ClamAVUpdateEnabledLabel;
        private Microsoft.HomeServer.Controls.TextImageLabel ClamAVScanEnabledLabel;
        private Microsoft.HomeServer.Controls.QButton ClamAVScanEnableButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer serviceUpdateTimer;



    }
}
