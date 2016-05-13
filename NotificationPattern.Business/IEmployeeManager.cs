using cSharp.Monads;
using NotificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Business
{
    interface IEmployeeManager
    {
        Either<Notification, String> add(Employee emp);
    }
}
