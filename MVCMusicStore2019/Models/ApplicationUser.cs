using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Models
{
    /// <summary>
    /// 用户类，继承IdentityUser
    /// IdentityUser类只提供对用户基本信息的访问（用户名/Email/电话/哈希口令/角色成员）
    /// 所以如果需要添加附加属性，需要在ApplicationUser进行添加
    /// </summary>
    public class ApplicationUser:IdentityUser
    {
        // 附加属性可以在此编辑
    }
}