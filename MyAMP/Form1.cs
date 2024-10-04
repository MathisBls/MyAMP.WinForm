namespace MyAMP
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursor;
        private Point dragForm;
        public Form1()
        {
            InitializeComponent();
            customizeDesign();
            panelSideMenu.AutoScroll = true;
            this.FormBorderStyle = FormBorderStyle.None;

            Panel titleBar = new Panel();
            titleBar.Size = new Size(this.Width, 30);
            titleBar.BackColor = Color.FromArgb(255, 30, 70);
            titleBar.Dock = DockStyle.Top;
            this.Controls.Add(titleBar);

            Label lblClose = new Label();
            lblClose.Text = "✖";
            lblClose.Font = new Font("Arial", 12, FontStyle.Bold);
            lblClose.ForeColor = Color.White;
            lblClose.Size = new Size(30, 30);
            lblClose.Location = new Point(titleBar.Width - 40, 0);
            lblClose.TextAlign = ContentAlignment.MiddleCenter;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Click += new EventHandler(lblClose_Click);
            titleBar.Controls.Add(lblClose);

            Label lblMinimize = new Label();
            lblMinimize.Text = "➖";
            lblMinimize.Font = new Font("Arial", 12, FontStyle.Bold);
            lblMinimize.ForeColor = Color.White;
            lblMinimize.Size = new Size(30, 30);
            lblMinimize.Location = new Point(titleBar.Width - 80, 0);
            lblMinimize.TextAlign = ContentAlignment.MiddleCenter;
            lblMinimize.Cursor = Cursors.Hand;
            lblMinimize.Click += new EventHandler(lblMinimize_Click);
            titleBar.Controls.Add(lblMinimize);

            titleBar.MouseDown += new MouseEventHandler(titleBar_MouseDown);
            titleBar.MouseMove += new MouseEventHandler(titleBar_MouseMove);
            titleBar.MouseUp += new MouseEventHandler(titleBar_MouseUp);

            //par default
            openChildForm(new Home());

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
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
            openChildForm(new Login());

            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)//Register
        {
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
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e) //phpmyadmin
        {
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
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e) //Server
        {
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e) //Cloud
        {
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
            hideSubMenu();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }


        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
