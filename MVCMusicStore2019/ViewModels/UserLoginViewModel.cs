using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    /// <summary>
    /// 用户登录视图模型
    /// </summary>
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "登录名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}