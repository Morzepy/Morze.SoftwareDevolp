using Morze.SoftwareDevolp.Domain;
using Morze.SoftwareDevolp.Domain.Persons;
using System;
using System.Collections.Generic;

namespace Morze.SoftwareDevolp.Persistence
{
    public interface IRepository
    {
        List<User> Users();
        bool UserCreate(UserRole userRole, string name);
        User UserGet(string name);

        void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord);

        List<TimeRecord> ReportGet(UserRole userRole,DateTime? from = null, DateTime? to = null);
        List<TimeRecord> ReportGetByUser(string userName,UserRole userRole, DateTime? from = null, DateTime? to = null);

        List<TimeRecord> Empolees();
        List<TimeRecord> Managers();
        List<TimeRecord> Freelancers();

    }
}
