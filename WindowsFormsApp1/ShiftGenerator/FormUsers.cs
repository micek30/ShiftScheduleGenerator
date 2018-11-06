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

            //try
            //{
                InitializeComponent();
                this.formHandler = form;
                data = new DataClasses1DataContext();
                loadEmployees();
                loadUsers();
            //}
        }
        private void loadEmployees()
        {
            try
            {
                var result = from employees in data.Employees
                             select new { employees.idEmployee,employees.name, employees.surname, employees.jobContract, employees.idTeam, employees.independent, employees.frenchlvl, employees.idUser};

                dataGridViewEmp.DataSource = result;

                for (int i = 0; i < dataGridViewEmp.Columns.Count; i++)
                {
                    dataGridViewEmp.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                this.Close();
                //formHandler.lostConnection();
            }
        }
        private void loadUsers()
        {
            try
            {
                var result = from users in data.Users
                             select new {users.idUser, users.login, users.password, users.permission };

                dataGridViewUsers.DataSource = result;

                for (int i = 0; i < dataGridViewUsers.Columns.Count; i++)
                {
                    dataGridViewUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                this.Close();
                //formHandler.lostConnection();
            }
        }

    }
}
 