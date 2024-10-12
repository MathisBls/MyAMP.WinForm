namespace MyAMP
{
    partial class Logs
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
            logsHistoric = new TextBox();
            saveLogs = new Button();
            SuspendLayout();
            // 
            // logsHistoric
            // 
            logsHistoric.BackColor = Color.FromArgb(11, 7, 17);
            logsHistoric.BorderStyle = BorderStyle.None;
            logsHistoric.Dock = DockStyle.Bottom;
            logsHistoric.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logsHistoric.ForeColor = SystemColors.Menu;
            logsHistoric.Location = new Point(0, 12);
            logsHistoric.Multiline = true;
            logsHistoric.Name = "logsHistoric";
            logsHistoric.ReadOnly = true;
            logsHistoric.Size = new Size(750, 443);
            logsHistoric.TabIndex = 6;
            logsHistoric.Text = "Logs:";
            // 
            // saveLogs
            // 
            saveLogs.BackColor = Color.FromArgb(255, 30, 70);
            saveLogs.FlatAppearance.BorderColor = Color.White;
            saveLogs.FlatAppearance.BorderSize = 0;
            saveLogs.FlatAppearance.MouseDownBackColor = Color.FromArgb(11, 7, 17);
            saveLogs.FlatStyle = FlatStyle.Flat;
            saveLogs.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveLogs.ForeColor = Color.White;
            saveLogs.Location = new Point(9, 9);
            saveLogs.Margin = new Padding(0);
            saveLogs.Name = "saveLogs";
            saveLogs.Size = new Size(150, 35);
            saveLogs.TabIndex = 8;
            saveLogs.Text = "Save Logs";
            saveLogs.UseVisualStyleBackColor = false;
            saveLogs.Click += saveLogs_Click;
            // 
            // Logs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 7, 17);
            ClientSize = new Size(750, 455);
            Controls.Add(saveLogs);
            Controls.Add(logsHistoric);
            Name = "Logs";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox logsHistoric;
        private Button saveLogs;
    }
}