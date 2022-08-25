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
        /// <summary>
        /// проверка зарплаты за обычную 8-ч работу и переработку
        /// </summary>
        [Test]
        public void ManagerTotalPay1()
        {
            //10 000 + 11 000 + 8750 = 29750
            Manager manager = new Manager("test", new List<TimeRecord>() { 
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test message"),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",7,"test message"),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",9,"test message")
            });

            Assert.IsTrue(manager.TotalPay == 29750);
        }
        [Test]
        public void ManagerTotalPay2()
        {
            //10 000 = 10 000
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-3),"test",8,"test message"),
            });

            Assert.IsTrue(manager.TotalPay == 10000);
        }
        public void ManagerTotalPay3()
        {
            //11 000 * 5 = 55 000
            Manager manager = new Manager("test", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-5),"test",9,"test message 1"),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",9,"test message 2 "),
                new TimeRecord(DateTime.Now.AddDays(-3),"test",9,"test message 3 "),
                new TimeRecord(DateTime.Now.AddDays(-2),"test",9,"test message 4 "),
                new TimeRecord(DateTime.Now.AddDays(-1),"test",9,"test message 5"),
            });

            Assert.IsTrue(manager.TotalPay == 55000);
        }
    }
}