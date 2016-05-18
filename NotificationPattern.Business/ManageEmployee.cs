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

        /// <summary>
        /// Constructor to assign database gateway
        /// </summary>
        /// <param name="employeeGateway"></param>
        public ManageEmployee(IEmployeeGateway employeeGateway)
            : this()
        {
            this.employeeGateway = employeeGateway;
        }

        /// <summary>
        /// Adds the employee to the repository
        /// </summary>
        /// <param name="emp">Employee entity</param>
        /// <returns>Either<Notification,String> - Left value in case of any validation error otheriwse right value with success message</returns>
        public Either<Notification, String> add(Entities.Employee emp)
        {
            validate(emp);
            if (notifications.isEmpty())
            {
                employeeGateway.add(emp);
                return Either<Notification, String>.Right(ErrorCodes.SUCCESS_CODE);
            }
            return Either<Notification, String>.Left(notifications);
        }

        /// <summary>
        /// Performs all the validations on entity
        /// </summary>
        /// <param name="entity">Entity to be validated</param>
        private void validate(Employee entity)
        {
            validateEmployeeName(entity);
            validateEmployeeDesignation(entity);
            validateEmployeeDateOfBirth(entity);
            validateForDuplicateId(entity);
        }

        /// <summary>
        /// Validates entity for Dulplicate Id
        /// </summary>
        /// <param name="entity">Entity to be validated</param>
        private void validateForDuplicateId(Employee entity)
        {
            if (employeeGateway.get(entity.Id) != null)
            {
                notifications.add(ErrorCodes.DUPLICATE_EMPLOYEE_ID);
            }
        }

        /// <summary>
        /// Validates entity for Empty or Null Employee Name
        /// </summary>
        /// <param name="entity">Entity to be validated</param>
        private void validateEmployeeName(Employee entity)
        {
            if (String.IsNullOrEmpty(entity.Name))
                notifications.add(ErrorCodes.EMPLOYEE_NAME_EMPTYORNULL);
        }

        /// <summary>
        /// Validates entity for Empty or Null Designation
        /// </summary>
        /// <param name="entity">Entity to be validated</param>
        private void validateEmployeeDesignation(Employee entity)
        {
            if (String.IsNullOrEmpty(entity.Designation))
                notifications.add(ErrorCodes.EMPLOYEE_DESIGNATION_EMPTYORNULL);
        }

        /// <summary>
        /// Validates entity for Empty/Null DateOfBirth and the age limit of 21 
        /// </summary>
        /// <param name="entity">Entity to be validated</param>
        private void validateEmployeeDateOfBirth(Employee entity)
        {
            if (!entity.DateOfBirth.HasValue)
                notifications.add(ErrorCodes.EMPLOYEE_DATE_OF_BIRTH_EMPTYORNULL);
            else
            {
                if ((DateTime.Today.Year - entity.DateOfBirth.Value.Year) < 21)
                    notifications.add(ErrorCodes.EMPLOYEE_AGE_SHOULD_BE_MORE_THAN21);
            }
        }

    }
}
