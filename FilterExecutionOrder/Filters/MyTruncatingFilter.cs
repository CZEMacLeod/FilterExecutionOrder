using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterExecutionOrder.Filters
{
    public class MyTruncatingFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            System.Diagnostics.Debug.WriteLine("Before");
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            System.Diagnostics.Debug.WriteLine("After");
            var old = actionExecutedContext.Response.Content as ObjectContent<IEnumerable<string>>;
            if (old != null) {
                var formatter = old.Formatter;
                var content = (IEnumerable<string>)old.Value;
                actionExecutedContext.Response.Content = new ObjectContent<IEnumerable<string>>(content.Take(1), formatter);
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
