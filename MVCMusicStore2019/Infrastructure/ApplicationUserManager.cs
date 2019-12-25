using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Infrastructure
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }

        public static ApplicationUserManager Create(
                IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
        {
            MusicDbContext db = context.Get<MusicDbContext>();
            //UserStore<T>IUserStore<T> 接口的Entity Framework实现，
            //提供了UserManager类所定义的存储方法的实现。
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            //manager.PasswordValidator = new PasswordValidator
            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,//Password至少6字符
                RequireNonLetterOrDigit = false,//ture：Password必须含飞字母和数字的字符
                RequireDigit = false,//ture：Password必须含有数字
                RequireLowercase = true,//Password必须含小写字母
                RequireUppercase = true//Password必须含大写字母
            };
            // 通过创建UserValidator实例，对用户进行验证（用户类型：ApplicationUser）
            //manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            return manager;
        }
    }
}