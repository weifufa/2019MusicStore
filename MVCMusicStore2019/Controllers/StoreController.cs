using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public string Index()
        {
            return "123.Index()";
        }
        public string Browse(int id)
        {
            string message = "当前登录用户编码:" + id;
            return message;
           
        }
    }
}