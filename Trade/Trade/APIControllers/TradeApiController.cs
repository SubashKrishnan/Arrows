using System.Data;
using System.Web.Http;
using Trade.ApiAuth;
using Trade.Models;

namespace Trade.APIControllers
{
    public class TradeApiController : ApiController
    {
        #region  Declarations
        private readonly TradeModel obj = new TradeModel();
        #endregion
        #region  Methods
        [Route("api/TradeApi/AddUpdate")]
        [HttpPost]
        public string AddUpdate(TradeModel t)
        {
            int IntStatus = 0;
            string strStatus = "";
            if (t != null)
            {
                obj.IntClientID = t.IntClientID;
                obj.StrDate = t.StrDate;
                obj.FltCRDR = t.FltCRDR;
                obj.IntMode = t.IntMode;
                IntStatus = obj.AddUpdate();
                if (IntStatus == 1)
                {
                    strStatus = "Trade Added Successfully!";
                }
                if (IntStatus == 2)
                {
                    strStatus = "Trade Updated Successfully!";
                }
                if (IntStatus == 3)
                {
                    strStatus = "Trade Deleted Successfully!";
                }
            }
            return strStatus;
        }
        [Route("api/TradeApi/GetTrades")]
        [HttpPost]
        [CompressFilter]
        public DataTable GetTrades(TradeModel t)
        {
            string StrDate="";
            if (t != null)
            {
                if(t.StrDate != null)
                {
                    StrDate = t.StrDate;
                }
                else
                {
                    StrDate = System.DateTime.Today.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                StrDate = System.DateTime.Today.ToString("dd/MM/yyyy");
            }
            DataTable dt = obj.GetTrades(StrDate);
            return dt;
        }
        #endregion
    }
}
