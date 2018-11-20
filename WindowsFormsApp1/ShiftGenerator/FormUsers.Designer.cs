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
            this.dataGridViewEmp = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.comboBoxFrenchLvl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.comboBoxPermission = new System.Windows.Forms.ComboBox();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.checkBoxIndependent = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEmp
            // 
            this.dataGridViewEmp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmp.Location = new System.Drawing.Point(16, 15);
            this.dataGridViewEmp.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewEmp.Name = "dataGridViewEmp";
            this.dataGridViewEmp.Size = new System.Drawing.Size(959, 315);
            this.dataGridViewEmp.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonAdd.Location = new System.Drawing.Point(16, 354);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(111, 40);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add user";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonSave.Location = new System.Drawing.Point(16, 559);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 40);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonDelete.Location = new System.Drawing.Point(16, 492);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(111, 40);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete user";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.buttonEdit.Location = new System.Drawing.Point(16, 423);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(111, 40);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit user";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.AccessibleName = "";
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.textBoxName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxName.Location = new System.Drawing.Point(160, 354);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(209, 32);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.Text = "Name";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.textBoxSurname.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxSurname.Location = new System.Drawing.Point(160, 405);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(209, 32);
            this.textBoxSurname.TabIndex = 7;
            this.textBoxSurname.Text = "Surname";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.textBoxLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxLogin.Location = new System.Drawing.Point(160, 457);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(209, 32);
            this.textBoxLogin.TabIndex = 8;
            this.textBoxLogin.Text = "Login";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxPassword.Location = new System.Drawing.Point(160, 513);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(209, 32);
            this.textBoxPassword.TabIndex = 13;
            this.textBoxPassword.Text = "Password";
            // 
            // comboBoxFrenchLvl
            // 
            this.comboBoxFrenchLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxFrenchLvl.FormattingEnabled = true;
            this.comboBoxFrenchLvl.Location = new System.Drawing.Point(649, 354);
            this.comboBoxFrenchLvl.Name = "comboBoxFrenchLvl";
            this.comboBoxFrenchLvl.Size = new System.Drawing.Size(121, 30);
            this.comboBoxFrenchLvl.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(489, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "French level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(489, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Contract";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(489, 513);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Team";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(489, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "Permission";
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(649, 407);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(121, 30);
            this.comboBoxContract.TabIndex = 21;
            // 
            // comboBoxPermission
            // 
            this.comboBoxPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxPermission.FormattingEnabled = true;
            this.comboBoxPermission.Location = new System.Drawing.Point(649, 454);
            this.comboBoxPermission.Name = "comboBoxPermission";
            this.comboBoxPermission.Size = new System.Drawing.Size(121, 30);
            this.comboBoxPermission.TabIndex = 22;
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(649, 510);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(121, 30);
            this.comboBoxTeam.TabIndex = 23;
            // 
            // checkBoxIndependent
            // 
            this.checkBoxIndependent.AutoSize = true;
            this.checkBoxIndependent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIndependent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.checkBoxIndependent.Location = new System.Drawing.Point(160, 565);
            this.checkBoxIndependent.Name = "checkBoxIndependent";
            this.checkBoxIndependent.Size = new System.Drawing.Size(139, 28);
            this.checkBoxIndependent.TabIndex = 24;
            this.checkBoxIndependent.Text = "Independent";
            this.checkBoxIndependent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIndependent.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(864, 580);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 40);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 641);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxIndependent);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.comboBoxPermission);
            this.Controls.Add(this.comboBoxContract);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFrenchLvl);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridViewEmp);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormUsers";
            this.Text = "FormUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.DataGridView dataGridViewEmp;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.ComboBox comboBoxFrenchLvl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.ComboBox comboBoxPermission;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.CheckBox checkBoxIndependent;
        private System.Windows.Forms.Button buttonCancel;
    }
}