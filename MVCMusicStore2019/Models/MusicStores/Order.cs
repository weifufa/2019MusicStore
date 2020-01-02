using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStores
{
    /// <summary>
    /// 订单列表
    /// </summary>
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }//专辑id
        public int Quantity { get; set; }//数量
        public virtual Order Order { get; set; }//对应订单
        public virtual Album Album { get; set; }
        //是否需要专辑的外键
        public OrderItem()
        {
            this.Id = Guid.NewGuid();
            this.Quantity = 0;
        }
        public OrderItem(OrderItem item)
        {
            this.Id = Guid.NewGuid();
            this.AlbumId = item.AlbumId;
            this.Quantity = 0;
            if (this.Order!=null)
            {
                this.Id = item.Order.Id;
                this.Order.UserId = item.Order.UserId;
                this.Order.OrderTime = item.Order.OrderTime;
            }
            if (this.Album != null)
            {
                this.Id = item.Album.Id;
                this.Album.Name = item.Album.Name;
                this.Album.Price = item.Album.Price;
                this.Album.UrlString = item.Album.UrlString;
            }
        }
    }
    /// <summary>
    /// 订单类
    /// </summary>
    public class Order
    {
        public Guid Id { get; set; }//订单编号
        public Guid UserId { get; set; }//待商劵
        public DateTime OrderTime { get; set; }//订单生成时间
        public bool OrderStatus { get; set; }//订单状态，默认值：true,
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public Order()
        {
       
            this.Id = Guid.NewGuid();
            this.OrderTime = DateTime.Now;
            this.OrderStatus = true;
            this.OrderItems = new HashSet<OrderItem>();
        }
        public Order(Order order)
        {
            this.Id = Guid.NewGuid();
            this.UserId = order.UserId;
            this.OrderTime = order.OrderTime;
            this.OrderStatus = order.OrderStatus;

        }
    }
}