using NotificationPattern.Entities;
using NotificationPattern.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.InMemoryDB
{
    public class EmployeeStore : IEmployeeGateway
    {
        private static List<Employee> employeeStorage = new List<Employee>();
        
        public void add(Employee emp)
        {
            employeeStorage.Add(emp);
        }

        public Employee get(string empId)
        {
            return employeeStorage.Single(e => e.Id.Equals(empId));
        }

        public void update(Employee emp)
        {
            var empOld = employeeStorage.Where(e => e.Id == emp.Id).FirstOrDefault();
            if (empOld != null)
            {
                employeeStorage.Remove(empOld);
                add(emp);
            }
        }

      
    }
}
