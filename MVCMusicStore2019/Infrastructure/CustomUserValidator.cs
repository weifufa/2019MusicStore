using Microsoft.AspNet.Identity;
using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCMusicStore2019.Infrastructure
{
    public class CustomUserValidator: UserValidator<ApplicationUser>
    {
        public CustomUserValidator(ApplicationUserManager mgr) : base(mgr) { }
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            // 将用户的Email地址限制在lzzy.net主域内，并执行LINQ操作判断
            if (!user.Email.ToLower().EndsWith("@lzzy.net"))
            {
                var errors = result.Errors.ToList();
                errors.Add("仅允许lzzy.net的Email地址进行注册。");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}