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
    public partial class FormEmpReqAdm : Form
    {
        User user = new User();
        Employee employee = new Employee();
        DataClasses1DataContext data = new DataClasses1DataContext();
        public FormEmpReqAdm(User user)
        {
            InitializeComponent();
            this.ActiveControl = dataGridViewReq;
            this.user = user;

            employee= data.Employees.SingleOrDefault(x => x.idUser == user.idUser);

            //update DataGridView
            AdminGuestLoad();

            Dictionary<string, string> dayNight = new Dictionary<string, string>();
            dayNight.Add("D", "D");
            dayNight.Add("N", "N");
            comboBoxDN.DataSource = new BindingSource(dayNight, null);
            comboBoxDN.DisplayMember = "Value";
            comboBoxDN.ValueMember = "Key";
        }

        private void loadEmpRequirements(String param)
        {
            try
            {
                if (param.Equals("all"))
                {
                    var result = from employees in data.Employees
                                 join requirements in data.EmpRequirements on employees.idEmployee equals requirements.idEmployee
                                 select new { employees.idEmployee, employees.name, employees.surname, requirements.dateReq, requirements.dayNight, requirements.idEmpRequirements };
                    dataGridViewReq.DataSource = result;
                }
                else
                {
                    var result = from employees in data.Employees
                                 join requirements in data.EmpRequirements on employees.idEmployee equals requirements.idEmployee
                                 join users in data.Users on employees.idUser equals users.idUser
                                 where employees.idUser == user.idUser
                                 select new {employees.idEmployee, employees.name, employees.surname, requirements.dateReq, requirements.dayNight, requirements.idEmpRequirements};
                    dataGridViewReq.DataSource = result;
                }

                for (int i = 0; i < dataGridViewReq.Columns.Count; i++)
                {
                    dataGridViewReq.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                this.Close();
                Console.Write(ex);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            loadEmpRequirements("mine");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //creating Requirements
            EmpRequirement empRequirement = new EmpRequirement();
            empRequirement.reqDesc = richTextBoxDesc.Text;
 //////////////TODO usunąć kolumnę fulfilled
            empRequirement.fulfilled = true;
            empRequirement.Employee = this.employee;
            //creating Datetime
            DateTime date = new DateTime((int)numericUpDownYear.Value, (int)numericUpDownMonth.Value, (int)numericUpDownDay.Value);
            empRequirement.dateReq = date;
            //comboBox Day/Night
            string comboBoxDNValue = ((KeyValuePair<string, string>)comboBoxDN.SelectedItem).Value;
            empRequirement.dayNight = comboBoxDNValue;

            data.EmpRequirements.InsertOnSubmit(empRequirement);
            try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }
            
            //update DataGridView
            AdminGuestLoad();
        }

        private void richTextBoxDesc_Enter(object sender, EventArgs e)
        {
            richTextBoxDesc.Clear();
            richTextBoxDesc.ForeColor = SystemColors.WindowText;
        }
        private void AdminGuestLoad()
        {
            //Showing updated requirements
            if (user.permission.Equals("admin"))
            {
                loadEmpRequirements("all");
                buttonShow.Visible = true;
            }
            else loadEmpRequirements("mine");
        }
        private int getSelectedIdx(DataGridView dataGridView, String columnName)
        {
            int idx = dataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataGridView.Rows[idx];

            int selected = Convert.ToInt32(selectedRow.Cells[columnName].Value);

            return selected;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int selected = getSelectedIdx(dataGridViewReq, "idEmpRequirements");

            var result = (from requirements in data.EmpRequirements
                          where requirements.idEmpRequirements == selected
                          select requirements).First();

            data.EmpRequirements.DeleteOnSubmit(result);
            try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }
            //update DataGridView
            AdminGuestLoad();
        }
    }
}
