using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Entities
{
    public class Employee
    {
        private string id;
        private string name;
        private string designation;
        private DateTime? dateOfBirth;

        public string Id { get { return id; }
            private set
            {
                if (value == null)
                    this.id = generateID();
                else
                    this.id = value;
            }
        }
        public string Name { get { return name; } }
        public string Designation { get { return designation; } }
        public DateTime? DateOfBirth { get { return dateOfBirth; } }

        private Employee(string id, string name, string designation, DateTime? dateOfBirth)
        {
            Id = id;
            this.name = name;
            this.designation = designation;
            this.dateOfBirth = dateOfBirth;
        }

        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static Employee newEmployee(string id, string name, string designation, DateTime? dateOfBirth)
        {
            return new Employee(id, name, designation, dateOfBirth);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            Employee other = (Employee)obj;
            if (name == null && other.name != null)
              return false;
            else if (!String.Equals(name,other.name))
                return false;
            else  if (id == null && other.id != null)
                return false;
            if (id != other.id)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
		    int result = 1;
		    result = prime * result + ((name == null) ? 0 : name.GetHashCode());
            result = prime * result + ((id == null) ? 0 : id.GetHashCode());
		    return result;
        }

        public override string ToString()
        {
            return "EmployeeID = " + id + " , Name = " + name + " , Designation = " + designation + " , dateOfBirth" + dateOfBirth;
        }
    }
}
