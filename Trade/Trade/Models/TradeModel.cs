using DataBaseClass;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Trade.Models
{
    public class TradeModel : RepositoryBase
    {
        #region Variables
        public int IntClientID { get; set; }
        public String StrDate { get; set; }
        public float FltCRDR { get; set; }
        public int IntMode { get; set; }
        #endregion
        #region Methods
        public int AddUpdate()
        {
            int IntStatus = 0;
            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[6];
                objSqlParameter[0] = new SqlParameter("@IntClientID", IntClientID);
                objSqlParameter[1] = new SqlParameter("@StrDate", StrDate);
                objSqlParameter[2] = new SqlParameter("@FltCRDR", FltCRDR);
                objSqlParameter[3] = new SqlParameter("@IntStatus", IntStatus);
                objSqlParameter[3].Direction = ParameterDirection.Output;
                objSqlParameter[4] = new SqlParameter("@IntMode", IntMode);
                objSqlParameter[5] = new SqlParameter("@IntLoginID", DataBaseClass.Global.IntLoginID);
                SqlHelper.ExecuteNonQuery(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_AddUpdateTrade", objSqlParameter);
                IntStatus = Convert.ToInt32(objSqlParameter[3].Value);
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public int AddUpdate()", "TradeApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "AddUpdate()");
            }
            return IntStatus;
        }
        public DataTable GetTrades(string StrDate)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] objSqlParameter = new SqlParameter[1];
                objSqlParameter[0] = new SqlParameter("@StrDate", StrDate);
                dt = SqlHelper.ExecuteDataset(objConnection.GetConnection(), CommandType.StoredProcedure, "SP_GetTrades",objSqlParameter).Tables[0];
            }
            catch (Exception ex)
            {
                ExceptionHandling.CatchAndLogError(ex, "Error while trying to public DataTable GetTrades()", "TradeApiController.cs", DataBaseClass.Global.StrLoginName, "ClientModel.cs", "GetTrades()");
            }
            return dt;
        }
        #endregion
    }
}