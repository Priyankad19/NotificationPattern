using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Business
{
    sealed class  ErrorCodes
    {
        public const string SUCCESS_CODE = "Success";
        public const string DUPLICATE_EMPLOYEE_ID = "DuplicateEmployeeId";
        public const string EMPLOYEE_NAME_EMPTYORNULL = "EmployeeNameEmptyOrNull";
        public const string EMPLOYEE_DESIGNATION_EMPTYORNULL = "EmployeeDesignationEmptyOrNull";
        public const string EMPLOYEE_DATE_OF_BIRTH_EMPTYORNULL = "EmployeeDateOfBirthEmptyOrNull";
        public const string EMPLOYEE_AGE_SHOULD_BE_MORE_THAN21 = "EmployeeAgeShouldBeMoreThan21";
        public const string FAILURE_CODE = "Failed";
    }
}
