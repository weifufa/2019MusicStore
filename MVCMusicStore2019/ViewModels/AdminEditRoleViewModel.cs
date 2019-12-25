using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    public class AdminEditRoleViewModel
    {
        [Display(Name = "角色")]
        public ApplicationRole Role { get; set; }
        [Display(Name = "会员")]
        public IEnumerable<ApplicationUser> Members { get; set; }
        [Display(Name = "非会员")]
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }
    public class AdminModificationRoleModel
    {
        [Required]
        [Display(Name = "角色名")]
        public string RoleName { get; set; }
        [Display(Name = "添加用户")]
        public string[] IdsToAdd { get; set; }
        [Display(Name = "删除用户")]
        public string[] IdsToDelete { get; set; }
    }
}