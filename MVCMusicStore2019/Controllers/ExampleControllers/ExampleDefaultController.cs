using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index(int num1,int num2,string operation)
        {
            int result;
            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 + num2;
                    break;
                case "*":
                    result = num1 + num2;
                    break;
                case "/":
                    result = num1 + num2;
                    break;
                default:
                    Console.Write("输入错误") ;
                    break;
            }
            return View();
        }
    }
}