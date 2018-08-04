using System.Data;
using System.Web.Http;
using Trade.ApiAuth;
using Trade.Models;
namespace Trade.APIControllers
{
    public class ClientApiController : ApiController
    {
        #region  Declarations
        private readonly ClientModel obj = new ClientModel();
        #endregion
        #region  Methods
        [Route("api/ClientApi/AddUpdate")]
        [HttpPost]
        public string AddUpdate(ClientModel c)
        {
            int IntStatus = 0;
            string strStatus = "";
            if (c != null)
            {
                obj.IntClientID = c.IntClientID;
                obj.StrClientCode = c.StrClientCode;
                obj.IntCustomerID = c.IntCustomerID;
                obj.FltInvestmentAmount = c.FltInvestmentAmount;
                obj.IntClientPlanID = c.IntClientPlanID;
                obj.IntReference_ClientID = c.IntReference_ClientID;
                obj.IntClientIsActive = c.IntClientIsActive;
                obj.IntMode = c.IntMode;
                IntStatus = obj.AddUpdate();
                if (IntStatus == 1)
                {
                    strStatus = "Client Added Successfully!";
                }
                if (IntStatus == 2)
                {
                    strStatus = "Client Updated Successfully!";
                }
                if (IntStatus == 3)
                {
                    strStatus = "Client Deleted Successfully!";
                }
                if (IntStatus == 4)
                {
                    strStatus = "Client Code Already Exist!";
                }
            }
            return strStatus;
        }
        [Route("api/ClientApi/GetClients")]
        [HttpGet]
        [CompressFilter]
        public DataTable GetClients()
        {
            DataTable dt = obj.GetClients();
            return dt;
        }
        [Route("api/ClientApi/GetCustomers")]
        [HttpGet]
        [CompressFilter]
        public DataTable GetCustomers()
        {
            DataTable dt = obj.GetCustomers();
            return dt;
        }
        [Route("api/ClientApi/GetPlans")]
        [HttpGet]
        [CompressFilter]
        public DataTable GetPlans()
        {

            DataTable dt = obj.GetPlans();
            return dt;
        }
        [Route("api/ClientApi/GetReferences")]
        [HttpGet]
        [CompressFilter]
        public DataTable GetReferences()
        {
            DataTable dt = obj.GetReferences();
            return dt;
        }
        #endregion
    }
}
