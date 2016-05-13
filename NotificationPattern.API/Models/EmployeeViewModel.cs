using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationPattern.API.Models
{
    public class EmployeeViewModel
    {

        private string id;
        private string name;
        private string designation;
        private DateTime? dateOfBirth;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
    }
}