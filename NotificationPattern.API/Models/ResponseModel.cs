using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotificationPattern.API.Models
{
    public class ResponseModel<T>
    {
        private String status;
        private Object message;
        private T data;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        public Object Message
        {
            get { return message; }
            set { message = value; }
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public ResponseModel(){}

        public ResponseModel(String status, String message, T data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}