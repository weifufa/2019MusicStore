using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models.MusicStores
{
    /// <summary>
    /// 专辑类
    /// </summary>
    public class Album:IEntity
    {
        public Guid Id { get; set; } //编号
        public string Name{ get; set; }//名称
        public string Description { get; set; }//简介    
        public Guid GenreId { get; set; } //流派id
        public Guid AlbumTypeId { get; set; } //类型id
        public Guid ArtistId { get; set; }//歌手id
        public DateTime IssueTime { get; set; } //发行日期
        public string IssueUser { get; set; }//发行人
        public string LanguageClassification { get; set; } //语种
        public decimal Price { get; set; }  //价格
        public virtual Genre Genre{ get; set; } //流派
        public virtual AlbumType AlbumType { get; set; } //类型
        public virtual Artist Artist { get; set; }//歌手
        public string UrlString { get; set; }
        public Album()
        {
            this.Id = Guid.NewGuid();
            this.IssueTime = DateTime.Now;
            this.Price = 0.00M;
        }
        public Album(Album bo)
        {
            this.Id = bo.Id;
            this.Name = bo.Name;
            this.Description = bo.Description;
            this.IssueTime = bo.IssueTime;
            this.IssueUser = bo.IssueUser;
            this.LanguageClassification = bo.LanguageClassification;
            this.Price = bo.Price;
            this.UrlString = bo.UrlString;
            if (Genre!=null)
            {
                this.GenreId = bo.Genre.Id;
                this.Genre.Id = bo.Genre.Id;
                this.Genre.Name = bo.Genre.Name;
                this.Genre.Description = bo.Genre.Description;
            }
            if (AlbumType != null)
            {
                this.AlbumTypeId = bo.AlbumType.Id;
                this.AlbumType.Id = bo.AlbumType.Id;
                this.AlbumType.Name = bo.AlbumType.Name;
                this.AlbumType.Description = bo.AlbumType.Description;
            }
            if (Artist != null)
            {
                this.ArtistId = bo.Artist.Id;
                this.Artist.Id = bo.Artist.Id;
                this.Artist.Name= bo.Artist.Name;
                this.Artist.Description = bo.Artist.Description;
            }
        }      
    }
}