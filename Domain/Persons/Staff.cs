using System;
using System.Collections.Generic;
using System.Text;

namespace Morze.SoftwareDevolp.Domain
{
    public class Staff: Human
    {
        public decimal MonthSalary { get; }
        public Staff(string name, decimal monthSalary, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
            MonthSalary = monthSalary;
        }
    }
}
