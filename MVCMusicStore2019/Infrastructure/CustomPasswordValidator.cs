using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCMusicStore2019.Infrastructure
{
    public class CustomPasswordValidator: PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string pass)
        {
            IdentityResult result = await base.ValidateAsync(pass);
            //如果Password中包含"12345"字串，则验证错误，此处的判断条件使用了LINQ
            if (pass.Contains("12345"))
            {
                var errors = result.Errors.ToList();
                errors.Add("密码不能是连续的数字。");
                // 如果想报告验证错误，必须创建一个新实例，将错误提示和IdentityResult基实现联系
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}