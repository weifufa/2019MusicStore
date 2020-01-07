﻿using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityRepository<Album> _Service;
        public HomeController(EntityRepository<Album> Service)
        {
            this._Service = Service;
        }
        /// <summary>
        /// 查询用户权限
        /// </summary>
        /// <returns>返回布尔值，真；管理员权限；假，一般用户权限</returns>
        public JsonResult UserRole()
        {
            bool result = false;
            var role = _Service.GetUserRole();//获取当前登录用户权限组
            if (role)
            {
                result = true;
            }
            return Json(result);
        }
        //[Authorize]
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        [Authorize(Roles = "Users")]
        public ActionResult OtherAction()
        {
            return View("Index", GetData("OtherAction"));
        }
        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("User", HttpContext.User.Identity.Name);
            dict.Add("Authenticated", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Auth Type", HttpContext.User.Identity.AuthenticationType);
            dict.Add("In Users Role", HttpContext.User.IsInRole("Users"));
            return dict;
        }
        /// <summary>
        /// 商品特惠
        /// </summary>
        /// <returns>分布视图页，将其嵌入Home/Index中，并实现局部刷新</returns>
        public ActionResult Promotions()
        {
            //在Album数据中随机抽取一条记录为特惠商品
            var promtionAlbum = _Service.GetAll()
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();
            promtionAlbum.Price*= 0.5M;//5折特惠金额
            AlbumDisplayViewModel vm = new AlbumDisplayViewModel(promtionAlbum);
            return PartialView("_Promotions", vm);

        }

    }
}