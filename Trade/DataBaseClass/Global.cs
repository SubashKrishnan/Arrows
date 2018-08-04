using System;
using System.Web;
namespace DataBaseClass
{
    public class Global
    {
        public static Int32 IntLoginUserID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["IntLoginUserID"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["IntLoginUserID"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["IntLoginUserID"] = value;
                }
            }
        }
        public static Int32 IntLoginUserGroupID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["IntLoginUserGroupID"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["IntLoginUserGroupID"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["IntLoginUserGroupID"] = value;
                }
            }
        }
        public static Int32 IntAdminID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["IntAdminID"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["IntAdminID"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["IntAdminID"] = value;
                }
            }
        }
        public static Int32 IntLoginID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["IntLoginID"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["IntLoginID"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["IntLoginID"] = value;
                }
            }
        }
        public static String StrLoginUserName
        {
            get { return (HttpContext.Current == null || HttpContext.Current.Session["StrLoginUserName"] == null) ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginUserName"]); }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["StrLoginUserName"] = value; }
        }
        public static String StrLoginName
        {
            get { return (HttpContext.Current == null || HttpContext.Current.Session["StrLoginName"] == null) ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginName"]); }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["StrLoginName"] = value; }
        }
        public static String StrGroupName
        {
            get { return (HttpContext.Current == null || HttpContext.Current.Session["StrGroupName"] == null) ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrGroupName"]); }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["StrGroupName"] = value; }
        }
        public static String StrLoginUserFirstName
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["StrLoginUserFirstName"] == null ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginUserFirstName"]); }
            set { HttpContext.Current.Session["StrLoginUserFirstName"] = value; }
        }
        public static String StrLoginUserLastName
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["StrLoginUserLastName"] == null ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginUserLastName"]); }
            set { HttpContext.Current.Session["StrLoginUserLastName"] = value; }
        }
        public static String StrLoginUserImage
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["StrLoginUserImage"] == null ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginUserImage"]); }
            set { HttpContext.Current.Session["StrLoginUserImage"] = value; }
        }
        public static String StrLoginEmailID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["StrLoginEmailID"] == null ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginEmailID"]); }
            set { HttpContext.Current.Session["StrLoginEmailID"] = value; }
        }
        public static String StrLastLoginTimestamp
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["StrLastLoginTimestamp"] == null ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLastLoginTimestamp"]); }
            set { HttpContext.Current.Session["StrLastLoginTimestamp"] = value; }
        }
        public static Int32 LoginLogId
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["intLoginLogId"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["intLoginLogId"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["intLoginLogId"] = value;
                }
            }
        }
        public static String StrLoginIP
        {
            get { return (HttpContext.Current == null || HttpContext.Current.Session["StrLoginIP"] == null) ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrLoginIP"]); }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["StrLoginIP"] = value; }
        }
        public static String StrUserBrowser
        {
            get { return (HttpContext.Current == null || HttpContext.Current.Session["StrUserBrowser"] == null) ? String.Empty : Convert.ToString(HttpContext.Current.Session["StrUserBrowser"]); }
            set { if (HttpContext.Current != null) HttpContext.Current.Session["StrUserBrowser"] = value; }
        }
        public static Int32 IntRoleID
        {
            get { return HttpContext.Current == null || HttpContext.Current.Session["IntRoleID"] == null ? 0 : Convert.ToInt32(HttpContext.Current.Session["IntRoleID"]); }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session["IntRoleID"] = value;
                }
            }
        }
    }
}
