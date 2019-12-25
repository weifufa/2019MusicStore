using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore2019.ViewModels.ExamleDemo
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="姓名是必填字段！")]
        [Display(Name="姓名")]
        public string Name { get; set; }

        [Display(Name = "简介")]
        public string Description { get; set; }

        [Display(Name = "性别")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "用户名是必填字段！")]
        [Display(Name = "用户名")]
        [Remote("LoginNameExaits","ApplicationUser",ErrorMessage ="此用户名已被使用，请换一个用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "昵称是必填字段！")]
        [Display(Name = "昵称")]
        [StringLength(50,MinimumLength =4,ErrorMessage ="昵称长度为4~50个字符为合法昵称")]
        public string NiName { get; set; }

        [Required(ErrorMessage = "出生日期是必填字段！")]
        [Display(Name = "出生日期")]
        [DataType(DataType.Date,ErrorMessage ="请输入正确日期")]
        public DateTime Birthday { get; set; }

        [Display(Name = "年龄")]
        [Range(1,120)]
        public int Age { get; set; }

        [Required(ErrorMessage = "密码是必填字段！")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "密码确认")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="确认密码和密码不一致，请重新输入")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "电子邮箱是必填字段！")]
        [Display(Name = "电子邮箱")]
        [DataType(DataType.EmailAddress,ErrorMessage ="请输入合法的电子邮件")]
        public string Email { get; set; }

        [Display(Name = "贡献度")]
        [Range(typeof(decimal),"0.00","100.00",ErrorMessage ="贡献度合法数值为0.00~100.00之间")]
        public decimal Contribution { get; set; }

        [Display(Name = "建立时间")]
        [ReadOnly(true)]
        public DateTime CreaTine { get; set; }

        [Display(Name = "状态")]
        [EnumDataType(typeof(DataStatus),ErrorMessage ="请输入合法状态值")]
        public DataStatus DataStatus { get; set; }
    }
}