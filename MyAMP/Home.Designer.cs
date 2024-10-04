namespace MyAMP
{
    partial class Home
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            DocumentRoot = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ServerName = new TextBox();
            startMySQL = new Button();
            browse = new Button();
            updateButton = new Button();
            label3 = new Label();
            label4 = new Label();
            startApache = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.bdd_red;
            pictureBox1.Location = new Point(236, 218);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.apache_red;
            pictureBox2.Location = new Point(510, 188);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 43);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // DocumentRoot
            // 
            DocumentRoot.BackColor = Color.FromArgb(11, 7, 17);
            DocumentRoot.BorderStyle = BorderStyle.None;
            DocumentRoot.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DocumentRoot.ForeColor = SystemColors.Menu;
            DocumentRoot.Location = new Point(296, 95);
            DocumentRoot.Multiline = true;
            DocumentRoot.Name = "DocumentRoot";
            DocumentRoot.Size = new Size(287, 29);
            DocumentRoot.TabIndex = 2;
            DocumentRoot.Text = "C:/ < tools < www";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(116, 95);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 3;
            label1.Text = "Document Root :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(116, 42);
            label2.Name = "label2";
            label2.Size = new Size(71, 25);
            label2.TabIndex = 6;
            label2.Text = "Name :";
            // 
            // ServerName
            // 
            ServerName.BackColor = Color.FromArgb(11, 7, 17);
            ServerName.BorderStyle = BorderStyle.None;
            ServerName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ServerName.ForeColor = SystemColors.Menu;
            ServerName.Location = new Point(216, 42);
            ServerName.Multiline = true;
            ServerName.Name = "ServerName";
            ServerName.Size = new Size(367, 29);
            ServerName.TabIndex = 5;
            ServerName.Text = "localhost";
            // 
            // startMySQL
            // 
            startMySQL.BackColor = Color.FromArgb(11, 7, 17);
            startMySQL.FlatAppearance.BorderColor = Color.White;
            startMySQL.FlatAppearance.BorderSize = 0;
            startMySQL.FlatAppearance.MouseDownBackColor = Color.FromArgb(11, 7, 17);
            startMySQL.FlatStyle = FlatStyle.Flat;
            startMySQL.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startMySQL.ForeColor = Color.FromArgb(255, 30, 70);
            startMySQL.Location = new Point(210, 331);
            startMySQL.Margin = new Padding(0);
            startMySQL.Name = "startMySQL";
            startMySQL.Size = new Size(95, 39);
            startMySQL.TabIndex = 7;
            startMySQL.Text = "Start";
            startMySQL.UseVisualStyleBackColor = false;
            // 
            // browse
            // 
            browse.BackColor = Color.FromArgb(255, 30, 70);
            browse.FlatAppearance.BorderSize = 0;
            browse.FlatStyle = FlatStyle.Flat;
            browse.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            browse.ForeColor = Color.White;
            browse.Location = new Point(589, 95);
            browse.Name = "browse";
            browse.Size = new Size(84, 29);
            browse.TabIndex = 8;
            browse.Text = "Browse";
            browse.TextAlign = ContentAlignment.TopCenter;
            browse.UseVisualStyleBackColor = false;
            browse.Click += browse_Click;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(255, 30, 70);
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateButton.ForeColor = Color.White;
            updateButton.Location = new Point(589, 42);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(84, 29);
            updateButton.TabIndex = 9;
            updateButton.Text = "Update";
            updateButton.TextAlign = ContentAlignment.TopCenter;
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(225, 282);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 10;
            label3.Text = "MySQL";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(480, 282);
            label4.Name = "label4";
            label4.Size = new Size(75, 25);
            label4.TabIndex = 11;
            label4.Text = "Apache";
            // 
            // startApache
            // 
            startApache.BackColor = Color.FromArgb(11, 7, 17);
            startApache.FlatAppearance.BorderColor = Color.White;
            startApache.FlatAppearance.BorderSize = 0;
            startApache.FlatAppearance.MouseDownBackColor = Color.FromArgb(11, 7, 17);
            startApache.FlatStyle = FlatStyle.Flat;
            startApache.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startApache.ForeColor = Color.FromArgb(255, 30, 70);
            startApache.Location = new Point(470, 331);
            startApache.Margin = new Padding(0);
            startApache.Name = "startApache";
            startApache.Size = new Size(95, 39);
            startApache.TabIndex = 12;
            startApache.Text = "Start";
            startApache.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(750, 455);
            Controls.Add(startApache);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(updateButton);
            Controls.Add(browse);
            Controls.Add(startMySQL);
            Controls.Add(label2);
            Controls.Add(ServerName);
            Controls.Add(label1);
            Controls.Add(DocumentRoot);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Home";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private FolderBrowserDialog folderBrowserDialog1;
        private TextBox DocumentRoot;
        private Label label1;
        private Label label2;
        private TextBox ServerName;
        private Button startMySQL;
        private Button browse;
        private Button updateButton;
        private Label label3;
        private Label label4;
        private Button startApache;
    }
}