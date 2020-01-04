using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class AlbumDisplayViewModel
    {
        public Guid Id { get; set; } //编号
        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
        [Required(ErrorMessage = "名称是必填字段！")]
        [Display(Name = "专辑名称")]
        public string Name { get; set; }//名称

        [Display(Name = "专辑介绍")]
        public string Description { get; set; }//简介    


        public Guid GenreId { get; set; } //流派id
        [Display(Name = "流派")]
        public string GenreName { get; set; }


        public Guid AlbumTypeId { get; set; } //类型id
        [Display(Name = "专辑类型")]
        public string AlbumTypeName { get; set; }


        public Guid ArtistId { get; set; }//歌手id
        [Display(Name = "歌手")]
        public string ArtistName { get; set; }


        [Required(ErrorMessage = "发行日期是必填字段！")]
        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确发行日期")]
        public DateTime IssueTime { get; set; } //发行日期

        [Required(ErrorMessage = "发行人是必填字段！")]
        [Display(Name = "唱片公司")]
        public string IssueUser { get; set; }//发行人

        [Display(Name = "语种")]
        public string LanguageClassification { get; set; } //语种

        [Display(Name = "价格")]
        [DataType(DataType.Currency, ErrorMessage = "请输入合法的价格")]
        [Range(typeof(decimal), "0.00", "100.00", ErrorMessage = "贡献度合法数值为0.00~100.00之间")]
        public decimal Price { get; set; }  //价格

        [Display(Name = "封面链接")]
        public string UrlString { get; set; }

        public List<Genre> GenreItem { get; set; }
        public List<AlbumType> AlbumTypeItem { get; set; }
        public List<Artist> ArtistItem { get; set; }
        public AlbumDisplayViewModel() {
            this.IssueTime = DateTime.Now;
        }
        public AlbumDisplayViewModel(Album model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
            this.IssueTime = model.IssueTime;
            this.IssueUser = model.IssueUser;
            this.LanguageClassification = model.LanguageClassification;
            this.Price = model.Price;
            this.UrlString = model.UrlString;
            //if (model.Genre != null)
            //{
            //    this.GenreId = model.Genre.Id;
            //    this.GenreName = model.Genre.Name;
            //}
            //if (model.AlbumType != null)
            //{
            //    this.AlbumTypeId = model.AlbumType.Id;
            //    this.AlbumTypeName = model.AlbumType.Name;
            //}
            //if (model.Artist != null)
            //{
            //    this.ArtistId = model.Artist.Id;
            //    this.ArtistName = model.Artist.Name;
            //}
        }

    }



    public class AlbumViewModel
    {
        public Guid Id { get; set; } //编号

        [Required(ErrorMessage = "名称是必填字段！")]
        [Display(Name = "专辑名称")]
        public string Name { get; set; }//名称

        [Display(Name = "专辑介绍")]
        public string Description { get; set; }//简介    


        public Guid GenreId { get; set; } //流派id
        [Display(Name = "流派")]
        public string GenreName { get; set; }


        public Guid AlbumTypeId { get; set; } //类型id
        [Display(Name = "专辑类型")]
        public string AlbumTypeName { get; set; }


        public Guid ArtistId { get; set; }//歌手id
        [Display(Name = "歌手")]
        public string ArtistName { get; set; }


        [Required(ErrorMessage = "发行日期是必填字段！")]
        [Display(Name = "发行日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确发行日期")]
        public DateTime IssueTime { get; set; } //发行日期

        [Required(ErrorMessage = "发行人是必填字段！")]
        [Display(Name = "唱片公司")]
        public string IssueUser { get; set; }//发行人

        [Display(Name = "语种")]
        public string LanguageClassification { get; set; } //语种

        [Display(Name = "价格")]
       [Range(typeof(decimal), "0.00", "100.00", ErrorMessage = "合法价格为0.00~100.00之间")]
        public decimal Price { get; set; }  //价格

        [Display(Name = "封面链接")]
        public string UrlString { get; set; }

        public List<Genre> GenreItem { get; set; }
        public List<AlbumType> AlbumTypeItem { get; set; }
        public List<Artist> ArtistItem { get; set; }
        public AlbumViewModel()
        {
            this.IssueTime = DateTime.Now;
        }
        public AlbumViewModel(Album model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;     
            this.IssueTime = model.IssueTime;
            this.IssueUser = model.IssueUser;
            this.LanguageClassification = model.LanguageClassification;
            this.Price = model.Price;
            if (model.Genre!=null)
            {
                this.GenreId = model.Genre.Id;
                this.GenreName = model.Genre.Name;
            }
            if (model.AlbumType!=null)
            {
                this.AlbumTypeId = model.AlbumType.Id;
                this.AlbumTypeName = model.AlbumType.Name;
            }
            if (model.Artist!=null)
            {
                this.ArtistId = model.Artist.Id;
                this.ArtistName = model.Artist.Name;
            }
        }
        public void MapToModel(AlbumViewModel model)
        {
            AlbumViewModel entity = new AlbumViewModel();
            model.Id = entity.Id;
            model.Name= entity.Name;
            model.Description= entity.Description;
            model.GenreId= entity.GenreId ;
            model.AlbumTypeId= entity.AlbumTypeId ;
            model.ArtistId= entity.ArtistId;
            model.IssueTime= entity.IssueTime;
            model.IssueUser= entity.IssueUser ;
            model.LanguageClassification= entity.LanguageClassification;
            model.Price= entity.Price;
        }
    }
   
}