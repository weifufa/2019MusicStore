using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.ViewModels
{
    /// <summary>
    /// 新建用户视图模型
    /// </summary>
    public class AdminCreateUserViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        public string Password { get; set; }
        [Display(Name = "确认密码")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "密码和确认密码必须一致。")]
        public string ConfirmPassword { get; set; }
    }
}