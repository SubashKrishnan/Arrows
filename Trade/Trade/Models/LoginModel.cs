using DataBaseClass;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Trade.Models
{
    public class LoginModel : RepositoryBase
    {
        DBConfiguration dbcon = new DBConfiguration();
        #region Variables
        public string StrLogEmail { get; set; }
        public string StrLogUserName { get; set; }
        public string StrLogPassword { get; set; }
        public string StrLoginIP { get; set; }
        public string StrUserAgent { get; set; }
        public int IntStatus { get; set; }
        public int IntLoginID { get; set; }
        #endregion
        #region Methods
        public DataTable Login()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] objParam = new SqlParameter[6];
                objParam[0] = new SqlParameter("@VAR_UserName", StrLogUserName);
                objParam[1] = new SqlParameter("@VAR_Password", StrLogPassword);
                ds = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_LoginCheck", objParam);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to Login()", "HomeController.cs", DataBaseClass.Global.StrLoginName, "indexModel.cs", "Login()");
            }
            return ds.Tables[0];
        }
        public DataTable GetDetailsByID()
        {
            DataTable dt = new DataTable();
            try
            {
               
                dt = dbcon.Execute_Query("UPDATE USERS SET LAST_LOGIN=GETDATE() WHERE ID=" + IntLoginID + "; select US.ID,US.NAME,US.USERNAME,US.MOBILE,US.LAST_LOGIN,US.ISACTIVE from USERS  US where US.ID=" + IntLoginID + "", "USERS").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to GetDetailsByID()", "HomeController.cs", DataBaseClass.Global.StrLoginName, "indexModel.cs", "GetDetailsByID()");
            }
            return dt;
        }
        #endregion
    }
}