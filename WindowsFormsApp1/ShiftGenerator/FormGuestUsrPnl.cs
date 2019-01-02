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
    public partial class FormGuestUsrPnl : Form
    {
        DataClasses1DataContext data;
        public Employee toUpdateEmployee;
        public User toUpdateUser;
        public FTE toUpdateFTE;
        public User loggedUser;
        public FormGuestUsrPnl()
        {
            InitializeComponent();
        }
        public FormGuestUsrPnl(User user)
        {
            InitializeComponent();
            this.ActiveControl = buttonCancel;
            data = new DataClasses1DataContext();
            this.loggedUser = user;
            loadEmployee();
            textBoxPassword.Text = "Password";


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

        public void loadEmployee()
        {
            toUpdateUser = data.Users.SingleOrDefault(x => x.idUser == this.loggedUser.idUser);
            toUpdateEmployee = data.Employees.SingleOrDefault(x => x.idUser == this.loggedUser.idUser);
            

            textBoxName.Text = toUpdateEmployee.name;
            textBoxSurname.Text = toUpdateEmployee.surname;
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            loadEmployee();
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            toUpdateUser = data.Users.SingleOrDefault(x => x.idUser == this.loggedUser.idUser);
            toUpdateEmployee = data.Employees.SingleOrDefault(x => x.idUser == this.loggedUser.idUser);
            toUpdateFTE = data.FTEs.SingleOrDefault(x => x.idEmployee == toUpdateEmployee.idEmployee);

            if (textBoxName.Text != toUpdateEmployee.name && textBoxName.Text != "") { toUpdateEmployee.name = textBoxName.Text; }
            if (textBoxSurname.Text != toUpdateEmployee.surname && textBoxSurname.Text != "") { toUpdateEmployee.surname = textBoxSurname.Text; }
             
            //ComboBoxJobContract
            string comboContractVal = ((KeyValuePair<string, string>)comboBoxContract.SelectedItem).Value;
            //ComboBoxFrenchLevel
            string comboFrenchVal = ((KeyValuePair<string, string>)comboBoxFrenchLvl.SelectedItem).Value;

            //ComboBoxPermission
            string comboTeamVal = ((KeyValuePair<string, string>)comboBoxTeam.SelectedItem).Value;
            //ComboBoxFTE
            string comboFTE = ((KeyValuePair<string, string>)comboBoxFTE.SelectedItem).Value;


            /////////////////////////////////     FTE
            /////// dimension
            if (comboFTE == "1")
                {
                    toUpdateFTE.dimension = 1;
                }else if (comboFTE == "0.8")
                    {
                        toUpdateFTE.dimension = 0.8;
                    }else if (comboFTE == "0.6")
                        {
                            toUpdateFTE.dimension = 0.6;
                        }

            /////////////////////////////// Employee
            toUpdateEmployee.frenchlvl = comboFrenchVal;
            toUpdateEmployee.jobContract = comboContractVal;
            toUpdateEmployee.jobContract = comboContractVal;
            //idTeam
            if (comboTeamVal == "Channels")
                {
                    toUpdateEmployee.idTeam = 1;
                }
                else { toUpdateEmployee.idTeam = 2; }

                try { data.SubmitChanges(); } catch (Exception ex) { Console.WriteLine(ex); }
                labelCheck.Text = "CHANGED !!";
            
            if (textBoxPassword.Text != "" && textBoxRepassword.Text != "" && textBoxPassword.Text != "Password" && textBoxRepassword.Text != "Re-Password")
            {
                if (textBoxPassword.Text.Equals(textBoxRepassword.Text))
                {
                    toUpdateUser.password = PasswordHash.getHash(textBoxPassword.Text);
                    try { data.SubmitChanges(); } catch (Exception ex) { Console.WriteLine(ex); }
                    labelCheck.Text = "CHANGED !!";
                }
                else { labelCheck.Text = "Passwords are different"; }

            }
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxName.ForeColor = SystemColors.WindowText;
        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            textBoxSurname.Clear();
            textBoxSurname.ForeColor = SystemColors.WindowText;
        }
        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.Clear();
            textBoxPassword.ForeColor = SystemColors.WindowText;
        }
        private void textBoxRepassword_Enter(object sender, EventArgs e)
        {
            textBoxRepassword.Clear();
            textBoxRepassword.ForeColor = SystemColors.WindowText;
        }
    }
}
