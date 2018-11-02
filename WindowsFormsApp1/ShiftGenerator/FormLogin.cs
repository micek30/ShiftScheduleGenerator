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
        private FormMain formLog;

        public FormLogin()
        {
            InitializeComponent();
            data = new DataClasses1DataContext();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!textBoxLogin.Text.Equals("") || !textBoxPass.Text.Equals(""))
            {
                
                User toUpdateUser = new User
                {
                    login = textBoxLogin.Text,
                    password = textBoxPass.Text
                };
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
                    //else if (PasswordHash.checkPassword(textBoxPass.Text, result.user.pass))
                    else if (textBoxPass.Text.Equals( result.user.password))
                    {

                        labelMsg.Text = "Zalogowano !!!";
                        labelMsg.Visible = true;
                        FormMain formMain = new FormMain();
                        formMain.Show();
                        if (result.user.permission.Equals("admin"))
                        {
                            //formMain.Admin = true;
                        }
                        //formMain.Loggedin = true;
                        //formMain.loadBox();
                        this.Close();
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
    }
}
