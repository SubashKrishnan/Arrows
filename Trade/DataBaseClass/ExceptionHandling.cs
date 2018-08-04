using System;
using System.Data;
using System.Data.SqlClient;
namespace DataBaseClass
{
    public class ExceptionHandling : RepositoryBase
    {
        DBConfiguration dbcon = new DBConfiguration();
        #region Variables
        public int ExceptionId { get; set; }
        public string PageName { get; set; }
        public string UserAgent { get; set; }
        public string ClientIP { get; set; }
        public string ClientLoginName { get; set; }
        public string ExceptionDate { get; set; }
        public DataTable dtException { get; set; }
        public int TotalExceptions { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public string ExceptionIds { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public String ExceptionText { get; set; }
        public String CustomMessage { get; set; }
        public int EmployeeID { get; set; }
        #endregion
        #region Methods
        public ExceptionHandling InsertException(ExceptionHandling objExceptionHandling)
        {
            try
            {
                SqlParameter[] objParam = new SqlParameter[9];
                objParam[0] = new SqlParameter("@PageName", objExceptionHandling.PageName);
                objParam[1] = new SqlParameter("@ClassName", objExceptionHandling.ClassName);
                objParam[2] = new SqlParameter("@MethodName", objExceptionHandling.MethodName);
                objParam[3] = new SqlParameter("@ExceptionMessage", objExceptionHandling.ExceptionText);
                objParam[4] = new SqlParameter("@CustomMessage", objExceptionHandling.CustomMessage);
                objParam[5] = new SqlParameter("@UserAgent", objExceptionHandling.UserAgent);
                objParam[6] = new SqlParameter("@ClientIP", objExceptionHandling.ClientIP);
                objParam[7] = new SqlParameter("@ClientLoginName", objExceptionHandling.ClientLoginName);
                objParam[8] = new SqlParameter("@EmployeeID", objExceptionHandling.EmployeeID);
                SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "InsertException", objParam);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to InsertException(ExceptionHandling objExceptionHandling)", "CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName).cs", Global.StrLoginName, "CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName).cs", "InsertException(ExceptionHandling objExceptionHandling)");
            }
            return objExceptionHandling;
        }
        public static void CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName)
        {
            try
            {
                ExceptionHandling objException = new ExceptionHandling();
                objException.PageName = sPageName;
                objException.ExceptionText = ex.Message;
                objException.CustomMessage = sMessage;
                objException.PageName = sPageName;
                objException.ClientLoginName = sUserName;
                objException.ClientIP   = Global.StrLoginIP;
                objException.UserAgent  = Global.StrUserBrowser;
                objException.EmployeeID = Global.IntLoginID;
                objException.ClassName = sClassName;
                objException.MethodName = sMethodName;
                (new ExceptionHandling()).InsertException(objException);
            }
            catch (Exception exx)
            {
                ExceptionHandling.CatchAndLogError(exx, "Error while trying to CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName)", "CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName).cs", Global.StrLoginName, "CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName).cs", "CatchAndLogError(Exception ex, String sMessage, String sPageName, String sUserName, String sClassName, String sMethodName)");
            }
        }
        #endregion
    }
}
