using DataBaseClass;
using System;
using System.Data;
using System.Data.SqlClient;
namespace Trade.Models
{
    public class CustomerModel : RepositoryBase
    {
        DBConfiguration dbcon = new DBConfiguration();
        #region Variables
        DataTable dt = new DataTable();
        public int IntCustomerID { get; set; }
        public string StrCustomerName { get; set; }
        public string StrCustomerPancard { get; set; }
        public string StrCustomerAadhar { get; set; }
        public string StrCustomerMobile { get; set; }
        public string StrCustomerEmail { get; set; }
        public string StrCustomerAddress { get; set; }
        public int IntCustomerPlanID { get; set; }
        public int IntCustomerIsActive { get; set; }
        public int IntMode { get; set; }
        #endregion
        #region Methods
        public int AddUpdateCustomer()
        {
            int IntCustomerStatus = 0;
            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[12];
                objSqlParameter[0] = new SqlParameter("@IntCustomerID", IntCustomerID);
                objSqlParameter[1] = new SqlParameter("@StrCustomerName", StrCustomerName);
                objSqlParameter[2] = new SqlParameter("@StrCustomerPancard", StrCustomerPancard);
                objSqlParameter[3] = new SqlParameter("@StrCustomerAadhar", StrCustomerAadhar);
                objSqlParameter[4] = new SqlParameter("@StrCustomerMobile", StrCustomerMobile);
                objSqlParameter[5] = new SqlParameter("@StrCustomerEmail", StrCustomerEmail);
                objSqlParameter[6] = new SqlParameter("@StrCustomerAddress", StrCustomerAddress);
                objSqlParameter[7] = new SqlParameter("@IntCustomerPlanID", IntCustomerPlanID);
                objSqlParameter[8] = new SqlParameter("@IntCustomerIsActive", IntCustomerIsActive);
                objSqlParameter[9] = new SqlParameter("@IntStatus", IntCustomerStatus);
                objSqlParameter[9].Direction = ParameterDirection.Output;
                objSqlParameter[10] = new SqlParameter("@IntMode", IntMode);
                objSqlParameter[11] = new SqlParameter("@IntLoginID", DataBaseClass.Global.IntLoginID);
                SqlHelper.ExecuteNonQuery(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_AddUpdateCustomer", objSqlParameter);
                IntCustomerStatus = Convert.ToInt32(objSqlParameter[9].Value);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public int AddUpdateCustomer()", "CustomerAPIController.cs", DataBaseClass.Global.StrLoginName, "CustomerModel.cs", "AddUpdateCustomer()");
            }
            return IntCustomerStatus;
        }
        public DataTable GetCustomers()
        {
            try
            {
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomers").Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetCustomers()", "CustomerAPIController.cs", DataBaseClass.Global.StrLoginName, "CustomerModel.cs", "GetCustomers()");
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
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetPlans()", "CustomerAPIController.cs", DataBaseClass.Global.StrLoginName, "CustomerModel.cs", "GetPlans()");
            }
            return dt;
        }
        #endregion
    }
}