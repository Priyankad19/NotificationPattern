using NotificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Gateway
{
    public interface IEmployeeGateway
    {
        void add( Employee emp);
        Employee get(string empId);
        void update(Employee emp);
    }
}
