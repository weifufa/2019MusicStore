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
        /// ����Unity����
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion
        /// <summary>
        /// ���������ġ����ע��
        /// </summary>
        public static void RegisterComponents()
        {
            UnityContainer unityContainer = new UnityContainer();//�½�Unity����
            unityContainer.RegisterType<DbContext, MusicDbContext>();//��������ʵ�����������Ĺ�ϵӳ��

            //#region ��Unity������ע��ӿڼ��ӿ�ʵ����֮��Ĺ�ϵӳ��
            unityContainer.RegisterType<IEntityRepository<Genre>, EntityRepository<Genre>>();
            unityContainer.RegisterType<IEntityRepository<Artist>, EntityRepository<Artist>>();
            unityContainer.RegisterType<IEntityRepository<Album>, EntityRepository<Album>>();
            unityContainer.RegisterType<IEntityRepository<AlbumType>, EntityRepository<AlbumType>>();
            unityContainer.RegisterType<IEntityRepository<PopularHotList>, EntityRepository<PopularHotList>>();
            unityContainer.RegisterType<IShoppingCartService,ShoppingCartService>(); //���ﳵ����ע��
            //unityContainer.RegisterType<IOrderService, OrderService>();
            //#endregion

            //MVC����������ע�����
            DependencyResolver.SetResolver(new UnityDependencyResolver(unityContainer));
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}