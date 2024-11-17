namespace Demo
{
    partial class frmLogin
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
            this.login1 = new Login2.Login();
            this.SuspendLayout();
            // 
            // login1
            // 
            this.login1.Location = new System.Drawing.Point(17, 9);
            this.login1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.login1.Name = "login1";
            this.login1.Password = "";
            this.login1.Size = new System.Drawing.Size(449, 175);
            this.login1.TabIndex = 0;
            this.login1.UserName = "";
            this.login1.SubmitClicked += new Login2.Login.SubmitClickedHandler(this.login1_SubmitClicked);
            this.login1.CancelClicked += new Login2.Login.CancelClickedHander(this.login1_CancelClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 194);
            this.Controls.Add(this.login1);
            this.Name = "frmLogin";
            this.ResumeLayout(false);

        }

        #endregion

        private Login2.Login login1;
    }
}