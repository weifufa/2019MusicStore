using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.Controllers.ExampleControllers
{
    /// <summary>
    /// 购物车类定义
    /// </summary>
    /// 
    public class ShoppingCart : List<ShoppingCartItem> { }
    /// <summary>
    /// 购物车商品类
    /// </summary>
    /// 
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    public class ExampleJavaScriptResultApplicationController : Controller
    {
        private static Dictionary<Guid, int> stock = new Dictionary<Guid, int>();
        private static Guid stockA = Guid.NewGuid(), stockB = Guid.NewGuid(), stockC = Guid.NewGuid();
        // GET: ExampJavaScriptResultApplication
        static ExampleJavaScriptResultApplicationController()
        {
            stock.Add(stockA,10);
            stock.Add(stockB,1000);
            stock.Add(stockC,10);
        }
        /// <summary>
        /// 库存检查
        /// </summary>
        private bool CheckStock(Guid id, int quantity)
        {
            return stock[id] > quantity;
        }
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.Add(new ShoppingCartItem { Id = stockA,Quantity = 2, Name = "Air Jrodan篮球鞋"});
            cart.Add(new ShoppingCartItem { Id = stockB, Quantity = 1, Name = "Fashion衣服"});
            cart.Add(new ShoppingCartItem { Id = stockC, Quantity = 3, Name = "空军一号鞋子"});
            return View(cart);
        }
        public ActionResult ProcessOrder(ShoppingCart cart)
        {
            StringBuilder sbd = new StringBuilder(); 
            //库存检查
            foreach (var carItem in cart)
            {
                //判断库存的数量（Quantity）是否大于id的数量
                if (!CheckStock(carItem.Id, carItem.Quantity))
                {
                    sbd.Append(string.Format("{0}:{1}", carItem.Name, stock[carItem.Id]));
                }
            }
            if (string.IsNullOrEmpty(sbd.ToString()))
            {
                return Content("alert('您的订单已成功处理！')","text/javascript");
            }
            string scriptString = string.Format("alert('库存不足({0})')",sbd.ToString().TrimEnd(';'));
            return JavaScript(scriptString);
        }
    }
}