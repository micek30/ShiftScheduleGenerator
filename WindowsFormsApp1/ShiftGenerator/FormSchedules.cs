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
    public partial class FormSchedules : Form
    {


        public FormSchedules()
        {
            InitializeComponent();
            this.ActiveControl = dataGridView1;
            Shift shift = new Shift();

            DateTime thisDate1 = new DateTime(2018, 12, 12);
            shift.fillShiftEmp(thisDate1,"D");
            dataGridView1.DataSource = shift.EmployeesAvailable;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }


        public void FillMatrix()
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

        }

        private void labelMsg_Click(object sender, EventArgs e)
        {

        }
    }
}

//            using (ExcelPackage excel = new ExcelPackage())
//            {
//                excel.Workbook.Worksheets.Add("Worksheet1");
//                excel.Workbook.Worksheets.Add("Worksheet2");
//                excel.Workbook.Worksheets.Add("Worksheet3");



//                var excelWorksheet = excel.Workbook.Worksheets["Worksheet1"];

//List<string[]> headerRow = new List<string[]>()
//                    {
//                      new string[] { "ID", "First Name", "Last Name", "DOB" }
//                    };

//string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
//excelWorksheet.Cells[headerRange].LoadFromArrays(headerRow);

//FileInfo excelFile = new FileInfo(@"C:\test.xlsx");
//excel.SaveAs(excelFile);
//            }