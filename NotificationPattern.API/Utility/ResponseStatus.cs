using NotificationPattern.API.Models;
using NotificationPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationPattern.API.Utility
{
    public class ResponseStatus
    {
        public static void setFailureStatus<T>(ResponseModel<T> responseModel, Notification notification)
        {
            responseModel.Status = "Fail";
            responseModel.Message = notification.getMessages();
        }

        public static void setSuccesstatus<T>(ResponseModel<T> responseModel, T data)
        {
            responseModel.Status = "Success";
            responseModel.Message = null;
            responseModel.Data = data;
        }
    }
}