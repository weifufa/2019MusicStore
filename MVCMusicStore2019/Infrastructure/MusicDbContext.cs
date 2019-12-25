using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Models.MusicStores;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMusicStore2019.Infrastructure
{
    /// <summary>
    /// EF数据库上下文类
    /// 可以通过Context实现Code First进行DB的创建和管理
    /// </summary>
    public class MusicDbContext: IdentityDbContext<ApplicationUser>
    {
        public MusicDbContext() : base("MusicDB") { }
        //定义项目数据上下文，实现DbSet和实体类关系映射
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<AlbumType> AlbumTypes { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PopularHotList> PopularHotLists { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        //通过Database.SetInitializer方法指定一个种子数据库类，IdentityDbInit种子类
        static MusicDbContext()
        {
            Database.SetInitializer<MusicDbContext>(new IdentityDbInit());
        }
        /// <summary>
        /// 由OWIN使用的类进行Create
        /// </summary>
        /// <returns></returns>
        public static MusicDbContext Create()
        {
            return new MusicDbContext();
        }
    }
    public class IdentityDbInit
        : DropCreateDatabaseIfModelChanges<MusicDbContext>
    {

        protected override void Seed(MusicDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(MusicDbContext context)
        {
            // initial configuration will go here
            // 初始化配置将放在这儿
            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationRoleManager roleMgr = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "Secret666";
            string email = "admin@lzzy.net";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new ApplicationRole(roleName));
            }

            ApplicationUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new ApplicationUser { UserName = userName, Email = email },
                    password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
        }
    }
}