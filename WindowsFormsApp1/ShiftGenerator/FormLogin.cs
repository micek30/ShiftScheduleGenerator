using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftGenerator
{
    public partial class FormLogin : Form
    {
        DataClasses1DataContext data;

        public FormLogin()
        {
            InitializeComponent();
            data = new DataClasses1DataContext();
            this.ActiveControl = buttonLogin;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!textBoxLogin.Text.Equals("") || !textBoxPass.Text.Equals(""))
            {
                try
                {


                    var result = (from user in data.Users
                                  where user.login == textBoxLogin.Text
                                  select new { user }).FirstOrDefault();
                    if (result == null)
                    {
                        labelMsg.Text = "User not found";
                        labelMsg.Visible = true;
                    }
                    else if (PasswordHash.checkPassword(textBoxPass.Text, result.user.password))
                    {

                        labelMsg.Text = "Zalogowano !!!";
                        labelMsg.Visible = true;
                        FormMenu formMain = new FormMenu(result.user);
                        formMain.Show();
                        this.Hide();
                    }
                    else
                    {
                        labelMsg.Text = "Zly login lub haslo !!!";
                        labelMsg.Visible = true;
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show("Connection lost");
                    this.Close();
                }
                catch (Exception ex)
                {
                    labelMsg.Text = "Zly login lub haslo !!!";
                    labelMsg.Visible = true;
                }
            }
            else { MessageBox.Show("Enter login and password"); }
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            textBoxLogin.Clear();
            textBoxLogin.ForeColor = SystemColors.WindowText;
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            textBoxPass.Clear();
            textBoxPass.ForeColor = SystemColors.WindowText;
        }
    }
}
