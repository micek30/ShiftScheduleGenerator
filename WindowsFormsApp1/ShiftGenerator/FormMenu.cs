using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace ShiftGenerator
{
    public partial class FormMenu : Form
    {
        private FormLogin formLogin;
        private bool admin;
        public User user = new User();
        DataClasses1DataContext data;
        public bool Admin { get => admin; set => admin = value; }


        public FormMenu(FormLogin formLogin, User user)
        {
            InitializeComponent();
            this.user = user;
            //if (user.permission.Equals("admin")) admin = true;
            if (user.permission.Equals("admin"))
            {
                admin = true;
            }
            else
            {
                btnSchedules.Enabled = false;
                btnSchedules.Visible = false;
            }


            data = new DataClasses1DataContext();
            this.formLogin = formLogin;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUsersPnl_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                FormUsers formUsers = new FormUsers(this);
                formUsers.Show();
            }
            else
            {
                FormGuestUsrPnl formGuestUsrPnl = new FormGuestUsrPnl(this,this.user);
                formGuestUsrPnl.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void btnLawRequirements_Click(object sender, EventArgs e)
        {
            FormLawReq formLawReq = new FormLawReq(this);
            formLawReq.Show();
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            FormSchedules formSchedules = new FormSchedules();
            formSchedules.Show();
        }

        //protected override void OnFormClosing(FormClosingEventArgs e)
        //{
        //    base.OnFormClosing(e);

        //    if (e.CloseReason == CloseReason.WindowsShutDown) return;

        //    e.Cancel = true;
        //    formLogin.Show();
        //    this.Hide();
        //}
    }
}
 