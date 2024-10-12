namespace MyAMP
{
    partial class Subscription
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
            txtCardNumber = new TextBox();
            txtExpMonth = new TextBox();
            txtExpYear = new TextBox();
            txtCVC = new TextBox();
            buttonSubmitPayment = new Button();
            SuspendLayout();
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(52, 109);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(100, 23);
            txtCardNumber.TabIndex = 0;
            // 
            // txtExpMonth
            // 
            txtExpMonth.Location = new Point(219, 109);
            txtExpMonth.Name = "txtExpMonth";
            txtExpMonth.Size = new Size(100, 23);
            txtExpMonth.TabIndex = 1;
            // 
            // txtExpYear
            // 
            txtExpYear.Location = new Point(374, 109);
            txtExpYear.Name = "txtExpYear";
            txtExpYear.Size = new Size(100, 23);
            txtExpYear.TabIndex = 2;
            // 
            // txtCVC
            // 
            txtCVC.Location = new Point(542, 109);
            txtCVC.Name = "txtCVC";
            txtCVC.Size = new Size(100, 23);
            txtCVC.TabIndex = 3;
            // 
            // buttonSubmitPayment
            // 
            buttonSubmitPayment.Location = new Point(362, 214);
            buttonSubmitPayment.Name = "buttonSubmitPayment";
            buttonSubmitPayment.Size = new Size(75, 23);
            buttonSubmitPayment.TabIndex = 4;
            buttonSubmitPayment.Text = "button1";
            buttonSubmitPayment.UseVisualStyleBackColor = true;
            buttonSubmitPayment.Click += buttonSubmitPayment_Click_1;
            // 
            // Subscription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 30, 45);
            ClientSize = new Size(766, 494);
            Controls.Add(buttonSubmitPayment);
            Controls.Add(txtCVC);
            Controls.Add(txtExpYear);
            Controls.Add(txtExpMonth);
            Controls.Add(txtCardNumber);
            Name = "Subscription";
            Text = "Subscription";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private TextBox txtCardNumber;
        private TextBox txtExpMonth;
        private TextBox txtExpYear;
        private TextBox txtCVC;
        private Button buttonSubmitPayment;
    }
}