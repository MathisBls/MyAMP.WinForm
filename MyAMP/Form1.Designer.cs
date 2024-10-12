namespace MyAMP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelSideMenu = new Panel();
            btnLogs = new Button();
            btnSubscription = new Button();
            panelPreferencesSubmenu = new Panel();
            button3 = new Button();
            button1 = new Button();
            button2 = new Button();
            btnPreferences = new Button();
            panelVersionsSubmenu = new Panel();
            button4 = new Button();
            button5 = new Button();
            btnVersions = new Button();
            panelProfileSubmenu = new Panel();
            button6 = new Button();
            button7 = new Button();
            btnProfile = new Button();
            btnHome = new Button();
            panelLogo = new Panel();
            pictureBox1 = new PictureBox();
            panelHeader = new Panel();
            profileIcon = new PictureBox();
            localhostIcon = new PictureBox();
            websiteIcon = new PictureBox();
            panelContainer = new Panel();
            startApache = new Button();
            startMySQL = new Button();
            statusApacheCircle = new Panel();
            statusSQLCircle = new Panel();
            notifyIcon1 = new NotifyIcon(components);
            panelSideMenu.SuspendLayout();
            panelPreferencesSubmenu.SuspendLayout();
            panelVersionsSubmenu.SuspendLayout();
            panelProfileSubmenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profileIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)localhostIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)websiteIcon).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.AutoScroll = true;
            panelSideMenu.AutoScrollMargin = new Size(5, 5);
            panelSideMenu.BackColor = Color.FromArgb(11, 7, 17);
            panelSideMenu.Controls.Add(btnLogs);
            panelSideMenu.Controls.Add(btnSubscription);
            panelSideMenu.Controls.Add(panelPreferencesSubmenu);
            panelSideMenu.Controls.Add(btnPreferences);
            panelSideMenu.Controls.Add(panelVersionsSubmenu);
            panelSideMenu.Controls.Add(btnVersions);
            panelSideMenu.Controls.Add(panelProfileSubmenu);
            panelSideMenu.Controls.Add(btnProfile);
            panelSideMenu.Controls.Add(btnHome);
            panelSideMenu.Controls.Add(panelLogo);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.ForeColor = SystemColors.ControlText;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(200, 561);
            panelSideMenu.TabIndex = 0;
            // 
            // btnLogs
            // 
            btnLogs.Dock = DockStyle.Top;
            btnLogs.FlatAppearance.BorderSize = 0;
            btnLogs.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnLogs.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnLogs.FlatStyle = FlatStyle.Flat;
            btnLogs.Font = new Font("Segoe UI", 14.25F);
            btnLogs.ForeColor = Color.White;
            btnLogs.Location = new Point(0, 670);
            btnLogs.Name = "btnLogs";
            btnLogs.Padding = new Padding(10, 0, 0, 0);
            btnLogs.Size = new Size(183, 45);
            btnLogs.TabIndex = 14;
            btnLogs.Text = "Logs";
            btnLogs.TextAlign = ContentAlignment.MiddleLeft;
            btnLogs.UseVisualStyleBackColor = true;
            btnLogs.Click += btnLogs_Click;
            // 
            // btnSubscription
            // 
            btnSubscription.Dock = DockStyle.Top;
            btnSubscription.FlatAppearance.BorderSize = 0;
            btnSubscription.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnSubscription.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnSubscription.FlatStyle = FlatStyle.Flat;
            btnSubscription.Font = new Font("Segoe UI", 14.25F);
            btnSubscription.ForeColor = Color.White;
            btnSubscription.Location = new Point(0, 625);
            btnSubscription.Name = "btnSubscription";
            btnSubscription.Padding = new Padding(10, 0, 0, 0);
            btnSubscription.Size = new Size(183, 45);
            btnSubscription.TabIndex = 13;
            btnSubscription.Text = "MyAMP Pro";
            btnSubscription.TextAlign = ContentAlignment.MiddleLeft;
            btnSubscription.UseVisualStyleBackColor = true;
            btnSubscription.Click += btnSubscription_Click;
            // 
            // panelPreferencesSubmenu
            // 
            panelPreferencesSubmenu.BackColor = Color.FromArgb(35, 32, 39);
            panelPreferencesSubmenu.Controls.Add(button3);
            panelPreferencesSubmenu.Controls.Add(button1);
            panelPreferencesSubmenu.Controls.Add(button2);
            panelPreferencesSubmenu.Dock = DockStyle.Top;
            panelPreferencesSubmenu.Location = new Point(0, 496);
            panelPreferencesSubmenu.Name = "panelPreferencesSubmenu";
            panelPreferencesSubmenu.Size = new Size(183, 129);
            panelPreferencesSubmenu.TabIndex = 12;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 11.25F);
            button3.ForeColor = Color.LightGray;
            button3.Location = new Point(0, 83);
            button3.Name = "button3";
            button3.Padding = new Padding(35, 0, 0, 0);
            button3.Size = new Size(183, 42);
            button3.TabIndex = 3;
            button3.Text = "Cloud";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F);
            button1.ForeColor = Color.LightGray;
            button1.Location = new Point(0, 41);
            button1.Name = "button1";
            button1.Padding = new Padding(35, 0, 0, 0);
            button1.Size = new Size(183, 42);
            button1.TabIndex = 2;
            button1.Text = "Server";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11.25F);
            button2.ForeColor = Color.LightGray;
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Padding = new Padding(35, 0, 0, 0);
            button2.Size = new Size(183, 41);
            button2.TabIndex = 1;
            button2.Text = "General";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnPreferences
            // 
            btnPreferences.Dock = DockStyle.Top;
            btnPreferences.FlatAppearance.BorderSize = 0;
            btnPreferences.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnPreferences.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnPreferences.FlatStyle = FlatStyle.Flat;
            btnPreferences.Font = new Font("Segoe UI", 14.25F);
            btnPreferences.ForeColor = Color.White;
            btnPreferences.Location = new Point(0, 451);
            btnPreferences.Name = "btnPreferences";
            btnPreferences.Padding = new Padding(10, 0, 0, 0);
            btnPreferences.Size = new Size(183, 45);
            btnPreferences.TabIndex = 9;
            btnPreferences.Text = "Preferences";
            btnPreferences.TextAlign = ContentAlignment.MiddleLeft;
            btnPreferences.UseVisualStyleBackColor = true;
            btnPreferences.Click += btnPreferences_Click;
            // 
            // panelVersionsSubmenu
            // 
            panelVersionsSubmenu.BackColor = Color.FromArgb(35, 32, 39);
            panelVersionsSubmenu.Controls.Add(button4);
            panelVersionsSubmenu.Controls.Add(button5);
            panelVersionsSubmenu.Dock = DockStyle.Top;
            panelVersionsSubmenu.Location = new Point(0, 363);
            panelVersionsSubmenu.Name = "panelVersionsSubmenu";
            panelVersionsSubmenu.Size = new Size(183, 88);
            panelVersionsSubmenu.TabIndex = 8;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 11.25F);
            button4.ForeColor = Color.LightGray;
            button4.Location = new Point(0, 41);
            button4.Name = "button4";
            button4.Padding = new Padding(35, 0, 0, 0);
            button4.Size = new Size(183, 42);
            button4.TabIndex = 2;
            button4.Text = "PHPMyAdmin";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 11.25F);
            button5.ForeColor = Color.LightGray;
            button5.Location = new Point(0, 0);
            button5.Name = "button5";
            button5.Padding = new Padding(35, 0, 0, 0);
            button5.Size = new Size(183, 41);
            button5.TabIndex = 1;
            button5.Text = "Web Services";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // btnVersions
            // 
            btnVersions.Dock = DockStyle.Top;
            btnVersions.FlatAppearance.BorderSize = 0;
            btnVersions.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnVersions.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnVersions.FlatStyle = FlatStyle.Flat;
            btnVersions.Font = new Font("Segoe UI", 14.25F);
            btnVersions.ForeColor = Color.White;
            btnVersions.Location = new Point(0, 318);
            btnVersions.Name = "btnVersions";
            btnVersions.Padding = new Padding(10, 0, 0, 0);
            btnVersions.Size = new Size(183, 45);
            btnVersions.TabIndex = 7;
            btnVersions.Text = "Versions";
            btnVersions.TextAlign = ContentAlignment.MiddleLeft;
            btnVersions.UseVisualStyleBackColor = true;
            btnVersions.Click += btnVersions_Click;
            // 
            // panelProfileSubmenu
            // 
            panelProfileSubmenu.BackColor = Color.FromArgb(35, 32, 39);
            panelProfileSubmenu.Controls.Add(button6);
            panelProfileSubmenu.Controls.Add(button7);
            panelProfileSubmenu.Dock = DockStyle.Top;
            panelProfileSubmenu.Location = new Point(0, 230);
            panelProfileSubmenu.Name = "panelProfileSubmenu";
            panelProfileSubmenu.Size = new Size(183, 88);
            panelProfileSubmenu.TabIndex = 6;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI", 11.25F);
            button6.ForeColor = Color.LightGray;
            button6.Location = new Point(0, 41);
            button6.Name = "button6";
            button6.Padding = new Padding(35, 0, 0, 0);
            button6.Size = new Size(183, 42);
            button6.TabIndex = 2;
            button6.Text = "Register";
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Top;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.LightGray;
            button7.Location = new Point(0, 0);
            button7.Name = "button7";
            button7.Padding = new Padding(35, 0, 0, 0);
            button7.Size = new Size(183, 41);
            button7.TabIndex = 1;
            button7.Text = "Login";
            button7.TextAlign = ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // btnProfile
            // 
            btnProfile.Dock = DockStyle.Top;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 14.25F);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0, 185);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new Padding(10, 0, 0, 0);
            btnProfile.Size = new Size(183, 45);
            btnProfile.TabIndex = 3;
            btnProfile.Text = "Profile";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 30, 70);
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 30, 70);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 140);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 0, 0);
            btnHome.Size = new Size(183, 45);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(183, 140);
            panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.MyAMP_rogner;
            pictureBox1.Location = new Point(12, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(86, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(11, 7, 17);
            panelHeader.Controls.Add(profileIcon);
            panelHeader.Controls.Add(localhostIcon);
            panelHeader.Controls.Add(websiteIcon);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(200, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(766, 67);
            panelHeader.TabIndex = 1;
            // 
            // profileIcon
            // 
            profileIcon.Image = (Image)resources.GetObject("profileIcon.Image");
            profileIcon.Location = new Point(690, 12);
            profileIcon.Name = "profileIcon";
            profileIcon.Size = new Size(41, 35);
            profileIcon.SizeMode = PictureBoxSizeMode.Zoom;
            profileIcon.TabIndex = 3;
            profileIcon.TabStop = false;
            profileIcon.Click += profileIcon_Click;
            // 
            // localhostIcon
            // 
            localhostIcon.Image = (Image)resources.GetObject("localhostIcon.Image");
            localhostIcon.Location = new Point(92, 12);
            localhostIcon.Name = "localhostIcon";
            localhostIcon.Size = new Size(37, 35);
            localhostIcon.SizeMode = PictureBoxSizeMode.Zoom;
            localhostIcon.TabIndex = 2;
            localhostIcon.TabStop = false;
            localhostIcon.Click += localhostIcon_Click;
            // 
            // websiteIcon
            // 
            websiteIcon.Image = (Image)resources.GetObject("websiteIcon.Image");
            websiteIcon.Location = new Point(18, 12);
            websiteIcon.Name = "websiteIcon";
            websiteIcon.Size = new Size(41, 35);
            websiteIcon.SizeMode = PictureBoxSizeMode.Zoom;
            websiteIcon.TabIndex = 1;
            websiteIcon.TabStop = false;
            websiteIcon.Click += websiteIcon_Click;
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.FromArgb(32, 30, 45);
            panelContainer.Dock = DockStyle.Left;
            panelContainer.Location = new Point(200, 67);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(766, 494);
            panelContainer.TabIndex = 2;
            // 
            // startApache
            // 
            startApache.Location = new Point(0, 0);
            startApache.Name = "startApache";
            startApache.Size = new Size(75, 23);
            startApache.TabIndex = 0;
            // 
            // startMySQL
            // 
            startMySQL.Location = new Point(0, 0);
            startMySQL.Name = "startMySQL";
            startMySQL.Size = new Size(75, 23);
            startMySQL.TabIndex = 0;
            // 
            // statusApacheCircle
            // 
            statusApacheCircle.Location = new Point(0, 0);
            statusApacheCircle.Name = "statusApacheCircle";
            statusApacheCircle.Size = new Size(200, 100);
            statusApacheCircle.TabIndex = 0;
            // 
            // statusSQLCircle
            // 
            statusSQLCircle.Location = new Point(0, 0);
            statusSQLCircle.Name = "statusSQLCircle";
            statusSQLCircle.Size = new Size(200, 100);
            statusSQLCircle.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "MyAMP";
            notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 561);
            Controls.Add(panelContainer);
            Controls.Add(panelHeader);
            Controls.Add(panelSideMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(950, 600);
            Name = "Form1";
            Text = "MyAMP";
            panelSideMenu.ResumeLayout(false);
            panelPreferencesSubmenu.ResumeLayout(false);
            panelVersionsSubmenu.ResumeLayout(false);
            panelProfileSubmenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profileIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)localhostIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)websiteIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private Button btnHome;
        private Panel panelLogo;
        private Panel panelProfileSubmenu;
        private Button button6;
        private Button button7;
        private Button btnProfile;
        private Panel panelVersionsSubmenu;
        private Button button4;
        private Button button5;
        private Button btnVersions;
        private Button btnPreferences;
        private Panel panelPreferencesSubmenu;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btnLogs;
        private Button btnSubscription;
        private Panel panelHeader;
        private PictureBox pictureBox1;
        private Panel panelContainer;
        private PictureBox profileIcon;
        private PictureBox localhostIcon;
        private PictureBox websiteIcon;
        private NotifyIcon notifyIcon1;
    }
}
