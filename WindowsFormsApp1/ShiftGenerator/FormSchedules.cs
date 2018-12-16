using OfficeOpenXml;
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

namespace ShiftGenerator
{
    public partial class FormSchedules : Form
    {
        Shift shift;
        Month month;

        public FormSchedules()
        {
            InitializeComponent();
            this.ActiveControl = dataGridView1;


            //shift = new Shift(date, "D");
            //shift.chooseEmp();
            //dataGridView1.DataSource = month.Shifts[3].EmployeesChoosen;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            labelMsg.Visible = true;
            labelMsg.Enabled= true;
            labelMsg.Text = "Generating....";
            month = new Month(1, 2019);
            month.fillShifts();
            labelMsg.Text = "Finished !!";
        }

        private void chooseEmployees(Shift shift, String shiftTime)
        {
           
        }

        private void createExcell()
        {
            ////////////////  tworzenie excella

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");



                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];

                List<string[]> headerRow = new List<string[]>()
                    {
                      new string[] { "ID", "First Name", "Last Name", "DOB" }
                    };

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

                FileInfo excelFile = new FileInfo(@"C:\ShiftSchedule.xlsx");
                excel.SaveAs(excelFile);
            }
        }

    }
}

