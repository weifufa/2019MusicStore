using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class AlbumTypeDisplayViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "音乐类型")]
        public string Name { get; set; }

        [Required(ErrorMessage = "该字段不允许为空！")]
        [Display(Name = "类型描述")]
        public string Description { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }
    }
}