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
        public FTE toUpdateFTE;
        public FormUsers(FormMenu form)
        {
            InitializeComponent();
            this.ActiveControl = dataGridViewEmp;
            this.formHandler = form;
                data = new DataClasses1DataContext();
                loadEmployees();

            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxSurname.Enter += new System.EventHandler(this.textBoxSurname_Enter);
            this.textBoxLogin.Enter += new System.EventHandler(this.textBoxLogin_Enter);

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
            //FTE
            Dictionary<string, string> fte = new Dictionary<string, string>();
            fte.Add("1", "1");
            fte.Add("0.8", "0.8");
            fte.Add("0.6", "0.6");
            comboBoxFTE.DataSource = new BindingSource(fte, null);
            comboBoxFTE.DisplayMember = "Value";
            comboBoxFTE.ValueMember = "Key";

        }
        private void loadEmployees()
        {
            try
            {
                var result = from employees in data.Employees
                             join users in data.Users on employees.idUser equals users.idUser
                             join team in data.Teams on employees.idTeam equals team.idTeam
                             join fte in data.FTEs on employees.idEmployee equals fte.idEmployee
                             select new {employees.idEmployee, users.login, employees.name, employees.surname, employees.jobContract, team.nameTeam, employees.independent, employees.frenchlvl, users.permission, fte.dimension};

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
            }
        }


        //////////////////////////////////
        //////////////////////////////////                  ADDING EMPLOYEES
        //////////////////////////////////

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text != "Name"&& textBoxSurname.Text != "Surname"&&textBoxLogin.Text != "Login") {
                //ComboBoxJobContract
                string comboContractVal = ((KeyValuePair<string, string>)comboBoxContract.SelectedItem).Value;
                //ComboBoxFrenchLevel
                string comboFrenchVal = ((KeyValuePair<string, string>)comboBoxFrenchLvl.SelectedItem).Value;
                //ComboBoxPermission
                string comboPermVal = ((KeyValuePair<string, string>)comboBoxPermission.SelectedItem).Value;
                //ComboBoxPermission
                string comboTeamVal = ((KeyValuePair<string, string>)comboBoxTeam.SelectedItem).Value;
                //ComboBoxFTE
                string comboFTE = ((KeyValuePair<string, string>)comboBoxFTE.SelectedItem).Value;

                ////////////////////////////////////////// USER
                User user = new User();
                user.login = textBoxLogin.Text;
                user.password = PasswordHash.getHash("test");
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
                } else { employee.independent = false; }

                data.Employees.InsertOnSubmit(employee);
                try { data.SubmitChanges(); } catch (System.Data.SqlClient.SqlException ex) { Console.WriteLine(ex); }

                /////////////////////////////////     FTE

                FTE newFte = new FTE();

                ///// idEmployee
                var FTEEmp = (from emp in data.Employees
                                 orderby emp.idEmployee descending
                                 select emp.idEmployee).First();
                newFte.idEmployee = FTEEmp;

                /////// dimension
                if (comboFTE == "1")
                {
                    newFte.dimension = 1;
                }
                else if (comboFTE == "0.8")
                {
                    newFte.dimension = 0.8;
                }else if (comboFTE == "0.6")
                {
                    newFte.dimension = 0.6;
                }
                data.FTEs.InsertOnSubmit(newFte);
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

        ///////////////////////////
        ///////////////////////////          DELETING EMPLOYEES
        ///////////////////////////


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

                    data.Users.DeleteOnSubmit(result);

                //DELETING FTE
                var result1 = (from fte in data.FTEs
                               where fte.idEmployee == selected
                               select fte).First();

                data.FTEs.DeleteOnSubmit(result1);

                //DELETING EMPLOYEE
                var result2 = (from employee in data.Employees
                                   where employee.idEmployee == selected
                                   select employee).First();

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

        ///////////////////////////
        ///////////////////////////         EDITING EMPLOYEES
        ///////////////////////////


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int selected = getSelectedIdx(dataGridViewEmp, "idEmployee");
            toUpdateEmployee = data.Employees.SingleOrDefault(x => x.idEmployee == selected);
            toUpdateUser = data.Users.SingleOrDefault(x => x.idUser == toUpdateEmployee.idUser);
            toUpdateFTE = data.FTEs.SingleOrDefault(x => x.idEmployee == selected);

            textBoxName.Text = toUpdateEmployee.name;
            textBoxSurname.Text = toUpdateEmployee.surname;
            textBoxLogin.Text = toUpdateUser.login;

                    
            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            buttonDelete.Enabled = false;
            buttonSave.Visible = true;
            buttonSave.Enabled = true;
            buttonCancel.Visible = true;
            buttonCancel.Enabled = true;
            buttonReset.Visible = true;
            buttonReset.Enabled = true;

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
            //ComboBoxFTE
            string comboFTE = ((KeyValuePair<string, string>)comboBoxFTE.SelectedItem).Value;


            ///////////////////////////////// USER
            toUpdateUser.login = textBoxLogin.Text;

            
            /////////////////////////////////     FTE
            /////// dimension
            if (comboFTE == "1")
            {
                toUpdateFTE.dimension = 1;
            }
            else if (comboFTE == "0.8")
            {
                toUpdateFTE.dimension = 0.8;
            }
            else if (comboFTE == "0.6")
            {
                toUpdateFTE.dimension = 0.6;
            }



            ///////////////////////////////// EMPLOYEE
            toUpdateEmployee.name = textBoxName.Text;
            toUpdateEmployee.surname = textBoxSurname.Text;
            toUpdateEmployee.jobContract = comboContractVal;
            toUpdateEmployee.frenchlvl = comboFrenchVal;

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
            buttonCancel.Enabled = false;
            buttonCancel.Visible = false;
            buttonReset.Visible = false;
            buttonReset.Enabled = false;
            labelReset.Text = "";

            loadEmployees();

        }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "Name";
            textBoxSurname.Text = "Surname";
            textBoxLogin.Text = "Login";

            buttonAdd.Enabled = true;
            buttonEdit.Enabled = true;
            buttonDelete.Enabled = true;
            buttonSave.Enabled = false;
            buttonSave.Visible = false;
            buttonCancel.Enabled = false;
            buttonCancel.Visible = false;
            buttonReset.Visible = false;
            buttonReset.Enabled = false;

            labelReset.Text = "";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            int selected = getSelectedIdx(dataGridViewEmp, "idEmployee");
            toUpdateEmployee = data.Employees.SingleOrDefault(x => x.idEmployee == selected);
            toUpdateUser = data.Users.SingleOrDefault(x => x.idUser == toUpdateEmployee.idUser);

            toUpdateUser.password = PasswordHash.getHash("Password1234");

            labelReset.Text = "Password changed";

            try { data.SubmitChanges(); } catch (Exception ex) { Console.WriteLine(ex); }
        }

        //
        //////////  Function to calculating working days between two dates
        //
        //public int GetWorkingDays(DateTime from, DateTime to)
        //{
        //    var totalDays = 0;
        //    for (var date = from; date < to; date = date.AddDays(1))
        //    {
        //        if (date.DayOfWeek != DayOfWeek.Saturday
        //            && date.DayOfWeek != DayOfWeek.Sunday)
        //            totalDays++;
        //    }

        //    return totalDays;
        //}
    }
}
 