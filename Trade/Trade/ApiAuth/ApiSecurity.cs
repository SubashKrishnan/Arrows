using System.Data;
using Trade.Models;
namespace Trade.ApiAuth
{
    public class ApiSecurity
    {
        #region  Declarations
        private readonly LoginModel objClass = new LoginModel();
        #endregion
        public  bool VaidateUser(string username, string password)
        {
            objClass.StrLogUserName = username;
            objClass.StrLogPassword = password;
            DataTable dt = objClass.Login();
            if (dt.Rows.Count > 0)   
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