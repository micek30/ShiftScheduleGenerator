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
        private bool admin;
        public User user = new User();
        public bool Admin { get => admin; set => admin = value; }


        public FormMenu( User user)
        {
            InitializeComponent();
            this.user = user;
            if (user.permission.Equals("admin"))
            {
                admin = true;
            }
            else
            {
                btnSchedules.Enabled = false;
                btnSchedules.Visible = false;
            }
        }

        private void btnUsersPnl_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                FormUsers formUsers = new FormUsers();
                formUsers.Show();
            }
            else
            {
                FormGuestUsrPnl formGuestUsrPnl = new FormGuestUsrPnl(this.user);
                formGuestUsrPnl.Show();
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            FormEmpReqAdm formEmpReqAdm = new FormEmpReqAdm(user);
            formEmpReqAdm.Show();
        }
    }
}
 