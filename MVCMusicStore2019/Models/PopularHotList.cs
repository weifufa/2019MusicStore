using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.ViewModels.MusicStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{

    /// <summary>
    /// 人气榜
    /// </summary>
    public class PopularHotList:IEntity
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CTR { get; set; }//点赞数
        public Album Album { get; set; } //音乐关联关系类
        public PopularHotList()
        {
            this.Id = Guid.NewGuid();
            this.CTR = 0;
            this.Name = DateTime.Now.ToShortDateString();//上榜日期
            this.Description = this.Name + "上榜";
        }
        public PopularHotList(AlbumDisplayViewModel vm)
        {
            this.Id = vm.Id;
            this.Name = "热榜名单";
            this.Description = this.Name;
           
        }
    }
}