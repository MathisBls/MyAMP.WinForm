namespace MyAMP
{
    partial class PrefGeneral
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
            saveButton = new Button();
            autoStopApacheCheckBox = new CheckBox();
            autoStartApacheCheckBox = new CheckBox();
            mysqlPortInput = new NumericUpDown();
            apachePortInput = new NumericUpDown();
            autoStopMySQLCheckBox = new CheckBox();
            autoStartMySQLCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)mysqlPortInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)apachePortInput).BeginInit();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(284, 283);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 0;
            saveButton.Text = "button1";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // autoStopApacheCheckBox
            // 
            autoStopApacheCheckBox.AutoSize = true;
            autoStopApacheCheckBox.BackColor = Color.White;
            autoStopApacheCheckBox.FlatStyle = FlatStyle.Popup;
            autoStopApacheCheckBox.Font = new Font("Segoe UI", 12F);
            autoStopApacheCheckBox.Location = new Point(122, 115);
            autoStopApacheCheckBox.Name = "autoStopApacheCheckBox";
            autoStopApacheCheckBox.Size = new Size(207, 25);
            autoStopApacheCheckBox.TabIndex = 1;
            autoStopApacheCheckBox.Text = "autoStopApacheCheckBox";
            autoStopApacheCheckBox.UseVisualStyleBackColor = false;
            // 
            // autoStartApacheCheckBox
            // 
            autoStartApacheCheckBox.AutoSize = true;
            autoStartApacheCheckBox.FlatStyle = FlatStyle.Popup;
            autoStartApacheCheckBox.Font = new Font("Segoe UI", 12F);
            autoStartApacheCheckBox.Location = new Point(261, 63);
            autoStartApacheCheckBox.Name = "autoStartApacheCheckBox";
            autoStartApacheCheckBox.Size = new Size(208, 25);
            autoStartApacheCheckBox.TabIndex = 2;
            autoStartApacheCheckBox.Text = "autoStartApacheCheckBox";
            autoStartApacheCheckBox.UseVisualStyleBackColor = true;
            // 
            // mysqlPortInput
            // 
            mysqlPortInput.Location = new Point(261, 215);
            mysqlPortInput.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            mysqlPortInput.Name = "mysqlPortInput";
            mysqlPortInput.Size = new Size(120, 23);
            mysqlPortInput.TabIndex = 3;
            // 
            // apachePortInput
            // 
            apachePortInput.Location = new Point(261, 169);
            apachePortInput.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            apachePortInput.Name = "apachePortInput";
            apachePortInput.Size = new Size(120, 23);
            apachePortInput.TabIndex = 4;
            // 
            // autoStopMySQLCheckBox
            // 
            autoStopMySQLCheckBox.AutoSize = true;
            autoStopMySQLCheckBox.FlatStyle = FlatStyle.Popup;
            autoStopMySQLCheckBox.Font = new Font("Segoe UI", 12F);
            autoStopMySQLCheckBox.Location = new Point(469, 115);
            autoStopMySQLCheckBox.Name = "autoStopMySQLCheckBox";
            autoStopMySQLCheckBox.Size = new Size(206, 25);
            autoStopMySQLCheckBox.TabIndex = 5;
            autoStopMySQLCheckBox.Text = "autoStopMySQLCheckBox";
            autoStopMySQLCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoStartMySQLCheckBox
            // 
            autoStartMySQLCheckBox.AutoSize = true;
            autoStartMySQLCheckBox.FlatStyle = FlatStyle.Popup;
            autoStartMySQLCheckBox.Font = new Font("Segoe UI", 12F);
            autoStartMySQLCheckBox.Location = new Point(469, 63);
            autoStartMySQLCheckBox.Name = "autoStartMySQLCheckBox";
            autoStartMySQLCheckBox.Size = new Size(207, 25);
            autoStartMySQLCheckBox.TabIndex = 6;
            autoStartMySQLCheckBox.Text = "autoStartMySQLCheckBox";
            autoStartMySQLCheckBox.UseVisualStyleBackColor = true;
            // 
            // PrefGeneral
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(734, 404);
            Controls.Add(autoStartMySQLCheckBox);
            Controls.Add(autoStopMySQLCheckBox);
            Controls.Add(apachePortInput);
            Controls.Add(mysqlPortInput);
            Controls.Add(autoStartApacheCheckBox);
            Controls.Add(autoStopApacheCheckBox);
            Controls.Add(saveButton);
            Name = "PrefGeneral";
            Text = "PrefGeneral";
            ((System.ComponentModel.ISupportInitialize)mysqlPortInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)apachePortInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private CheckBox autoStopApacheCheckBox;
        private CheckBox autoStartApacheCheckBox;
        private NumericUpDown mysqlPortInput;
        private NumericUpDown apachePortInput;
        private CheckBox autoStopMySQLCheckBox;
        private CheckBox autoStartMySQLCheckBox;
    }
}