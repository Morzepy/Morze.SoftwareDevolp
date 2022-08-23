using System;
using System.Collections.Generic;

namespace Morze.SoftwareDevolp.Domain
{
    public class Human
    {
        public string Name { get; }
        public List<TimeRecord> TimeRecords { get; }
        public Human(string name, List<TimeRecord> timeRecords)
        {
            Name = name;
            TimeRecords = timeRecords;
        }
    }
}
