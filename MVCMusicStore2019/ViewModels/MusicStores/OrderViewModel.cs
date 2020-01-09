using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="序号")]
        public string OrderNumber { get; set; }
        [Display(Name = "交易时间")]
        public DateTime OrderTime { get; set; }
        [Display(Name = "商品数量")]
        public int Quantity { get; set; }
        [Display(Name = "交易金额")]
        public decimal Price { get; set; }
        public OrderViewModel() { }
        public OrderViewModel(Order model)
        {
            this.Id = model.Id;
            this.OrderTime = model.OrderTime;
            if(model.OrderItems!=null)
            {
                this.Quantity = model.OrderItems.Sum(x => x.Quantity);
                this.Price = model.OrderItems.Sum(x => x.Price);
            }
        }
    }
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
       
        public Guid AlbumId { get; set; }//专辑id
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
        [Display(Name = "商品名称")]
        public string AlbumName { get; set; }
        public DateTime OrderTime { get; set; }
        [Display(Name = "商品数量")]
        public int Quantity { get; set; }
        [Display(Name = "交易金额")]
        public decimal Price { get; set; }
        public virtual Order Order { get; set; }//对应订单
        public virtual Album Album { get; set; }
        public OrderItemViewModel()
        {
            this.Id = Guid.NewGuid();
            this.Quantity = 0;
            this.Price = 0.00M;
        }
        public OrderItemViewModel(OrderItem item)
        {
            this.Id = Guid.NewGuid();
            this.AlbumId = item.AlbumId;
            this.Quantity = item.Quantity;
            this.Price = item.Price;
            //get { return this.Price * this.Quantity; }
            //this.Price.Sum(x => x.Price * x.Quantity);
            this.AlbumName = item.Album.Name;
            if (this.Order != null)
            {
                this.Id = item.Order.Id;
                this.Order.UserId = item.Order.UserId;
                this.Quantity = item.Quantity;
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
}