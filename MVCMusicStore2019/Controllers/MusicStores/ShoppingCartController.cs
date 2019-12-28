using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.MusicStores
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IEntityRepository<Album> _Service;
        public ShoppingCartController(IShoppingCartService cartService,
            IEntityRepository<Album> service)
        {
            this._cartService = cartService;
            this._Service = service;
        }
        public ActionResult AddToCart(Guid id,decimal price,string name)
        {
            var cart = _cartService.GetCart();//获取购物车
            var album = _Service.GetAll().Single(x => x.Id == id);//获取专辑信息
            if(album!=null)
                {
                _cartService.AddToCart(album.Id, price, album.Name);
            }
            else
            {
                ViewBag.Msg = "查无此专辑，请不要非法操作！";
            }
           
            return RedirectToAction("Index");
        }
        // GET: ShoppingCart
        public JsonResult Gteimg(Guid id)
        {
            var Album = _Service.GetAll().SingleOrDefault(x => x.Id == id);
          return Json(Album);
        }
        public ActionResult Index()
        {
            //var vmCollention = new List<ShoppingCartItem>();
            var cart = _cartService.GetCart();//获取购物车
            ShoppingCartViewModel vm = new ShoppingCartViewModel(cart);
            {
               
            };
            vm.Items = cart.Items;
            //vmCollention.Add();
            return View(vm);
        }

   

    public ActionResult Delete(Guid id)
    {
        if (id != null)
        {
            if (_cartService.Delete(id))
            {
                ViewBag.Message = "删除成功！";

            }
            else
            {
                ViewBag.Message = "删除失败";
            }
            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Message = "请正确选择需要删除的记录";
        }
        return View();
    }
}
}