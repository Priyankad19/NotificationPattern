using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationPattern.Entities;
using cSharp.Monads;
using NotificationPattern.Gateway;
using NotificationPattern.Business;

namespace NotificationPattern.Tests
{
    [TestClass]
    public class ManageEmployeeTest
    {
        [TestMethod]
        public void shouldGenerateEmptyNameExceptionMessageForEmptyNamePassed()
        {
            Employee emp = Employee.newEmployee(null,null, "Developer", Convert.ToDateTime("04/18/1984"));
            IEmployeeGateway gateway = new EmployeeStoreTestDouble();
            ManageEmployee manageEmployee = new ManageEmployee(gateway);
            manageEmployee.add(emp).Apply(LeftEmptyNameNotification, RightSuccess);
        }

        [TestMethod]
        public void shouldGenerateEmptyDesignationExceptionMessageForEmptyDesignationPassed()
        {
            Employee emp = Employee.newEmployee(null, "ABC ABC", "", Convert.ToDateTime("04/18/1984"));
            IEmployeeGateway gateway = new EmployeeStoreTestDouble();
            ManageEmployee manageEmployee = new ManageEmployee(gateway);
            manageEmployee.add(emp).Apply(LeftEmptyDesignationNotification, RightSuccess);
        }

        [TestMethod]
        public void shouldGenerateEmptyDateOfBirthExceptionMessageForEmptyEmptyDateOfBirthPassed()
        {
            Employee emp = Employee.newEmployee(null, "ABC ABC", "Developer", null);
            IEmployeeGateway gateway = new EmployeeStoreTestDouble();
            ManageEmployee manageEmployee = new ManageEmployee(gateway);
            manageEmployee.add(emp).Apply(LeftEmptyDateOfBirthNotification, RightSuccess);
        }

        [TestMethod]
        public void shouldGenerateAgeLimitExceptionMessageForAgeBelow21Passed()
        {
            Employee emp = Employee.newEmployee(null, "ABC ABC", "Developer", Convert.ToDateTime("04/18/1996"));
            IEmployeeGateway gateway = new EmployeeStoreTestDouble();
            ManageEmployee manageEmployee = new ManageEmployee(gateway);
            manageEmployee.add(emp).Apply(LeftAgeLimitNotification, RightSuccess);
        }

        [TestMethod]
        public void shouldGenerateSuccessMessageForNewEmployeeWithAllValuesPassed()
        {
            Employee emp = Employee.newEmployee(null, "ABC ABC", "Developer", Convert.ToDateTime("04/18/1984"));
            IEmployeeGateway gateway = new EmployeeStoreTestDouble();
            ManageEmployee manageEmployee = new ManageEmployee(gateway);
            manageEmployee.add(emp).Apply(LeftNotificationMoreThanOne, RightSuccess);
        }

        private void LeftNotificationMoreThanOne(Notification notification)
        {
            Assert.IsTrue(notification.getMessages().Count > 0);
        }

       private void LeftEmptyNameNotification(Notification notification)
        {
            Assert.IsTrue(notification.getMessages().Contains("EmployeeNameEmptyOrNull"));
        }

        private void LeftEmptyDesignationNotification(Notification notification)
        {
            Assert.IsTrue(notification.getMessages().Contains("EmployeeDesignationEmptyOrNull"));
        }
        private void LeftEmptyDateOfBirthNotification(Notification notification)
        {
            Assert.IsTrue(notification.getMessages().Contains("EmployeeDateOfBirthEmptyOrNull"));
        }
        private void LeftAgeLimitNotification(Notification notification)
        {
            Assert.IsTrue(notification.getMessages().Contains("EmployeeAgeShouldBeMoreThan21"));
        }

        private void RightSuccess(String status)
        {
            Assert.AreEqual("Success", status);
        }
    }
}
