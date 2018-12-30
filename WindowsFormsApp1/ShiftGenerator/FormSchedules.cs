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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ShiftGenerator
{
    public partial class FormSchedules : Form
    {
        Month month;

        public FormSchedules()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            labelMsg.Visible = true;
            labelMsg.Enabled = true;
            labelMsg.Text = "Generating....";

            //creating month
            month = new Month(1, 2019);

            //filling FTE's for choosen month
            month.fillFTE();

            //filling month with shifts
            month.fillShifts();

            //creating excel
            createExcel(month);


            this.ActiveControl = dataGridView1;
            int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            showEmp(count);

            labelMsg.Text = "Finished !!";
        }

        private void showEmp(int count)
        {
            //do testowania
            dataGridView1.DataSource = month.Shifts[count].EmployeesChoosen;
            /////

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void createExcel(Month month)
        {
            ////////////////  creating excell
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Employee emp = new Employee();
            List<Employee> allEmp = emp.getAllEmployee();

            xlWorkSheet.Cells[2, 1] = "Channels";
            xlWorkSheet.Cells[2, 2] = "French";
            xlWorkSheet.Cells[2, 3] = "Independent";

            //fill names, surnames, french level and independency
            for (int i = 0; i < allEmp.Count(); i++)
            {
                xlWorkSheet.Cells[i + 3, 1] = allEmp[i].name + " " + allEmp[i].surname;
                xlWorkSheet.Cells[i + 3, 2] = allEmp[i].frenchlvl;
                xlWorkSheet.Cells[i + 3, 3] = allEmp[i].independent.Value.ToString();
            }
            //fill dates
            /////////////////////////////////////////////////////////////////////////////////////////////////
            int shiftCounter = 0;
            for (int i = 0; i < month.LastDay.Day; i++)
            {

                xlWorkSheet.Cells[1, i + 4] = month.FirstDay.AddDays(i).DayOfWeek.ToString();
                xlWorkSheet.Cells[2, i + 4] = month.FirstDay.AddDays(i).Day.ToString();
                for (int j = 0; j < allEmp.Count(); j++)
                {
                    if (month.Shifts[shiftCounter].EmployeesChoosen.Any(x => x.idEmployee == allEmp[j].idEmployee))
                    {
                        xlWorkSheet.Cells[j + 3, i + 4] = "D";
                    }
                    else if (month.Shifts[shiftCounter + 1].EmployeesChoosen.Any(x => x.idEmployee == allEmp[j].idEmployee))
                    {
                        xlWorkSheet.Cells[j + 3, i + 4] = "N";
                    }


                }
                shiftCounter += 2;
            }

            xlWorkBook.SaveAs("c:\\ShiftSchedule_" + month.MonthNum.ToString() + ".xlsx", Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file C:\\ShiftSchedule_" + month.MonthNum.ToString() + ".xlsx");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            showEmp(count);
        }
    }
}