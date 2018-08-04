using DataBaseClass;
using System;
using System.Web;
using System.Web.Mvc;
namespace Trade.Controllers
{
    public class AdminController : Controller
    {
        #region  Declarations
        #endregion
        #region Action Results
        [HttpGet]
        public ActionResult Index()
        {
            if (DataBaseClass.Global.IntLoginID == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Customer()
        {
            if (DataBaseClass.Global.IntLoginID == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Client()
        {
            if (DataBaseClass.Global.IntLoginID == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Trade()
        {
            if (DataBaseClass.Global.IntLoginID == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            try
            {
                DataBaseClass.Global.IntLoginID = 0;
                DataBaseClass.Global.StrLoginName = string.Empty;
                ExpireCookie();
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to Logout()", "AdminController.cs", DataBaseClass.Global.StrLoginName, "LoginModel.cs", "public ActionResult Logout()");
            }
            return RedirectToAction("Index", "Login");
        }
        #endregion
        #region  Methods
        [HttpPost]
        public bool ExpireCookie()
        {
            try
            {
                HttpCookie aCookie;
                string cookieName;
                int limit = Request.Cookies.Count;
                for (int i = 0; i < limit; i++)
                {
                    cookieName = Request.Cookies[i].Name;
                    aCookie = new HttpCookie(cookieName)
                    {
                        Expires = DateTime.Now.AddDays(-1)
                    };
                    System.Web.HttpContext.Current.Response.Cookies.Add(aCookie);
                }
                if (Request.Cookies["StockOrion"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("StockOrion");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                    DataBaseClass.Global.IntLoginID = 0;
                    DataBaseClass.Global.StrLoginName = "";
                    DataBaseClass.Global.StrLoginUserName = "";
                    DataBaseClass.Global.StrUserBrowser = "";
                    DataBaseClass.Global.StrLoginIP = "";
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    System.Web.Security.FormsAuthentication.SignOut();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to ExpireCookie()", "AdminController.cs", DataBaseClass.Global.StrLoginName, "LoginModel.cs", "public bool ExpireCookie()");
            }
            return true;
        }
        #endregion
    }
}