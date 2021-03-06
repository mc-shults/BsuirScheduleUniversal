﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsuirScheduleLib.BsuirApi.Employee
{
    public class Employee
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string rank { get; set; }
        public string photoLink { get; set; }
        public string calendarId { get; set; }
        public List<string> academicDepartment { get; set; }
        public int id { get; set; }
        public string fio { get; set; }
        public string FullName => lastName + " " + firstName + " " + middleName;

        public bool Contains(string str)
        {
            var parts = str.Split(' ');
            Func<string, string, bool> contains = (name, substr) =>
                CultureInfo.CurrentUICulture.CompareInfo.IndexOf(name, substr, CompareOptions.IgnoreCase) >= 0;
            return parts.All(p => contains(firstName, p) || contains(middleName, p) || contains(lastName, p));
        }

        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            return employee != null &&
                   firstName == employee.firstName &&
                   lastName == employee.lastName &&
                   middleName == employee.middleName &&
                   rank == employee.rank &&
                   photoLink == employee.photoLink &&
                   calendarId == employee.calendarId &&
                   academicDepartment.SequenceEqual(employee.academicDepartment) &&
                   id == employee.id &&
                   fio == employee.fio;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
