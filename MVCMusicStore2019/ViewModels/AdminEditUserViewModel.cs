using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    /// <summary>
    /// 修改用户视图模型
    /// </summary>
    public class AdminEditUserViewModel
    {
        [Display(Name = "用户ID")]
        public string Id { get; set; }
        [Display(Name = "用户名")]
        public string Name { get; set; }
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        public string Password { get; set; }
        public AdminEditUserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.UserName;
        }
    }
}