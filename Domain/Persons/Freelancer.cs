using System;
using System.Collections.Generic;
using System.Text;

namespace Morze.SoftwareDevolp.Domain
{
    public class Freelancer : Human
    {
        public Freelancer(string name, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
        }
    }
}
