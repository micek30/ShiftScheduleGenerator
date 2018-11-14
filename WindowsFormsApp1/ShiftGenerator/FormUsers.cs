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
    public partial class FormUsers : Form
    {
        DataClasses1DataContext data;
        FormMenu formHandler;
        public FormUsers(FormMenu form)
        {

            
                InitializeComponent();
                this.formHandler = form;
                data = new DataClasses1DataContext();
                loadEmployees();

            //ADDING VALUES TO COMBOBOXES
            //JOB CONTRACTS
            Dictionary<string, string> jobContracts = new Dictionary<string, string>();
            jobContracts.Add("Employee", "Employee");
            jobContracts.Add("Contractor", "Contractor");
            comboBoxContract.DataSource = new BindingSource(jobContracts, null);
            comboBoxContract.DisplayMember = "Value";
            comboBoxContract.ValueMember = "Key"; 
            //LANGUAGE LEVEL
            Dictionary<string, string> languageLvl = new Dictionary<string, string>();
            languageLvl.Add("A0", "A0");
            languageLvl.Add("A1", "A1");
            languageLvl.Add("A2", "A2");
            languageLvl.Add("B1", "B1");
            languageLvl.Add("B2", "B2");
            languageLvl.Add("C1", "C1");
            languageLvl.Add("C2", "C2");
            comboBoxFrenchLvl.DataSource = new BindingSource(languageLvl, null);
            comboBoxFrenchLvl.DisplayMember = "Value";
            comboBoxFrenchLvl.ValueMember = "Key";
            //PERMISSION
            Dictionary<string, string> perms = new Dictionary<string, string>();
            perms.Add("admin", "admin");
            perms.Add("guest", "guest");
            comboBoxPermission.DataSource = new BindingSource(perms, null);
            comboBoxPermission.DisplayMember = "Value";
            comboBoxPermission.ValueMember = "Key";
            //TEAM
            Dictionary<string, string> team = new Dictionary<string, string>();
            team.Add("Mainframe", "Mainframe");
            team.Add("Channels", "Channels");
            comboBoxTeam.DataSource = new BindingSource(team, null);
            comboBoxTeam.DisplayMember = "Value";
            comboBoxTeam.ValueMember = "Key";


        }
        private void loadEmployees()
        {
            try
            {
                var result = from employees in data.Employees
                             join users in data.Users on employees.idUser equals users.idUser
                             join team in data.Teams on employees.idTeam equals team.idTeam
                             select new {employees.idEmployee, users.login, employees.name, employees.surname, employees.jobContract, team.nameTeam, employees.independent, employees.frenchlvl, users.password,users.permission};

                dataGridViewEmp.DataSource = result;

                for (int i = 0; i < dataGridViewEmp.Columns.Count; i++)
                {
                    dataGridViewEmp.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                this.Close();
                Console.Write(ex);
                //formHandler.lostConnection();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //ComboBoxJobContract
            string comboContractVal = ((KeyValuePair<string, string>)comboBoxContract.SelectedItem).Value;
            //ComboBoxFrenchLevel
            string comboFrenchVal = ((KeyValuePair<string, string>)comboBoxFrenchLvl.SelectedItem).Value;
            //ComboBoxPermission
            string comboPermVal = ((KeyValuePair<string, string>)comboBoxPermission.SelectedItem).Value;
            //ComboBoxPermission
            string comboTeamVal = ((KeyValuePair<string, string>)comboBoxTeam.SelectedItem).Value;

            if (!textBoxName.Equals("") && !textBoxSurname.Equals("") && !textBoxLogin.Equals("") && !textBoxPassword.Equals(""))
            {


                ////////////////////////////////////////// USER
                User user = new User();
                user.login = textBoxLogin.Text;
                user.password = textBoxPassword.Text;
                user.permission = comboPermVal;

                data.Users.InsertOnSubmit(user);
                try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }

                ///////////////////////////////////////// EMPLOYEE
                Employee employee = new Employee();
                employee.name = textBoxName.Text;
                employee.surname = textBoxSurname.Text;
                employee.jobContract = comboContractVal;
                employee.frenchlvl = comboFrenchVal;
                //idTeam
                if (comboTeamVal == "Channels")
                {
                    employee.idTeam = 1;
                }
                else { employee.idTeam = 2; }
                //idUser
                var newUserId = (from users in data.Users
                                 orderby users.idUser descending
                                 select users.idUser).First();
                employee.idUser = newUserId;
                //independent
                if (checkBoxIndependent.Checked)
                {
                    employee.independent = true;
                }
                else { employee.independent = false; }

                data.Employees.InsertOnSubmit(employee);
                try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }
            }
            loadEmployees();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var result = (from users in data.Users
                         orderby users.idUser descending
                         select users.idUser).First();
            int ajdi = result;

            textBoxSurname.Text = ajdi.ToString();

        }
    }
}
 