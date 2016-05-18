using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NotificationPattern.API.Models;
using NotificationPattern.Business;
using NotificationPattern.Entities;
using NotificationPattern.Gateway;
using NotificationPattern.InMemoryDB;
using cSharp.Monads;
using NotificationPattern.API.Utility;

namespace NotificationPattern.API.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<string> Get()
        {
            return new string[] { "NotImplemented", "NotImplemented" };
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "Not implemented yet";
        }

        // POST: api/Employee
        public ResponseModel<String> Post(EmployeeViewModel model)
        {
            ManageEmployee manageEmployee = new ManageEmployee(new EmployeeStore());
            ResponseModel<String> response = new ResponseModel<String>();
            Employee employee = Employee.newEmployee(null, model.Name, model.Designation, model.DateOfBirth);
            manageEmployee.add(employee).Apply(l => ResponseStatus.setFailureStatus<String>(response, l), r => ResponseStatus.setSuccesstatus<String>(response, r));
            return response;
        }
               
    }
}
