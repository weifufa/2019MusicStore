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
        public ActionResult Index()
        {
            //var vmCollention = new List<ShoppingCartViewModel>();
            var cart = _cartService.GetCart();//获取购物车
            ShoppingCartViewModel vm = new ShoppingCartViewModel(cart);
            {

            };
            //vmCollention.Add(vm);
            return View(vm);
        }
        public ActionResult Index2()
        {
            return View();
        }
    }
}