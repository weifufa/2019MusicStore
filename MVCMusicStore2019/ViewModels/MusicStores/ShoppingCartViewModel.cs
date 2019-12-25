using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; } //购物车中的条目
        public string Id { get; set; }
        public string UserId { get; set; }//当前登录用户Id
        [Display(Name= "数量")]
        public int TotalQuantity { get; }   //专辑总数量
        [Display(Name = "金额")]
        public decimal TotalPrice { get; }  //总金额
        public ShoppingCartViewModel(){}
        public ShoppingCartViewModel(ShoppingCart model)
        {
            if(Items!=null)
            {
                this.Items = model.Items;
            }
            this.Id = model.Id;
            this.UserId = model.UserId;
            this.TotalQuantity = model.TotalQuantity;
            this.TotalPrice = model.TotalPrice;
        }
    }
}