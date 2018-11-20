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
        private bool admin, loggedin;
        DataClasses1DataContext data;
        public bool Loggedin { get => loggedin; set => loggedin = value; }
        public bool Admin { get => admin; set => admin = value; }


        public FormMenu()
        {
            InitializeComponent();
        }

        public FormMenu(FormLogin formLogin)
        {
            InitializeComponent();
            data = new DataClasses1DataContext();
            this.formLogin = formLogin;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUsersPnl_Click(object sender, EventArgs e)
        {
            FormUsers formUsers = new FormUsers(this);
            formUsers.Show();
            //this.Hide();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                excel.Workbook.Worksheets.Add("Worksheet2");
                excel.Workbook.Worksheets.Add("Worksheet3");



                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];

                List<string[]> headerRow = new List<string[]>()
                    {
                      new string[] { "ID", "First Name", "Last Name", "DOB" }
                    };

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FileInfo excelFile = new FileInfo(@"C:\test.xlsx");
                excel.SaveAs(excelFile);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            e.Cancel = true;
            formLogin.Show();
            this.Hide();
        }
    }
}
 