using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.MusicStores
{
    public class OrderController : Controller
    {
        MusicDbContext db = new MusicDbContext();
        private readonly IShoppingCartService _cartService;
        private readonly IOrderService _Service;
        private readonly IEntityRepository<Album> _albumService;
        public OrderController(ShoppingCartService cartService,OrderService Service,
            EntityRepository<Album> albumService)
        {
            _cartService = cartService;
            _Service = Service;
            _albumService = albumService;
        }

        /// <summary>
        /// 通过购物车提交订单
        /// </summary>
        /// <returns></returns>
       
        public ActionResult CheckOut()
        {
            var userId = Guid.Parse(_cartService.GetUserId());
            var userName = System.Web.HttpContext.Current.User.Identity.Name;
            var cart = _cartService.GetCart();
            Order order = new Order();
            foreach (var item in cart.Items)
            {
                OrderItem bo = new OrderItem()
                {
                    Id = Guid.NewGuid(),
                    AlbumId = item.AlbumId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                bo.Album = db.Albums.SingleOrDefault(x => x.Id == item.AlbumId);
                order.OrderItems.Add(bo);
                order.UserId = userId;
            }
            db.Orders.Add(order);
            db.SaveChanges();


            _cartService.GetCart();//待确认是不是用此方法



            ViewBag.ResultString = "订单已成功生成";
            return Redirect("Index");
        }


        /// <summary>
        /// 直接购买
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public ActionResult Buy(Guid id,decimal price)
        {
            if(String.IsNullOrEmpty(_cartService.GetUserId()))
            {
                return RedirectToAction("Login", "Account");
            }
            var userId = Guid.Parse(_cartService.GetUserId());
            var userName = System.Web.HttpContext.Current.User.Identity.Name;
            var album = _albumService.GetAll().SingleOrDefault(x => x.Id == id);
            album.Price = price;

            Order order = new Order();
            OrderItem bo = new OrderItem()
            {
                Id = Guid.NewGuid(),
                AlbumId = album.Id,
                Quantity = 1,
                Price = album.Price
            };
            order.OrderItems.Add(bo);
            order.UserId = userId;
            db.Orders.Add(order);
            db.SaveChanges();
            ViewBag.ResultString = "订单已成功生成";
            return RedirectToAction("Index", "Order");
        }
        // GET: Order
        public ActionResult Index()
        {
            var list = _Service.GetOrderList().OrderByDescending(x => x.OrderTime);
            var vmList = new System.Collections.Generic.List<OrderViewModel>();
            var count = 0;
            foreach (var item in list)
            {
                OrderViewModel vm = new OrderViewModel(item);
                vm.OrderNumber = (++count).ToString();
                vmList.Add(vm);
            }
            ViewBag.Title = "订单列表";
            return View(vmList);
        }

        ///删除订单
        ///
        public ContentResult Delete(Guid id)
        {
            string result = "";
            if(id!=null)
            {
                if(_Service.Delete(id))
                {
                    result = "订单删除成功！";
                }
                else
                {
                    result = "订单删除失败！";
                }
            }
            else
            {
                result = "没有找到可删除订单！";
            }
            string scriptString = "<script>alert('" + result + "');window.location.href='/Order/Index';</script>";
            return Content(scriptString);
        }
    }


}