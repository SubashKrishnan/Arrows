using System.Data;
using Trade.Models;
namespace Trade.ApiAuth
{
    public class ApiSecurity
    {
        #region  Declarations
        private LoginModel objClass = new LoginModel();
        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();
        #endregion
        public  bool VaidateUser(string username, string password)
        {
            objClass.StrLogUserName = username;
            objClass.StrLogPassword = password;
            dt = objClass.Login();
            // Check if it is valid credential  
            if (dt.Rows.Count > 0)//CheckUserInDB(username, password))  
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}