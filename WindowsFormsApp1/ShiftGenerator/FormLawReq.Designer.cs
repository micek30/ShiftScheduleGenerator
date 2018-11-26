namespace ShiftGenerator
{
    partial class FormLawReq
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
            this.comboBoxLaws = new System.Windows.Forms.ComboBox();
            this.labelLaw = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxLaws
            // 
            this.comboBoxLaws.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxLaws.FormattingEnabled = true;
            this.comboBoxLaws.Location = new System.Drawing.Point(32, 31);
            this.comboBoxLaws.Name = "comboBoxLaws";
            this.comboBoxLaws.Size = new System.Drawing.Size(358, 30);
            this.comboBoxLaws.TabIndex = 0;
            this.comboBoxLaws.SelectedIndexChanged += new System.EventHandler(this.comboBoxLaws_SelectedIndexChanged);
            // 
            // labelLaw
            // 
            this.labelLaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelLaw.Location = new System.Drawing.Point(29, 81);
            this.labelLaw.Name = "labelLaw";
            this.labelLaw.Size = new System.Drawing.Size(808, 401);
            this.labelLaw.TabIndex = 0;
            // 
            // FormLawReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 516);
            this.Controls.Add(this.comboBoxLaws);
            this.Controls.Add(this.labelLaw);
            this.Name = "FormLawReq";
            this.Text = "FormLawReq";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLaws;
        private System.Windows.Forms.Label labelLaw;
    }
}