namespace ShiftGenerator
{
    partial class FormLogin
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
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxLogin.Location = new System.Drawing.Point(43, 46);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(207, 20);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.Text = "Login...";
            // 
            // textBoxPass
            // 
            this.textBoxPass.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxPass.Location = new System.Drawing.Point(43, 96);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(207, 20);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.Text = "Password...";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(89, 143);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(117, 42);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Log in";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Location = new System.Drawing.Point(130, 188);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(35, 13);
            this.labelMsg.TabIndex = 3;
            this.labelMsg.Text = "label1";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 230);
            this.Controls.Add(this.labelMsg);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxLogin);
            this.Name = "FormLogin";
            this.Text = "Shift schedule generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelMsg;
    }
}