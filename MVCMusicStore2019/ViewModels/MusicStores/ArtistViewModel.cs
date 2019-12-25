using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class ArtistViewModel
    {
        [Display(Name = "歌手ID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "该字段不允许为空！")]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "该字段不允许为空！")]
        [Display(Name = "歌手简介")]
        public string Description { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
        public ArtistViewModel()
        {
        }
        public ArtistViewModel(Artist model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Artist model)
        {
            model.Id = this.Id;
            model.Name = this.Name;
            model.Description = this.Description;
        }
    }
}