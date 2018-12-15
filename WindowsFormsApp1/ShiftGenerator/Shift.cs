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
        List<Employee> employees = new List<Employee>();
        DateTime day;
        String shiftTime;


        public Shift() { }

        public Shift(List<Employee> employeesAvailable, DateTime day, string shiftTime)
        {
            this.employees = employeesAvailable;
            this.day = day;
            this.shiftTime = shiftTime;
        }

        public string ShiftTime { get => shiftTime; set => shiftTime = value; }
        public DateTime Day { get => day; set => day = value; }
        public List<Employee> EmployeesAvailable { get => employees; set => employees = value; }

        public void fillShiftEmp(DateTime day, String shiftTime)
        {
            DataClasses1DataContext data = new DataClasses1DataContext(); ;

            this.day = day;
            this.shiftTime = shiftTime;
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //string format = "yyyy-MM-dd";
            //string FromDate = "2018-12-12";
            //var dt = DateTime.ParseExact(FromDate, format, provider);

            var result = from employees in data.Employees
                         join req in data.EmpRequirements on employees.idEmployee equals req.idEmployee into ps
                         from req in ps.DefaultIfEmpty()
                         where req.dateReq.Value.Date != day.Date || (req.dateReq.Value.Date == day.Date && !(req.dayNight.Equals(shiftTime)) )|| req.dateReq.Value.Date == null
                         select employees;

            this.EmployeesAvailable = result.ToList();
     
        }

    }
}
