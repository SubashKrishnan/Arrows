using DataBaseClass;
using System;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Trade.Models;
namespace Trade.Controllers
{
    public class LoginController : Controller
    {
        #region  Declarations
        private LoginModel objClass = new LoginModel();
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        #endregion
        #region Action Results
        public ActionResult Index()
        {
            objClass.IntLoginID = DataBaseClass.Global.IntLoginID;
            if (objClass.IntLoginID != 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        #endregion
        #region Post Methods
        [Route("Login/Login")]
        [HttpPost]
        public JsonResult Login(LoginModel Login)
        {
            try
            {
                //System.Threading.Thread.Sleep(1);
                objClass.StrLogUserName = Login.StrLogUserName.Trim();
                objClass.StrLogPassword = Login.StrLogPassword.Trim();
                objClass.StrUserAgent = Request.UserAgent;
                objClass.StrLoginIP = Request.UserHostAddress;
                dt = objClass.Login();
                if (dt.Rows.Count > 0)
                {
                    int IsActive = Convert.ToInt32(dt.Rows[0]["ISACTIVE"].ToString());
                    if (IsActive == 1)
                    {
                        int IntLoginID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        CreateUserCookiesLogin(IntLoginID);
                        Login.IntStatus = 1;
                    }
                    else
                    {
                        Login.IntStatus = 2;
                    }
                }
                else
                {
                    Login.IntStatus = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to Login(LoginModel Login)", "LoginController.cs", DataBaseClass.Global.StrLoginName, "LoginModel.cs", "public JsonResult Login(LoginModel Login)");
            }
            return Json(Login);
        }
        #endregion
        #region  Methods
        private void CreateUserCookiesLogin(int intUserID)
        {
            try
            {
                objClass.IntLoginID = intUserID;
                DataTable dt = objClass.GetDetailsByID();
                if (dt != null)
                {
                    HttpCookie LoginCookies = new HttpCookie("StockOrion");
                    LoginCookies.Values.Add("LoginID", dt.Rows[0]["ID"].ToString());
                    LoginCookies.Values.Add("LoginName", dt.Rows[0]["NAME"].ToString());
                    LoginCookies.Values.Add("LoginUserName", dt.Rows[0]["UserName"].ToString());
                    LoginCookies.Expires = System.DateTime.Now.AddYears(1);
                    System.Web.HttpContext.Current.Response.Cookies.Add(LoginCookies);
                    DataBaseClass.Global.IntLoginID = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    DataBaseClass.Global.StrLoginName = dt.Rows[0]["NAME"].ToString();
                    DataBaseClass.Global.StrLoginUserName = dt.Rows[0]["UserName"].ToString();
                    DataBaseClass.Global.StrUserBrowser = Request.UserAgent;
                    DataBaseClass.Global.StrLoginIP = Request.UserHostAddress;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to CreateUserCookiesLogin(int IntUserID)", "LoginController.cs", DataBaseClass.Global.StrLoginName, "LoginModel.cs", "private void CreateUserCookiesLogin(int intUserID)");
            }
        }
        #endregion
    }
}