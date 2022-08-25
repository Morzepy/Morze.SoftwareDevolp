using Morze.SoftwareDevolp.Domain;
using Morze.SoftwareDevolp.Domain.Persons;
using Morze.SoftwareDevolp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class MemoryRepository : IRepository
    {
        #region Fake Date
        private List<TimeRecord> empolees = new List<TimeRecord>()
        {
             new TimeRecord(DateTime.Now.Date.AddDays(-3),"Иванов",8,"test message"),
             new TimeRecord(DateTime.Now.Date.AddDays(-3),"Шишкин",8,"test message 1"),
             new TimeRecord(DateTime.Now.Date.AddDays(-2),"Иванов",12,"test message 2 "),
             new TimeRecord(DateTime.Now.Date.AddDays(-2),"Шишкин",4,"test message 3"),
        };
        

        private List<TimeRecord> freelancers = new List<TimeRecord>()
        {
             new TimeRecord(DateTime.Now.Date.AddDays(-3),"Алексеев",5,"test message "),
             new TimeRecord(DateTime.Now.Date.AddDays(-4),"Брин",7,"test message 1"),
             new TimeRecord(DateTime.Now.Date.AddDays(-1),"Шольц",10,"test message 2 "),
             new TimeRecord(DateTime.Now.Date.AddDays(-6),"Смит",4,"test message 3"),
        };
        

        private List<TimeRecord> managers = new List<TimeRecord>()
        {
             new TimeRecord(DateTime.Now.Date.AddDays(-2),"Плотников",8,"test message 1"),
             new TimeRecord(DateTime.Now.Date.AddDays(-1),"Плотников",8,"test message 1")
        };

        private List<User> users = new List<User>()
        {
            new User("Иванов",UserRole.Empolee),
            new User("Шишкин",UserRole.Empolee),
            new User("Алексеев",UserRole.Freelancer),
            new User("Брин",UserRole.Freelancer),
            new User("Шольц",UserRole.Freelancer),
            new User("Смит",UserRole.Freelancer),
            new User("Плотников",UserRole.Manager)
        };
        
        #endregion
        public List<TimeRecord> Empolees()
        {
            return empolees;
        }
        public List<TimeRecord> Freelancers()
        {
            return freelancers;
        }
        public List<TimeRecord> Managers()
        {
            return managers;
        }
        public List<User> Users()
        {
            return users;
        }
        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = new List<TimeRecord>();
            switch (userRole)
            {
                case UserRole.Manager:
                    records = Managers();
                    break;
                case UserRole.Empolee:
                    records = Empolees();
                    break;
                case UserRole.Freelancer:
                    records = Freelancers();
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
            if (from == null)
            {
                from = DateTime.Now.AddYears(-100);
            }
            if (to == null)
            {
                to = DateTime.Now;
            }
            return records.Where(x => from.Value <= x.Date && x.Date <= to).ToList();
        }

        public List<TimeRecord> ReportGetByUser(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x=>x.Name == userName).ToList();
        }

        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            switch (userRole)
            {
                case UserRole.Manager:
                    managers.Add(timeRecord);
                    break;
                case UserRole.Empolee:
                    empolees.Add(timeRecord);
                    break;
                case UserRole.Freelancer:
                    freelancers.Add(timeRecord);
                    break;
                default:
                    throw new NotImplementedException("Добавлена новая роль");
            }
        }
        public bool UserCreate(UserRole userRole, string name)
        {
            var newUser = new User(name, userRole);
            User existedUser = UserGet(name);
            if (existedUser == null)
            {
                users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        public User UserGet(string name)
        {
            return Users().FirstOrDefault(x => x.Name == name);
        }

       
    }
}
