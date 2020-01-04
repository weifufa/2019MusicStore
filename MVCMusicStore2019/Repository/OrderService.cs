using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Repository
{
    public class OrderService:IOrderService
    {
        MusicDbContext db = new MusicDbContext();
        private readonly IShoppingCartService _cartService;
        private readonly IEntityRepository<Album> _Service;
        //public MusicDbContext _context { get; set; }
        //public OrderService(MusicDbContext context)
        //{
        //    this._context = context;
        //}
        public bool Delete(Guid id)
        {
            var dbSet = db.Set(typeof(Order));//获取Order数据集
            bool result = true;
            var entity = dbSet.Find(id);
            if(entity==null)
            {
                result = false;
                return result;//删除失败
            }
            else
            {
                if(result)
                {
                    try
                    {
                        var bo = db.Orders.SingleOrDefault(x => x.Id == id);
                        bo.OrderStatus = false;
                        db.SaveChanges();
                        result = true;
                        return result;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public List<Order> GetOrderList()
        {
            var userId = Guid.Parse(_cartService.GetUserId());
            var userName = HttpContext.Current.User.Identity.Name;
            var order = db.Orders
                .Where(x => x.UserId == userId)
                .Where(y => y.OrderStatus == true)
                .ToList();
            return order;
        }
    }
}