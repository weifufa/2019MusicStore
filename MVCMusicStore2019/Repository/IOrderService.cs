using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCMusicStore2019.Models.MusicStores;

namespace MVCMusicStore2019.Repository
{
   public interface IOrderService
    {
        List<Order> GetOrderList();
        bool Delete(Guid id);
        List<OrderItem> GetOrderItems();

    }
}
