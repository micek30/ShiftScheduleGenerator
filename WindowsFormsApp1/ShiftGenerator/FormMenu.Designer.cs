﻿namespace ShiftGenerator
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnUsersPnl = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnUsersPnl
            // 
            this.btnUsersPnl.Location = new System.Drawing.Point(36, 26);
            this.btnUsersPnl.Name = "btnUsersPnl";
            this.btnUsersPnl.Size = new System.Drawing.Size(283, 43);
            this.btnUsersPnl.TabIndex = 1;
            this.btnUsersPnl.Text = "Users Panel";
            this.btnUsersPnl.UseVisualStyleBackColor = true;
            this.btnUsersPnl.Click += new System.EventHandler(this.btnUsersPnl_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(283, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Law Requirements";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(283, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Employee Requirements";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(36, 208);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(283, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "Schedules";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 280);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUsersPnl);
            this.Name = "FormMain";
            this.Text = "Shift schedule generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnUsersPnl;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
