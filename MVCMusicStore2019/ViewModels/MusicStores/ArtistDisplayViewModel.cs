using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class ArtistDisplayViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "歌手")]
        [Required(ErrorMessage = "该字段不允许为空！")]
        public string Name { get; set; }
        [Display(Name = "歌手说明")]
        [Required(ErrorMessage = "该字段不允许为空！")]
        public string Description { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
    }
}