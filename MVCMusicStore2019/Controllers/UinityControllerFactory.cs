using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace MVCMusicStore2019.Controllers
{
    /// <summary>
    /// 自定义Unity控制器工厂
    /// </summary>
    public class UinityControllerFactory : DefaultControllerFactory
    {
        //Unity容器，IUnityContainer：
        public IUnityContainer UnityContainer { get; private set; }
        public UinityControllerFactory(IUnityContainer unityContainer)
        {
            this.UnityContainer = unityContainer;
        }
        /// <summary>
        /// 根据上下文和控制器类型进行控制器实例化
        /// </summary>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (null == controllerType)
            {
                return null;
            }
            //Resolve指定解析默认对象
            //以下解析方式得到实例化对象
            return (IController)this.UnityContainer.Resolve(controllerType);
        }
    }
}