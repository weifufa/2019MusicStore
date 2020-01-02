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
                this.Price = model.OrderItems.Sum(x => x.Album.Price);
            }
        }
    }
}