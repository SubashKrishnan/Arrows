using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
namespace Trade.ApiAuth
{
    public class APIAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private ApiSecurity objClass = new ApiSecurity();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));
                // Gets username and password  
                string usrename = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];
                // Validate username and password  
                if (!objClass.VaidateUser(usrename, password))
                {
                    // returns unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}