using System.Data;
using System.Web.Http;
using Trade.Models;
namespace Trade.APIControllers
{
    public class CustomerAPIController : ApiController
    {
        #region  Declarations
        private CustomerModel obj = new CustomerModel();
        private DataTable dt = new DataTable();
        #endregion
        #region  Methods
        //[Route("CustomerAPI/AddUpdateCustomer")]
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
                obj.IntCustomerPlanID = c.IntCustomerPlanID;
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
        //[Route("CustomerAPI/GetCustomers")]
        //[HttpGet]
        public DataTable GetCustomers()
        {
            dt = obj.GetCustomers();
            return dt;
        }
        //[Route("CustomerAPI/GetPlans")]
        //[HttpGet]
        public DataTable GetPlans()
        {
            dt = obj.GetPlans();
            return dt;
        }
        #endregion
    }
}
