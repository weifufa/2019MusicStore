using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    public class Student : IEntity
    {
        [Key]//主键
        public Guid Id{get; set;}
        public string Name{get;set;}
        public string Description {get;set;}
        public bool Gender { get; set; }
        public string UserName { get; set; }
        public string NiName { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public decimal Contribution { get; set; }
        public DateTime CreaTine { get; set; }
        public DataStatus DataStatus { get; set; }

    }
    public enum DataStatus
    {
            合法用户,
            非法用户,
            冻结用户
    }
}