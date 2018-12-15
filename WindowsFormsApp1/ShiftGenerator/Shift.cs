using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftGenerator
{
    class Shift
    {
        List<Employee> employeesAvailable = new List<Employee>();
        List<Employee> employeesChoosen = new List<Employee>();
        DateTime day;
        String shiftTime;


        public Shift() { }

        public Shift(List<Employee> employeesAvailable, DateTime day, string shiftTime)
        {
            this.employeesAvailable = employeesAvailable;
            this.day = day;
            this.shiftTime = shiftTime;
        }

        public string ShiftTime { get => shiftTime; set => shiftTime = value; }
        public DateTime Day { get => day; set => day = value; }
        public List<Employee> EmployeesAvailable { get => employeesAvailable; set => employeesAvailable = value; }

        public void fillShiftEmp(DateTime day, String shiftTime, String restriction)
        {
            DataClasses1DataContext data = new DataClasses1DataContext(); ;

            this.day = day;
            this.shiftTime = shiftTime;
            switch (restriction)
            {
                case "all":
                    var resultAll = from employees in data.Employees
                                 join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                 from req in ps.DefaultIfEmpty()
                                 where req.dateReq.Value.Date != day.Date || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime))) || req.dateReq.Value.Date == null
                                 select employees;
                    this.EmployeesAvailable = resultAll.ToList();
                    break;
                case "CH":
                    var resultCH = from employees in data.Employees
                                 join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                 from req in ps.DefaultIfEmpty()
                                 where req.dateReq.Value.Date != day.Date && employees.idTeam == 1 || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.idTeam == 1) || req.dateReq.Value.Date == null && employees.idTeam == 1
                                   select employees;
                    this.EmployeesAvailable = resultCH.ToList();
                    break;
                case "MF":
                    var resultMF = from employees in data.Employees
                                   join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                   from req in ps.DefaultIfEmpty()
                                   where req.dateReq.Value.Date != day.Date && employees.idTeam == 2 || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.idTeam == 2) || req.dateReq.Value.Date == null && employees.idTeam == 2
                                   select employees;
                    this.EmployeesAvailable = resultMF.ToList();
                    break;
                case "Language":
                    var levels = new string[] { "B2", "C1", "C2" };
                    var resultLang = from employees in data.Employees
                                    join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                    from req in ps.DefaultIfEmpty()
                                    where req.dateReq.Value.Date != day.Date && levels.Contains(employees.frenchlvl) || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && levels.Contains(employees.frenchlvl)) || req.dateReq.Value.Date == null && levels.Contains(employees.frenchlvl)
                                     select employees;
                    this.EmployeesAvailable = resultLang.ToList();
                    break;
                case "Independent":
                    var resultInd = from employees in data.Employees
                                   join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                   from req in ps.DefaultIfEmpty()
                                   where req.dateReq.Value.Date != day.Date && employees.independent == true || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.independent == true) || req.dateReq.Value.Date ==  && employees.independent == true
                                    select employees;
                    this.EmployeesAvailable = resultInd.ToList();
                    break;
            }
        }

        public void chooseEmp()
        {

        }

    }
}
