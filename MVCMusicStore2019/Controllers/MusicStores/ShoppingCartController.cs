using MVCMusicStore2019.Infrastructure;
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
        MusicDbContext db = new MusicDbContext();
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
            var userId = _cartService.GetUserId();
            if (id != Guid.Empty)
            {
                var cart = db.ShoppingCarts.Where(x => x.UserId == userId).FirstOrDefault();

                var cartItems = db.ShoppingCarts.Where(x => x.UserId == userId).SelectMany(x => x.Items);//购物车Items

                var album = _Service.GetAll().Single(x => x.Id == id);//获取购物车

                var item = cartItems.SingleOrDefault(x => x.AlbumId == album.Id);

                //var item = db.ShoppingCartItems.SingleOrDefault(x => x.AlbumId == album.Id);
                if (cart != null)
                {
                    if (item != null)
                    {
                        item.Quantity++;
                    }
                    else
                    {
                        cart.Items = new List<ShoppingCartItem>();
                        ShoppingCartItem entity = new ShoppingCartItem
                        {
                            Id = Guid.NewGuid(),
                            AlbumId=album.Id,
                            AlbumName = album.Name,
                            Quantity = 1,
                            Price = album.Price
                        };
                        cart.Items.Add(entity);
                    }
                }
                else
                {
                    ShoppingCartItem entity = new ShoppingCartItem
                    {
                        Id = Guid.NewGuid(),
                        AlbumId = album.Id,
                        AlbumName = album.Name,
                        Quantity = 1,
                        Price = album.Price,
                    };

                    ShoppingCart bo = new ShoppingCart();
                    bo.UserId = userId;
                    bo.Items.Add(entity);
                    db.ShoppingCarts.Add(bo);
                    db.ShoppingCartItems.Add(entity);
                }
                db.SaveChanges();
            }
            db.Dispose();
            return RedirectToAction("Index");

            //var cart = _cartService.GetCart();//获取购物车
            //var album = _Service.GetAll().Single(x => x.Id == id);//获取专辑信息
            //if(album!=null)
            //    {
            //    _cartService.AddToCart(album.Id, price, album.Name);
            //}
            //else
            //{
            //    ViewBag.Msg = "查无此专辑，请不要非法操作！";
            //}

            //return RedirectToAction("Index");
        }
        // GET: ShoppingCart
        public JsonResult Gteimg(Guid id)
        {
            var Album = _Service.GetAll().SingleOrDefault(x => x.Id == id);
          return Json(Album);
        }
        public ActionResult Index()
        {    //var vmCollention = new List<ShoppingCartItem>();
            var cart = _cartService.GetCart();//获取购物车
            ShoppingCartViewModel vm = new ShoppingCartViewModel(cart);
            if (cart != null)
            {
           
                cart.Items = _cartService.GetItems(cart.Id);
                if (cart.Items.Count() != 0)
                {
                    vm.Items = cart.Items;
                }
            }
        // vm.Items = cart.Items;
            //vmCollention.Add();
            return View(vm);
        }

   /// <summary>
   /// 删除购物车
   /// </summary>
   /// <param name="id"></param>
   /// <returns></returns>
   /// 
   [HttpPost]
   public ContentResult Remove(Guid id)
        {
            var resultString = "";
            ShoppingCart cart = _cartService.GetCart();
            cart.Items = _cartService.GetItems(cart.Id);
            ShoppingCartItem currentItem = cart.Items.FirstOrDefault(x => x.Id == id);
            if(null!=currentItem)
            {
                var item = db.ShoppingCartItems.Where(x => x.Id == currentItem.Id).First();
                db.ShoppingCartItems.Remove(item);
                db.SaveChanges();
                db.Dispose();//清除数据
                resultString = "已成功移除商品!";
            }
            else
            {
                resultString = "商品移除失败！";
            }

           string scriptString = "<script>alert('" + resultString + "');window.location.href='/ShoppingCart/Index';</script>";
            return Content(scriptString);
        }

        /// <summary>
        /// 获取图片专辑链接
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAlbumUrl(Guid id)
        {
            var albums = _Service.GetAll();
            string albumUrl = "";
            if(albums!=null)
            {
                albumUrl = albums.SingleOrDefault(x => x.Id == id).UrlString;
            }
            return albumUrl;
        }

        public JsonResult EmpryCart(string id)
        {
            var cart = _cartService.GetCart();
            if(cart!=null)
            {
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                foreach(var entity in cart.Items)
                {
                    items.Add(db.Set<ShoppingCartItem>().Attach(entity));//将对象读取到上下文
                }
           
            db.ShoppingCartItems.RemoveRange(items);
         
            db.SaveChanges();
            return Json("成功清空购物车！");

            }
            return Json("清空购物车失败！");
        }

        //public ActionResult Delete(Guid id)
        //{
        //    if (id != null)
        //    {
        //        if (_cartService.Delete(id))
        //        {
        //            ViewBag.Message = "删除成功！";

        //        }
        //        else
        //        {
        //            ViewBag.Message = "删除失败";
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "请正确选择需要删除的记录";
        //    }
        //    return View();
        //}
    }
}