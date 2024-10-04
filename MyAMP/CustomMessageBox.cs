using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyAMP
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string message)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(11, 7, 17);

            Label messageLabel = new Label();
            messageLabel.Text = message;
            messageLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            messageLabel.ForeColor = Color.FromArgb(255, 30, 70);
            messageLabel.AutoSize = true;
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            messageLabel.Location = new Point((this.ClientSize.Width - messageLabel.PreferredWidth) / 2, 30);

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.FlatAppearance.BorderSize = 0;
            okButton.BackColor = Color.FromArgb(255, 30, 70);
            okButton.ForeColor = Color.White;
            okButton.Size = new Size(100, 40);
            okButton.Location = new Point((this.ClientSize.Width - okButton.Width) / 2, 80);
            okButton.Click += (sender, e) => this.Close();

            this.Controls.Add(messageLabel);
            this.Controls.Add(okButton);
            this.ClientSize = new Size(400, 150);
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Paint += CustomMessageBox_Paint;
        }

        private void CustomMessageBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 30, 70), 3), 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
        }
    }
}
