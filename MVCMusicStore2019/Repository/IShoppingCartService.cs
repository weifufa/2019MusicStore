using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMusicStore2019.Repository
{
    /// <summary>
    /// 购物车接口组件
    /// </summary>
   public interface IShoppingCartService
    {
        ShoppingCart GetCart();//获取当前用户的购物车
        void AddToCart(Guid id, decimal price, string name);
        bool Delete(Guid id);//根据ID删除一条记录
        string GetUserId();//根据用户查找ID 
        List<ShoppingCartItem> GetItems(string catrId);

    }
}
