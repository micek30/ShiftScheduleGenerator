using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void fillShifts()
        {
            int shiftCounter = 0;
            for(int i = 0; i < LastDay.Day;i++)
            {
                // i+1 żeby dzień nie byl zerowy
                DateTime date = new DateTime(this.YearNum, this.MonthNum, i+1);

                //creating day shift
                this.Shifts.Add(new Shift(date, "D"));
                if (i > 0)
                {
                    //filling day shift
                    Shifts[shiftCounter].chooseEmp(Shifts[shiftCounter - 1]);
                }else { Shifts[shiftCounter].chooseEmp(Shifts[shiftCounter]); }
                
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
        }
    }
}
