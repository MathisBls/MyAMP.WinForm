namespace MyAMP
{
    partial class Profile
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
            textBoxUsername = new TextBox();
            textBoxEmail = new TextBox();
            textBoxSubscriptionType = new TextBox();
            buttonSaveChanges = new Button();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(206, 137);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(100, 23);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(206, 205);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // textBoxSubscriptionType
            // 
            textBoxSubscriptionType.Location = new Point(206, 267);
            textBoxSubscriptionType.Name = "textBoxSubscriptionType";
            textBoxSubscriptionType.Size = new Size(100, 23);
            textBoxSubscriptionType.TabIndex = 2;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.Location = new Point(220, 362);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(75, 23);
            buttonSaveChanges.TabIndex = 3;
            buttonSaveChanges.Text = "Submit";
            buttonSaveChanges.UseVisualStyleBackColor = true;
            buttonSaveChanges.Click += buttonSaveChanges_Click_1;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(766, 494);
            Controls.Add(buttonSaveChanges);
            Controls.Add(textBoxSubscriptionType);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxUsername);
            Name = "Profile";
            Text = "Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxEmail;
        private TextBox textBoxSubscriptionType;
        private Button buttonSaveChanges;
    }
}