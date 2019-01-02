namespace ShiftGenerator
{
    partial class FormMenu
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
            this.btnUsersPnl = new System.Windows.Forms.Button();
            this.btnLawRequirements = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSchedules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsersPnl
            // 
            this.btnUsersPnl.Location = new System.Drawing.Point(48, 32);
            this.btnUsersPnl.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsersPnl.Name = "btnUsersPnl";
            this.btnUsersPnl.Size = new System.Drawing.Size(377, 53);
            this.btnUsersPnl.TabIndex = 1;
            this.btnUsersPnl.Text = "Users Panel";
            this.btnUsersPnl.UseVisualStyleBackColor = true;
            this.btnUsersPnl.Click += new System.EventHandler(this.btnUsersPnl_Click);
            // 
            // btnLawRequirements
            // 
            this.btnLawRequirements.Location = new System.Drawing.Point(48, 103);
            this.btnLawRequirements.Margin = new System.Windows.Forms.Padding(4);
            this.btnLawRequirements.Name = "btnLawRequirements";
            this.btnLawRequirements.Size = new System.Drawing.Size(377, 53);
            this.btnLawRequirements.TabIndex = 2;
            this.btnLawRequirements.Text = "Law Requirements";
            this.btnLawRequirements.UseVisualStyleBackColor = true;
            this.btnLawRequirements.Click += new System.EventHandler(this.btnLawRequirements_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(48, 176);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(377, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "Employee Requirements";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnSchedules
            // 
            this.btnSchedules.Location = new System.Drawing.Point(48, 256);
            this.btnSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.btnSchedules.Name = "btnSchedules";
            this.btnSchedules.Size = new System.Drawing.Size(377, 49);
            this.btnSchedules.TabIndex = 4;
            this.btnSchedules.Text = "Schedules";
            this.btnSchedules.UseVisualStyleBackColor = true;
            this.btnSchedules.Click += new System.EventHandler(this.btnSchedules_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 345);
            this.Controls.Add(this.btnSchedules);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnLawRequirements);
            this.Controls.Add(this.btnUsersPnl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(487, 392);
            this.MinimumSize = new System.Drawing.Size(487, 392);
            this.Name = "FormMenu";
            this.Text = "Shift schedule generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUsersPnl;
        private System.Windows.Forms.Button btnLawRequirements;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSchedules;
    }
}

