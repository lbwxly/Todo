using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Todo.Models
{
    [DataContract]
    public class ErrorResponse
    {
        public ErrorResponse(int errorCode, string message)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }

        [DataMember(Name = "errorCode")]
        public int ErrorCode { get; set; }

        [DataMember(Name = "errorMessage")]
        public string ErrorMessage { get; set; }
    }
}