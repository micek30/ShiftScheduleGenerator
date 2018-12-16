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
        bool language = false;


        public Shift() { }

        public Shift(DateTime day, string shiftTime)
        {
            this.day = day;
            this.shiftTime = shiftTime;
        }

        public string ShiftTime { get => shiftTime; set => shiftTime = value; }
        public DateTime Day { get => day; set => day = value; }
        public List<Employee> EmployeesAvailable { get => employeesAvailable; set => employeesAvailable = value; }
        public List<Employee> EmployeesChoosen { get => employeesChoosen; set => employeesChoosen = value; }
        public bool Language { get => language; set => language = value; }

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
                                   where req.dateReq.Value.Date != day.Date && employees.independent == true || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.independent == true) || req.dateReq.Value.Date ==  null && employees.independent == true
                                    select employees;
                    this.EmployeesAvailable = resultInd.ToList();
                    break;
                case "CH-I":
                    var resultCHI = from employees in data.Employees
                                   join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                   from req in ps.DefaultIfEmpty()
                                   where req.dateReq.Value.Date != day.Date && employees.idTeam == 1 && employees.independent == true || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.idTeam == 1 && employees.independent == true) || req.dateReq.Value.Date == null && employees.idTeam == 1 && employees.independent == true
                                    select employees;
                    this.EmployeesAvailable = resultCHI.ToList();
                    break;
                case "MF-I":
                    var resultMFI = from employees in data.Employees
                                   join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                                   from req in ps.DefaultIfEmpty()
                                   where req.dateReq.Value.Date != day.Date && employees.idTeam == 2 && employees.independent == true || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) && employees.idTeam == 2 && employees.independent == true) || req.dateReq.Value.Date == null && employees.idTeam == 2 && employees.independent == true
                                    select employees;
                    this.EmployeesAvailable = resultMFI.ToList();
                    break;
            }
        }

        public void chooseEmp()
        {
            Random rnd = new Random();

            //////////////////  DAY SHIFTS - 2 channels, 2 MF, 1 language support, 2 idependent
            if (this.shiftTime == "D")
            {
                /////////CHANNELS
                int counterCH = 0;
                fillShiftEmp(this.day, this.shiftTime, "CH-I");
                var listOfCH = new List<int> { };
                while (counterCH <= 1)
                {
                    int r = rnd.Next(0,employeesAvailable.Count-1);

                    if (listOfCH.Count == 0)
                    {
                        EmployeesChoosen.Add(employeesAvailable[r]);
                        listOfCH.Add(r);
                        fillShiftEmp(this.day, this.shiftTime, "CH");
                        counterCH += 1;

                    }
                    else
                    {
                        if (listOfCH.Contains(r)){} else
                        {
                            EmployeesChoosen.Add(employeesAvailable[r]);
                            listOfCH.Add(r);
                            counterCH += 1;
                        }
                    }

                    if (employeesAvailable[r].frenchlvl == "B2" || employeesAvailable[r].frenchlvl == "C1" || employeesAvailable[r].frenchlvl == "C2")
                    {
                        Language = true;
                    }
                }

                ////////////Mainframe
                int counterMF = 0;
                fillShiftEmp(this.day, this.shiftTime, "MF-I");
                var listOfMF = new List<int> { };
                while (counterMF <= 1)
                {
                    int r = rnd.Next(employeesAvailable.Count);
                    if (listOfCH.Count == 0)
                    {
                        EmployeesChoosen.Add(employeesAvailable[r]);
                        listOfMF.Add(r);
                        fillShiftEmp(this.day, this.shiftTime, "MF");
                        counterMF += 1;

                    }
                    else
                    {
                        if (listOfCH.Contains(r)) { }
                        else
                        {
                            EmployeesChoosen.Add(employeesAvailable[r]);
                            listOfMF.Add(r);
                            counterMF += 1;
                        }
                    }


                    if (employeesAvailable[r].frenchlvl == "B2" || employeesAvailable[r].frenchlvl == "C1" || employeesAvailable[r].frenchlvl == "C2")
                    {
                        Language = true;
                    }
                }

                /////////LANGUAGE SUPPORT
                if (!Language)
                {
                    fillShiftEmp(this.day, this.shiftTime, "language");
                    int r = rnd.Next(employeesAvailable.Count);
                    EmployeesChoosen.Add(employeesAvailable[r]);
                }


            }

        }

    }
}
