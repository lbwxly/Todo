using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;
using Todo.Models;

namespace Todo.Infrastructure
{
    /// <summary>
    /// Global error handling
    /// </summary>
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<ErrorResponse>(new ErrorResponse(-1, "System Error"),
                                                           new JsonMediaTypeFormatter())
            };
            base.OnException(actionExecutedContext);
        }
    }
}