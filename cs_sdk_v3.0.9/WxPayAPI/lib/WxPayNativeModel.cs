using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxPayAPI.lib
{
    public class WxPayNativeModel
    {
        public string body;
        public string attach;
        public string pout_trade_no;
        public string total_fee;
        public string time_start;
        public string time_expire;
        public string goods_tag;
        public string trade_type;
        public string product_id;

        //public WxPayNativeModel MapfJson(string stringJson)
        //{
        //    return stringJson;
          
        //}
    }
}