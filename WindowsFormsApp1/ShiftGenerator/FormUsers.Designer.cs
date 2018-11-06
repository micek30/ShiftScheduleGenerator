namespace ShiftGenerator
{
    partial class FormUsers
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
            this.employeesTableAdapter1 = new ShiftGenerator.ShiftScheduleDBDataSetTableAdapters.EmployeesTableAdapter();
            this.dataGridViewEmp = new System.Windows.Forms.DataGridView();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // employeesTableAdapter1
            // 
            this.employeesTableAdapter1.ClearBeforeFill = true;
            // 
            // dataGridViewEmp
            // 
            this.dataGridViewEmp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmp.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewEmp.Name = "dataGridViewEmp";
            this.dataGridViewEmp.Size = new System.Drawing.Size(449, 256);
            this.dataGridViewEmp.TabIndex = 0;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 275);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(449, 234);
            this.dataGridViewUsers.TabIndex = 1;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 521);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.dataGridViewEmp);
            this.Name = "FormUsers";
            this.Text = "FormUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ShiftScheduleDBDataSetTableAdapters.EmployeesTableAdapter employeesTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridViewEmp;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
    }
}