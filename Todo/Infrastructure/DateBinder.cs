using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json.Linq;

namespace Todo.Infrastructure
{
    public class DateBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            JObject queryJson = null;
            if (actionContext.Request.RequestUri.TryReadQueryAsJson(out queryJson))
            {
                if (queryJson.ContainsKey("year") &&
                    queryJson.ContainsKey("month") &&
                    queryJson.ContainsKey("day"))
                {
                    string year = queryJson["year"].Value<string>();
                    string month = queryJson["month"].Value<string>();
                    string day = queryJson["day"].Value<string>();
                    DateTime date = DateTime.Now;

                    if (DateTime.TryParse($"{year}-{month}-{day}", out date))
                    {
                        bindingContext.Model = date;
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }
    }
}