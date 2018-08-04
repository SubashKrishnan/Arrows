using System;
using System.Linq;
using System.Web.Http.Filters;

namespace Trade.ApiAuth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CompressFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var acceptedEncoding = actionExecutedContext.Response.RequestMessage.Headers.AcceptEncoding.First().Value;
            if (!acceptedEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase)
            && !acceptedEncoding.Equals("deflate", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
            actionExecutedContext.Response.Content = new CompressedContent(actionExecutedContext.Response.Content, acceptedEncoding);
        }
    }
}