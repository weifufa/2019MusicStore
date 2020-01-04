using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        MusicDbContext db = new MusicDbContext();
        /// <summary>
        /// 实现根据传入的UserId，获取他的角色组，用户名，Email,Phone
        /// </summary>
        /// <returns></returns>
        /// 
        public IHttpActionResult GetUser(string id)
        {
            var user = db.Users.Find(id);
            var userrole = db.Users.Find(id).Roles.First();
            var role = db.Roles.Find(userrole.RoleId);
            UserInfo entity = new UserInfo()
            {
                RoleName = role.Name,
                UserName = user.UserName,
                Phone = user.PhoneNumber,
                Email = user.Email

            };
            return Ok(entity);
        }
        //public IEnumerable<ApplicationUser>GetUser()
        //{
        //    return db.Users;
        //}
        //// GET: api/User/5
        //public IHttpActionResult Get(string id)
        //{
        //    ApplicationUser entity = db.Users.Find(id);
        //        if(entity!=null)
        //    {
        //        return Ok(entity);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //    var User = db.Users.Find(id).Roles;
        //    //return Get(User);
        //}
        public class UserInfo
        {
            public string RoleName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }

    }
}
