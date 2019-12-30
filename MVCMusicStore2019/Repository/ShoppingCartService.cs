using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Repository
{
    public class ShoppingCartService:IShoppingCartService
    {
        public MusicDbContext _context { get; private set; }
        public ShoppingCartService(MusicDbContext context)
        {
            this._context = context;
        }
        public string GetUserId()
        {
            var userName = HttpContext.Current.User.Identity.Name; //取当前用户登录的用户名
            var userId = _context.Users.SingleOrDefault(x => x.UserName == userName).Id;//根据用户名获取用户ID
            return userId;
        }
        public ShoppingCart GetCart()
        {
            var userid = GetUserId();
            //获取当前用户购物车
            var cart = _context.ShoppingCarts.SingleOrDefault(x => x.UserId == userid);
                if(cart!=null)
                {
                cart.Items = GetItems(cart.Id);
                    return cart;
            }
            return null;
        }

        /// <summary>
        /// 获取购物车商品列表
        /// </summary>
        /// <param name="catrId"></param>
        /// <returns></returns>
        public List<ShoppingCartItem> GetItems(string catrId)
        {
            //获取当前用户购物车详单Items
            var entityCollection = _context.ShoppingCarts
                .Where(x => x.Id == catrId)
                .Select(y => y.Items)
                .ToList();
            //获取详单的id
            var entity = entityCollection.Select(x => x.Select(y => y.Id));
            var vmCollection = new List<ShoppingCartItem>();
            //把entityCollection读到vmCollection
            foreach(var items in entityCollection)
            {
               
                foreach(var item in items)
                {
                    ShoppingCartItem bo = new ShoppingCartItem();
                    bo.Id = item.Id;
                    bo.AlbumName = item.AlbumName;
                    bo.Price = item.Price;
                    bo.Quantity = item.Quantity;
                    vmCollection.Add(bo);
                }
            }
            
            return vmCollection;
        }

       public void AddToCart(Guid id, decimal price, string name)
        {
          if(id!=Guid.Empty)
            {
                //查找购物车是否已有该音乐专辑数据
                ShoppingCartItem cartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Id == id);
                if(cartItem!=null)
                {
                    cartItem.Quantity++;
                    _context.SaveChanges();
                }
                else
                {
                    ShoppingCartItem item = new ShoppingCartItem
                    {
                        Id=id,
                        AlbumName=name,
                        Price=price,
                        Quantity=1,
                    };
                    //查找当前用户购物车数据
                    var userId = GetUserId();
                    var cart = _context.ShoppingCarts.SingleOrDefault(x => x.UserId == userId);
                    if(cart!=null)//用户已有购物车数据，但是购物车没有当前专辑数据
                    {
                        cart.Items.Add(item);//思考：为什么要多此一举
                        _context.ShoppingCartItems.Add(item);
                        _context.SaveChanges();
                    }
                    else
                    {
                        ShoppingCart shoppingCart = new ShoppingCart();
                        shoppingCart.UserId = userId;
                        shoppingCart.Items.Add(item);
                        _context.ShoppingCarts.Add(shoppingCart);
                        _context.ShoppingCartItems.Add(item);
                        _context.SaveChanges();
                    }
                }
                
            }
        }

        public bool Delete(Guid id)
        {
            ShoppingCartItem vm = _context.ShoppingCartItems.FirstOrDefault(x => x.Id == id);
            var dbSet = _context.Set(typeof(ShoppingCartItem)); //获取实体的数据集
            bool returnStatus = true; //定义状态值
            var entity = dbSet.Find(id);//根据ID查找数据集中的一条记录
            if (entity == null)
            {
                returnStatus = false;//当查找结果为空值，返回false
                return returnStatus;
            }
            else
            {
                if (returnStatus)
                {
                    try
                    {
                        vm.Quantity--;
                     
                        if (vm.Quantity == 0)
                        {
                            dbSet.Remove(entity);//当查找结果为true，移除本次查找记录
                        }
                        _context.SaveChanges();//存盘、保存
                        return returnStatus;
                    }
                    catch
                    {
                        returnStatus = false;
                    }
                }
            }
            return returnStatus;
        }
    }
}