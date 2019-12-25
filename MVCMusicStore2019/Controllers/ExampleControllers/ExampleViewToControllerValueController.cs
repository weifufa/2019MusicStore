using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    public class ExampleViewToControllerValueController : Controller
    {
        // GET: ExampleViewToControllerValue
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["theme"] ?? new HttpCookie("theme", "default");
            ViewBag.Theme = cookie.Value;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string theme)
        {
            HttpCookie cookie = new HttpCookie("theme",theme);
            cookie.Expires = DateTime.MaxValue;
            Response.SetCookie(cookie);
            ViewBag.Theme = theme;
            return View();
        }
        public ActionResult Css()
        {
            HttpCookie cookie = Request.Cookies["theme"] ?? new HttpCookie("theme", "default");
            switch (cookie.Value)
            {
                case "Theme1":return Content("body{font-family:SimHei;font-size:1.2em;}", "text/css");
                case "Theme2": return Content("body{font-family:KaiTi;font-size:1.2em;}", "text/css");
                default: return Content("body{font-family:SimSong;font-size:1.2em;}", "text/css");
            }
        }
    }
}