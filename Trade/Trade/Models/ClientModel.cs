using DataBaseClass;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Trade.Models
{
    public class ClientModel : RepositoryBase
    { 
        #region Variables
        DataTable dt = new DataTable();
        public int IntClientID { get; set; }
        public string StrClientCode { get; set; }
        public int IntCustomerID { get; set; }
        public float FltInvestmentAmount { get; set; }
        public int IntClientPlanID { get; set; }
        public int IntReference_ClientID { get; set; }
        public int IntClientIsActive { get; set; }
        public int IntMode { get; set; }
        #endregion
        #region Methods
        public int AddUpdate()
        {
            int IntStatus = 0;
            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[10];
                objSqlParameter[0] = new SqlParameter("@IntClientID", IntClientID);
                objSqlParameter[1] = new SqlParameter("@StrClientCode", StrClientCode);
                objSqlParameter[2] = new SqlParameter("@IntCustomerID", IntCustomerID);
                objSqlParameter[3] = new SqlParameter("@FltInvestmentAmount", FltInvestmentAmount);
                objSqlParameter[4] = new SqlParameter("@IntClientPlanID", IntClientPlanID);
                objSqlParameter[5] = new SqlParameter("@IntReference_ClientID", IntReference_ClientID);
                objSqlParameter[6] = new SqlParameter("@IntClientIsActive", IntClientIsActive);
                objSqlParameter[7] = new SqlParameter("@IntStatus", IntStatus);
                objSqlParameter[7].Direction = ParameterDirection.Output;
                objSqlParameter[8] = new SqlParameter("@IntMode", IntMode);
                objSqlParameter[9] = new SqlParameter("@IntLoginID", DataBaseClass.Global.IntLoginID);
                SqlHelper.ExecuteNonQuery(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_AddUpdateClient", objSqlParameter);
                IntStatus = Convert.ToInt32(objSqlParameter[7].Value);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public int AddUpdate()", "ClientApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "AddUpdate()");
            }
            return IntStatus;
        }
        public DataTable GetClients()
        {
            try
            {
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetClients").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetClients()", "ClientApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "GetClients()");
            }
            return dt;
        }
        public DataTable GetCustomers()
        {
            try
            {
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomers").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetCustomers()", "ClientApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "GetCustomers()");
            }
            return dt;
        }
        public DataTable GetPlans()
        {
            try
            {
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetPlans").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetPlans()", "ClientApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "GetPlans()");
            }
            return dt;
        }
        public DataTable GetReferences()
        {
            try
            {
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetReferences").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetReferences()", "ClientApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "GetReferences()");
            }
            return dt;
        }
        #endregion
    }
}