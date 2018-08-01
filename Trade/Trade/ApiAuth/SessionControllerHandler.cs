using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
namespace Trade.ApiAuth
{
    public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionControllerHandler(RouteData routeData)
       : base(routeData)
        { }
    }
}