using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model
{
    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PreferedName { get; set; }
        public string StudentEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string PersonalCellPhone { get; set; }
        public string ChapelSeat { get; set; }
        public string Mailbox { get; set; }
        public string BoxCombination { get; set; }
        public string Collegian { get; set; }
        public string FirstAddressLine { get; set; }
        public string SecondAddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        // This will return the address properly formatted
        public string Address { get; set; }

        // This will return the student name properly formatted
        public string FullName { get; set; }
    }
}
