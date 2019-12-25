using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels.MusicStores
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "流派")]
        [Required(ErrorMessage = "流派不允许为空！")]
        public string Name { get; set; }
        [Display(Name = "流派说明")]
        [Required(ErrorMessage = "流派说明不允许为空！")]
        public string Description { get; set; }

        [Display(Name = "序号")]
        public string OrderNumber { get; set; }

        public GenreViewModel(){ }
        public GenreViewModel(Genre model)
        {
            this.Id = model.Id;
            this.Name = model.Name;
            this.Description = model.Description;
        }
        public void MapToModel(Genre model)
        {
            model.Id= this.Id;
            model.Name = this.Name;
            model.Description = this.Description;
        }
    }
}