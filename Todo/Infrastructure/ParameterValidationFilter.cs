using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Todo.Infrastructure
{
    public class GuidValidationAttribute : ActionFilterAttribute
    {
        public string ParameterName { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = (Guid) actionContext.ActionArguments[ParameterName];
            if (id == Guid.Empty)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            base.OnActionExecuting(actionContext);
        }
    }
}