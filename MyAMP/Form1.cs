using System.Windows.Forms.VisualStyles;
using System.Drawing;
using System.Windows.Forms;
using System.ServiceProcess;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyAMP
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        private System.Windows.Forms.Timer statusTimer;
        private Button startApache;
        private Button startMySQL;
        private Panel statusApacheCircle;
        private Panel statusSQLCircle;
        string apacheServiceName = "Apache2.4";
        string sqlServiceName = "MySQL";
        private ServiceManager serviceManager;
        private Home homeForm;

        //Notify
        private NotifyIconMenuManagerLeftClick _menuManagerLeftClick;
        private NotifyIconMenuManagerRightClick _menuManagerRightClick;
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
            panelSideMenu.AutoScroll = true;
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.Size = new Size(this.Width, 30);
            titleBar.BackColor = Color.FromArgb(11, 7, 17);
            titleBar.Dock = DockStyle.Top;
            this.Controls.Add(titleBar);

            Label lblClose = new Label();
            lblClose.Text = "✖";
            lblClose.Font = new Font("Arial", 12, FontStyle.Bold);
            lblClose.ForeColor = Color.White;
            lblClose.Size = new Size(30, 30);
            lblClose.Location = new Point(titleBar.Width - 40, 0);
            lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += new EventHandler(lblClose_Click);
            titleBar.Controls.Add(lblClose);

            Label lblMinimize = new Label();
            lblMinimize.Text = "➖";
            lblMinimize.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMinimize.ForeColor = Color.White;
            lblMinimize.Size = new Size(30, 30);
            lblMinimize.Location = new Point(titleBar.Width - 80, 0);
            lblMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblMinimize.Cursor = Cursors.Hand;
            lblMinimize.Click += new EventHandler(lblMinimize_Click);
            titleBar.Controls.Add(lblMinimize);

            titleBar.MouseDown += new MouseEventHandler(titleBar_MouseDown);
            titleBar.MouseMove += new MouseEventHandler(titleBar_MouseMove);
            titleBar.MouseUp += new MouseEventHandler(titleBar_MouseUp);

            websiteIcon.Cursor = Cursors.Hand;
            localhostIcon.Cursor = Cursors.Hand;
            profileIcon.Cursor = Cursors.Hand;

            UpdateLocalhostIcon();

            #region timerUpdate
            statusTimer = new System.Windows.Forms.Timer();
            statusTimer.Interval = 1000;
            statusTimer.Tick += (s, e) => UpdateLocalhostIcon();
            statusTimer.Start();
            #endregion

            serviceManager = new ServiceManager(startApache, startMySQL, statusApacheCircle, statusSQLCircle);

            serviceManager.UpdateServiceButtons();
            homeForm = new Home();
            //par default
            openChildForm(new Home());

            _menuManagerLeftClick = new NotifyIconMenuManagerLeftClick(notifyIcon1, this);
            _menuManagerRightClick = new NotifyIconMenuManagerRightClick(notifyIcon1, this);

            notifyIcon1.Visible = true;

            // Gérer les clics sur l'icône
            notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            // Gérer la minimisation
            this.Resize += new EventHandler(Form1_Resize);

        }

        #region NotifyIcon
        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _menuManagerLeftClick.ShowMenu();
            }
            else if (e.Button == MouseButtons.Right)
            {
                _menuManagerRightClick.ShowMenu();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.Hide(); // Masquer la fenêtre
            }
        }
        #endregion

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #region TitleBar
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = new Point(Cursor.Position.X - dragCursor.X, Cursor.Position.Y - dragCursor.Y);
                this.Location = new Point(dragForm.X + dif.X, dragForm.Y + dif.Y);
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private void customizeDesign()
        {
            panelProfileSubmenu.Visible = false;
            panelVersionsSubmenu.Visible = false;
            panelPreferencesSubmenu.Visible = false;
        }

        private void InitializeControls()
        {
            // Initialiser les boutons et panels (exemple de création dynamique)
            startApache = new Button
            {
                Text = "Start Apache",
                ForeColor = Color.White,
                Location = new Point(10, 10),
                Size = new Size(120, 30)
            };

            startMySQL = new Button
            {
                Text = "Start MySQL",
                ForeColor = Color.White,
                Location = new Point(10, 50),
                Size = new Size(120, 30)
            };

            statusApacheCircle = new Panel
            {
                BackColor = Color.Red,
                Location = new Point(140, 10),
                Size = new Size(20, 20)
            };

            statusSQLCircle = new Panel
            {
                BackColor = Color.Red,
                Location = new Point(140, 50),
                Size = new Size(20, 20)
            };

            // Ajouter les contrôles au formulaire
            this.Controls.Add(startApache);
            this.Controls.Add(startMySQL);
            this.Controls.Add(statusApacheCircle);
            this.Controls.Add(statusSQLCircle);
        }

        private void hideSubMenu()
        {
            if (panelProfileSubmenu.Visible == true)
                panelProfileSubmenu.Visible = false;
            if (panelVersionsSubmenu.Visible == true)
                panelVersionsSubmenu.Visible = false;
            if (panelPreferencesSubmenu.Visible == true)
                panelPreferencesSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            showSubMenu(panelProfileSubmenu);
        }
        #region ProfileSubMenu

        private void button7_Click(object sender, EventArgs e) //Login
        {
            openChildForm(new Login(this));

            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)//Register
        {
            openChildForm(new Register());
            hideSubMenu();
        }
        #endregion

        private void btnVersions_Click(object sender, EventArgs e)
        {
            showSubMenu(panelVersionsSubmenu);
        }

        #region VersionsSubMenu
        private void button5_Click(object sender, EventArgs e)//web services
        {
            openChildForm(new WebServices());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e) //phpmyadmin
        {
            openChildForm(new PhpMyAdminServer());
            hideSubMenu();
        }
        #endregion

        private void btnPreferences_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPreferencesSubmenu);
        }

        #region PreferencesSubMenu

        private void button2_Click(object sender, EventArgs e) //General
        {
            openChildForm(new PrefGeneral());
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e) //Server
        {
            openChildForm(new PrefServer());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e) //Cloud
        {
            openChildForm(new PrefCloud());
            hideSubMenu();
        }

        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new Home());
            hideSubMenu();
        }

        private void btnSubscription_Click(object sender, EventArgs e)
        {
            openChildForm(new Subscription());
            hideSubMenu();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            openChildForm(new Logs());

            hideSubMenu();
        }


        private void websiteIcon_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "http://test",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void localhostIcon_Click(object sender, EventArgs e)
        {
            if (!localhostIcon.Enabled)
            {
                MessageBox.Show("Le serveur Apache n'est pas en cours d'exécution.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string iniFilePath = "myamp.ini";
                string serverName = "localhost"; 

                if (File.Exists(iniFilePath))
                {
                    var config = new Salaros.Configuration.ConfigParser(iniFilePath);
                    serverName = config.GetValue("Server", "ServerName", "localhost"); 
                }

                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = $"http://{serverName}",
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("Une erreur est survenue : " + ex.Message);
            }
        }

private void UpdateLocalhostIcon()
{
    if (serviceManager != null && serviceManager.IsServiceRunning(apacheServiceName))
    {
        localhostIcon.Enabled = true;
        localhostIcon.Cursor = Cursors.Hand;
    }
    else
    {
        localhostIcon.Enabled = false;
        localhostIcon.Cursor = Cursors.Default;
    }
}



        private void profileIcon_Click(object sender, EventArgs e)
        {
            if (Session.UserId == 0)
            {
                openChildForm(new Login(this));
            }
            else
            {
                openChildForm(new Profile(Session.UserId));
            }
        }
    }
}
