using NotificationPattern.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationPattern.Entities;
using cSharp.Monads;

namespace NotificationPattern.Business
{
    public class ManageEmployee : IEmployeeManager
    {
        private IEmployeeGateway employeeGateway;
        private Notification notifications;

        public ManageEmployee()
        {
            notifications = new Notification();
        }

        public ManageEmployee(IEmployeeGateway employeeGateway)
            : this()
        {
            this.employeeGateway = employeeGateway;
        }

        public Either<Notification, String> add(Entities.Employee emp)
        {
            validate(emp);
            if (notifications.isEmpty())
            {
                employeeGateway.add(emp);
                return Either<Notification, String>.Right("Success");
            }
            return Either<Notification, String>.Left(notifications);
        }

        private void validate(Employee entity)
        {
            validateEmployeeName(entity);
            validateEmployeeDesignation(entity);
            validateEmployeeDateOfBirth(entity);
            validateForDuplicateId(entity);
        }

        private void validateForDuplicateId(Employee entity)
        {
            if (employeeGateway.get(entity.Id) != null)
            {
                notifications.add("DuplicateEmployeeId");
            }
        }
        private void validateEmployeeName(Employee entity)
        {
            if (String.IsNullOrEmpty(entity.Name))
                notifications.add("EmployeeNameEmptyOrNull");
        }

        private void validateEmployeeDesignation(Employee entity)
        {
            if (String.IsNullOrEmpty(entity.Designation))
                notifications.add("EmployeeDesignationEmptyOrNull");
        }

        private void validateEmployeeDateOfBirth(Employee entity)
        {
            if (entity.DateOfBirth == null)
                notifications.add("EmployeeDateOfBirthEmptyOrNull");
            else
            {
                if ((DateTime.Today.Year - entity.DateOfBirth.Value.Year) < 21)
                    notifications.add("EmployeeAgeShouldBeMoreThan21");
            }
        }

    }
}
