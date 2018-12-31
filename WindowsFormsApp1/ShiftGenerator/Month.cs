using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShiftGenerator
{
    class Month
    {
        int countDays;
        int monthNum;
        int yearNum;
        DateTime firstDay;
        DateTime lastDay;
        List<Shift> shifts = new List<Shift>();

        public Month(int whichMonth, int whichYear)
        {
            this.MonthNum = whichMonth;
            this.YearNum = whichYear;
            DateTime month = new DateTime(whichYear, whichMonth, 1);
            this.FirstDay = new DateTime(whichYear, whichMonth, 1);
            this.LastDay = new DateTime(month.Year, month.Month, DateTime.DaysInMonth(month.Year, month.Month));
            this.CountDays = DateTime.DaysInMonth(month.Year, month.Month);
        }

        public DateTime LastDay { get => lastDay; set => lastDay = value; }
        public DateTime FirstDay { get => firstDay; set => firstDay = value; }
        public int CountDays { get => countDays; set => countDays = value; }
        public int MonthNum { get => monthNum; set => monthNum = value; }
        public int YearNum { get => yearNum; set => yearNum = value; }
        internal List<Shift> Shifts { get => shifts; set => shifts = value; }

        public async void fillShifts()
        {
            int shiftCounter = 0;
            await Task.Run(() =>
            {

                for (int i = 0; i < LastDay.Day; i++)
                {
                    // i+1 żeby dzień nie byl zerowy

                    DateTime date = new DateTime(this.YearNum, this.MonthNum, i + 1);

                    //creating day shift
                    this.Shifts.Add(new Shift(date, "D"));
                    if (i > 0)
                    {
                        //filling day shift
                        Shifts[shiftCounter].chooseEmp(Shifts[shiftCounter - 1]);
                    }
                    else { Shifts[shiftCounter].chooseEmp(Shifts[shiftCounter]); }

                    //creating night shift
                    this.Shifts.Add(new Shift(date, "N"));
                    if (i > 0)
                    {
                        //filling night shift
                        Shifts[shiftCounter + 1].chooseEmp(Shifts[shiftCounter]);
                    }
                    else { Shifts[shiftCounter + 1].chooseEmp(Shifts[shiftCounter]); }
                    shiftCounter += 2;
                }

            });
        }
        public void fillFTE()
        {
            //variables
            DataClasses1DataContext data = new DataClasses1DataContext();
            Employee emp = new Employee();
            List<Employee> allEmp = emp.getAllEmployee();
            int workingHours = 0;
            //finding working days
            switch (this.monthNum)
            {
                case 1:
                    workingHours = 176;
                    break;
                case int i when i == 2 || i == 12:
                    workingHours = 160;
                    break;
                case int i when i == 3 || i == 4 || i == 5 || i == 8 || i == 9:
                    workingHours = 168;
                    break;
                case int i when i == 6 || i == 11:
                    workingHours = 152;
                    break;
                case int i when i == 7 || i == 10:
                    workingHours = 184;
                    break;
            }

            //calculating and filling FTE's
            for (int i = 0; i < allEmp.Count(); i++)
            {
                FTE newFTE = new FTE();
                newFTE = data.FTEs.SingleOrDefault(x => x.idEmployee == allEmp[i].idEmployee);
                //newFTE.workingHours = (int)(workingHours * newFTE.dimension);
                newFTE.workingHours = (int)(Math.Ceiling(workingHours * (double)newFTE.dimension));
                newFTE.workingHoursLast = newFTE.workingHours;
                newFTE.SPM = (int)(Math.Ceiling((double)newFTE.workingHours / 12));

                try { data.SubmitChanges(); } catch (Exception ex) { Console.WriteLine(ex); }
            }
        }
    }
}
