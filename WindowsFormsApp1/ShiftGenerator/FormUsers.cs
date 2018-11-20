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
        public Employee toUpdateEmployee;
        public User toUpdateUser;
        public FormUsers(FormMenu form)
        {

            
                InitializeComponent();
                this.formHandler = form;
                data = new DataClasses1DataContext();
                loadEmployees();

     //       this.textBoxName.Leave += new System.EventHandler(this.textBoxName_Leave);
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxSurname.Enter += new System.EventHandler(this.textBoxSurname_Enter);
            this.textBoxLogin.Enter += new System.EventHandler(this.textBoxLogin_Enter);
            this.textBoxPassword.Enter += new System.EventHandler(this.textBoxPassword_Enter);

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
            if(textBoxName.Text != "Name"&& textBoxSurname.Text != "Surname"&&textBoxLogin.Text != "Login"&& textBoxPassword.Text != "Password") {
                //ComboBoxJobContract
                string comboContractVal = ((KeyValuePair<string, string>)comboBoxContract.SelectedItem).Value;
                //ComboBoxFrenchLevel
                string comboFrenchVal = ((KeyValuePair<string, string>)comboBoxFrenchLvl.SelectedItem).Value;
                //ComboBoxPermission
                string comboPermVal = ((KeyValuePair<string, string>)comboBoxPermission.SelectedItem).Value;
                //ComboBoxPermission
                string comboTeamVal = ((KeyValuePair<string, string>)comboBoxTeam.SelectedItem).Value;

                ////////////////////////////////////////// USER
                User user = new User();
                user.login = textBoxLogin.Text;
                user.password = textBoxSurname.Text;
                user.permission = comboPermVal;

                data.Users.InsertOnSubmit(user);
                try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }

                ///////////////////////////////////////// EMPLOYEE
                Employee employee = new Employee();
                employee.name = textBoxName.Text;
                employee.surname = textBoxPassword.Text;
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
                } else { employee.independent = false; }

                data.Employees.InsertOnSubmit(employee);
                try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }

                loadEmployees();
            }
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
                try
                {
                    //DELETING USER
                    int selected = getSelectedIdx(dataGridViewEmp, "idEmployee");

                    var result = (from users in data.Users
                                  join employee in data.Employees
                                  on users.idUser equals employee.idUser
                                  where employee.idEmployee == selected
                                  select users).First();

                    //int tempUserId = result.idUser;
                    data.Users.DeleteOnSubmit(result);

                    //DELETING EMPLOYEE
                    var result2 = (from employee in data.Employees
                                   where employee.idEmployee == selected
                                   select employee).First();

                    //int tempUserId = result.idUser;
                    data.Employees.DeleteOnSubmit(result2);

                    try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }


                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    //formHandler.lostConnection();
                }

                loadEmployees();
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selected = getSelectedIdx(dataGridViewEmp, "idEmployee");
            toUpdateEmployee = data.Employees.SingleOrDefault(x => x.idEmployee == selected);
            toUpdateUser = data.Users.SingleOrDefault(x => x.idUser == toUpdateEmployee.idUser);

            textBoxName.Text = toUpdateEmployee.name;
            textBoxSurname.Text = toUpdateEmployee.surname;
            textBoxLogin.Text = toUpdateUser.login;
            textBoxPassword.Text = toUpdateUser.password;

            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSave.Visible = true;
            buttonSave.Enabled = true;
            buttonCancel.Visible = true;
            buttonCancel.Enabled = true;

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //ComboBoxJobContract
            string comboContractVal = ((KeyValuePair<string, string>)comboBoxContract.SelectedItem).Value;
            //ComboBoxFrenchLevel
            string comboFrenchVal = ((KeyValuePair<string, string>)comboBoxFrenchLvl.SelectedItem).Value;
            //ComboBoxPermission
            string comboPermVal = ((KeyValuePair<string, string>)comboBoxPermission.SelectedItem).Value;
            //ComboBoxPermission
            string comboTeamVal = ((KeyValuePair<string, string>)comboBoxTeam.SelectedItem).Value;

            //textBoxName.Text = toUpdateEmployee.name;
            //textBoxSurname.Text = toUpdateEmployee.surname;
            //textBoxLogin.Text = toUpdateUser.login;
            //textBoxPassword.Text = toUpdateUser.password;

            toUpdateEmployee.name = textBoxName.Text;
            toUpdateEmployee.surname = textBoxSurname.Text;
            toUpdateUser.login = textBoxLogin.Text;
            toUpdateUser.password = textBoxPassword.Text;
            


            //idTeam
            if (comboTeamVal == "Channels")
            {
                toUpdateEmployee.idTeam = 1;
            }
            else { toUpdateEmployee.idTeam = 2; }

            //independent
            if (checkBoxIndependent.Checked)
            {
                toUpdateEmployee.independent = true;
            }
            else { toUpdateEmployee.independent = false; }

            try { data.SubmitChanges(); } catch (Exception ex) { Console.WriteLine(ex); }

            buttonAdd.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = false;
            buttonSave.Visible = false;

            loadEmployees();

        }

        //private void textBoxName_Leave(object sender, EventArgs e)
        //{
        //    if (textBoxName.Text.Length == 0)
        //    {
        //        textBoxName.Text = "Name";
        //        textBoxName.ForeColor = SystemColors.GrayText;
        //    }
        //}
        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                textBoxName.Clear();
                textBoxName.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Surname")
            {
                textBoxSurname.Clear();
                textBoxSurname.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Login")
            {
                textBoxLogin.Clear();
                textBoxLogin.ForeColor = SystemColors.WindowText;
            }
        }
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Clear();
                textBoxPassword.ForeColor = SystemColors.WindowText;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "Name";
            textBoxSurname.Text = "Surname";
            textBoxLogin.Text = "Login";
            textBoxPassword.Text = "Password";

            buttonAdd.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = false;
            buttonSave.Visible = false;
            buttonCancel.Enabled = false;
            buttonCancel.Visible = false;
        }
    }
}
 