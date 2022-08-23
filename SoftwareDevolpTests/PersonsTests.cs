using Morze.SoftwareDevolp.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Morze.SoftwareDevolp.SoftwareDevolpTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ManagerTotalPay()
        {
            //10 000 + 11 000 + 8750 = 29750
            Manager manager = new Manager("test", new List<TimeRecord>() { 
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test message"),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",7,"test message"),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",9,"test message")
            });

            Assert.IsTrue(manager.TotalPay == 29750);
        }
    }
}