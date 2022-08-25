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
        /// �������� ������������ � ����� ��������
        /// </summary>
        [Test]
        public void UserCreateEmpolee()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Empolee, "����Empolee");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "����Empolee");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Empolee);
        }
        /// <summary>
        /// �������� ������������ � ����� ���������
        /// </summary>
        [Test]
        public void UserCreateFreelancer()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Freelancer, "����Freelancer");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "����Freelancer");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Freelancer);
        }
        /// <summary>
        /// �������� ������������ � ����� ��������
        /// </summary>
        [Test]
        public void UserCreateManager()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Manager, "����Manager");
            var newUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "����Manager");
            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser != null);
            Assert.IsTrue(newUser.UserRole == UserRole.Manager);
        }
        /// <summary>
        /// �������� �� ������������� ������������
        /// </summary>
        [Test]
        public void UserCreateEmpoleeExisted()
        {
            bool isCreated = memoryRepository.UserCreate(UserRole.Empolee, "������");
            var existednewUser = memoryRepository.Users().FirstOrDefault(x => x.Name == "������");
            Assert.IsTrue(!isCreated);
            Assert.IsTrue(existednewUser != null);
            Assert.IsTrue(existednewUser.UserRole == UserRole.Empolee);
        }
        /// <summary>
        /// ��������� ������������ ������������� � �� �������������
        /// </summary>
        [Test]
        public void UserGetTest()
        {
            var existedUser = memoryRepository.UserGet("������");
            var notExistedUser = memoryRepository.UserGet("�������");
            Assert.IsTrue(existedUser != null);
            Assert.IsTrue(notExistedUser == null);
        }
        /// <summary>
        /// �������� ������� ���������� �� ���� ����� ����� ������������
        /// </summary>
        [Test]
        public void ReportGetByUserEmpoleeTests()
        {
            var reportList = memoryRepository.ReportGetByUser("������", UserRole.Empolee, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"������",8,"test message"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"������",12,"test message 2 "),
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        [Test]
        public void ReportGetByUserFreelancerTests()
        {
            var reportList = memoryRepository.ReportGetByUser("����", UserRole.Freelancer, null, null);
            var sampleList = new List<TimeRecord>()
            {
                 new TimeRecord(DateTime.Now.Date.AddDays(-6),"����",4,"test message 3")
            };
           
            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        [Test]
        public void ReportGetByUserManagerTests()
        {
            var reportList = memoryRepository.ReportGetByUser("���������", UserRole.Manager, null, null);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"���������",8,"test message 1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-1),"���������",8,"test message 1")
            };

            Assert.IsTrue(Enumerable.SequenceEqual(reportList, sampleList, new TimeRecordComparer()));
        }
        
    }
}