using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using Morze.SoftwareDevolp.Persistence;
using Persistence;
using Morze.SoftwareDevolp.Domain;
using Morze.SoftwareDevolp.Domain.Persons;


namespace Morze.SoftwareDevolp.SoftwareDevolpTests
{
    public class RepositoryTests
    {
        IRepository memoryRepository = new MemoryRepository();
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Создания пользователя с ролью работник
        /// </summary>
        [Test]
        public void UserCreateEmpolee()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Empolee, "ТестEmpolee");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "ТестEmpolee");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Empolee);
        }
        /// <summary>
        /// Создания пользователя с ролью фрилансер
        /// </summary>
        [Test]
        public void UserCreateFreelancer()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Freelancer, "ТестFreelancer");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "ТестFreelancer");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Freelancer);
        }
        /// <summary>
        /// Создания пользователя с ролью менеджер
        /// </summary>
        [Test]
        public void UserCreateManager()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Manager, "ТестManager");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "ТестManager");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Manager);
        }
        /// <summary>
        /// Проверка на существующего пользователя
        /// </summary>
        [Test]
        public void UserCreateEmpoleeExisted()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Empolee, "Иванов");
            var existednewUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "Иванов");
            Assert.IsTrue(!isCreated);
            Assert.IsTrue(existednewUser != null);
            Assert.IsTrue(existednewUser.UserRole == UserRole.Empolee);
        }
        /// <summary>
        /// Получения пользователя существующего и не существующего
        /// </summary>
        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("Иванов");
            var notExistedUser = memoryRepository.UserGet("Неронов");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notExistedUser == null);
        }
        /// <summary>
        /// Создания отчетов полученных от всех типов ролей пользователя
        /// </summary>
        [Test]
        public void ReportGetByUserEmpoleeTests()
        {
            var reportList = memoryRepository.ReportGetByUser("Иванов", UserRole.Empolee, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"Иванов",8,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"Иванов",12,"test message 2 "),
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        [Test]
        public void ReportGetByUserFreelancerTests()
        {
            var reportList = memoryRepository.ReportGetByUser("Смит", UserRole.Freelancer, null, null);
            var sampleList = new List<TimeRecord>()
            {
                 new TimeRecord(DateTime.Now.Date.AddDays(-6),"Смит",4,"test message 3")
            };
           
            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        [Test]
        public void ReportGetByUserManagerTests()
        {
            var reportList = memoryRepository.ReportGetByUser("Плотников", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"Плотников",8,"test message 1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-1),"Плотников",8,"test message 1")
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        
    }
}