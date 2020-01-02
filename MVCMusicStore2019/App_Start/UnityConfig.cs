using MVCMusicStore2019.Infrastructure;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.Models.MusicStores;
using MVCMusicStore2019.Repository;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace MVCMusicStore2019
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// 配置Unity容器
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
        /// <summary>
        /// 数据上下文、组件注册
        /// </summary>
        public static void RegisterComponents()
        {
            UnityContainer unityContainer = new UnityContainer();//新建Unity容器
            unityContainer.RegisterType<DbContext, MusicDbContext>();//在容器中实现数据上下文关系映射

            //#region 在Unity容器中注册接口及接口实现类之间的关系映射
            unityContainer.RegisterType<IEntityRepository<Genre>, EntityRepository<Genre>>();
            unityContainer.RegisterType<IEntityRepository<Artist>, EntityRepository<Artist>>();
            unityContainer.RegisterType<IEntityRepository<Album>, EntityRepository<Album>>();
            unityContainer.RegisterType<IEntityRepository<AlbumType>, EntityRepository<AlbumType>>();
            unityContainer.RegisterType<IEntityRepository<PopularHotList>, EntityRepository<PopularHotList>>();
            unityContainer.RegisterType<IShoppingCartService,ShoppingCartService>(); //购物车容器注册
            //unityContainer.RegisterType<IOrderService, OrderService>();
            //#endregion

            //MVC控制器和类注入解析
            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}