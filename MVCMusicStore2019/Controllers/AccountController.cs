using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCMusicStore2019.Models;
using MVCMusicStore2019.ViewModels;
using MVCMusicStore2019.Infrastructure;

namespace MVCMusicStore2019.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "访问被拒绝。" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginViewModel details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //检查用户登录凭据
                ApplicationUser user = await UserManager.FindAsync(details.Name, details.Password);
                if (user == null)
                {
                    //非法凭据，FindAsync方法将返回null空值，系统报错
                    ModelState.AddModelError("", "无效的用户名和密码。");
                }
                else
                {
                    //合法凭据，建立验证的Cookie。ClaimsIdentity实例——角色授权（IIdentity接口的ASP.NET Identity实现
                    //Claims：声明
                    ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();//用户注销，让用户Cookie实现
                    //用户登入，创建用户Cookie认证请求
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        //通过将IsPersistent属性设定为true，使认证Cookie在浏览器中得以持久化（用户新会话时，不必在此认证）
                        IsPersistent = false
                    }, ident);
                    return Redirect(returnUrl);
                }
            }
            return View(details);
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 凭据管理类实例
        /// </summary>
        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }
}