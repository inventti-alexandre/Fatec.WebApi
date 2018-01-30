using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Fatec.WebApi.Filters
{
    public class ActionRequestFilter : ActionFilterAttribute
    {
        private string SendJson { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var parametros = actionContext.ActionArguments;
            var itens = string.Empty;

            if (parametros.Count == 1)
                SendJson = JsonConvert.SerializeObject(new { obj = parametros.FirstOrDefault().Value });
            else
                SendJson = null;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                var statusCode = (int)actionExecutedContext.Response.StatusCode;
                var verb = actionExecutedContext.Request.Method.Method;
                var endPoint = actionExecutedContext.Request.RequestUri.AbsoluteUri;
                var json = SendJson;

            }
        }
    }
}