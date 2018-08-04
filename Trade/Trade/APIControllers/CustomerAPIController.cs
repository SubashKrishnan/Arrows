using System.Data;
using System.Web.Http;
using Trade.ApiAuth;
using Trade.Models;
namespace Trade.APIControllers
{
    public class CustomerApiController : ApiController
    {
        #region  Declarations
        private readonly CustomerModel obj = new CustomerModel();
        #endregion
        #region  Methods
        [Route("api/CustomerApi/AddUpdateCustomer")]
        [HttpPost]
        public string AddUpdateCustomer(CustomerModel c)
        {
            int IntCustomerStatus = 0;
            string strStatus = "";
            if (c != null)
            {
                obj.IntCustomerID = c.IntCustomerID;
                obj.StrCustomerName = c.StrCustomerName;
                obj.StrCustomerPancard = c.StrCustomerPancard;
                obj.StrCustomerAadhar = c.StrCustomerAadhar;
                obj.StrCustomerMobile = c.StrCustomerMobile;
                obj.StrCustomerEmail = c.StrCustomerEmail;
                obj.StrCustomerAddress = c.StrCustomerAddress;
                obj.IntCustomerIsActive = c.IntCustomerIsActive;
                obj.IntMode = c.IntMode;
                IntCustomerStatus = obj.AddUpdateCustomer();
                if (IntCustomerStatus == 1)
                {
                    strStatus = "Customer Added Successfully!";
                }
                if (IntCustomerStatus == 2)
                {
                    strStatus = "Customer Updated Successfully!";
                }
                if (IntCustomerStatus == 3)
                {
                    strStatus = "Customer Deleted Successfully!";
                }
            }
            return strStatus;
        }
        [Route("api/CustomerApi/GetCustomers")]
        [HttpGet]
        [CompressFilter]
        public DataTable GetCustomers()
        {
            DataTable dt = new DataTable();
            dt = obj.GetCustomers();
            return dt;
        }
        #endregion
    }
}
