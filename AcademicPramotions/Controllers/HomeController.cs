using AcademicPramotions.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AcademicPramotions.Controllers
{
    public class HomeController : Controller
    {
        #region "Unitofwork Reference"

        ILoginBO _loginBO = null;

        public HomeController(ILoginBO loginBO)
        {
            this._loginBO = loginBO;
        }
        public HomeController()
        {
            _loginBO = new LoginBO();
        }

        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            clearSession();
            return View("Index");
        }
        [HttpPost]
        public int ValidateLoginCredentials(string UserName, string Password)
        {
            
            FormsAuthentication.SetAuthCookie(UserName, false);
            var result = _loginBO.LoginUser(UserName, Password);
            if (result != null)
            {
                Session["RoleId"] = result.RoleId;
                if (result.RoleId == 2)
                {
                    var schoolId = _loginBO.getSchoolId(result.UserId);
                    Session["SchoolId"] = schoolId;
                }
                if (result.RoleId == 3)
                {
                    var sponsorId = _loginBO.getSponsorId(result.UserId);
                    Session["SponsorId"] = sponsorId;
                }
                return result.RoleId;
            }
            
            else
            {
                return 0;
            }
        }
        public ActionResult AdminDashBoard()
        {
            return View();
        }
        public ActionResult ErrorPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public void clearSession()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.AppendCacheExtension("no-store, must-revalidate");
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies.
            Response.ExpiresAbsolute = DateTime.UtcNow.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-Cache";
            Session.Abandon();
            FormsAuthentication.SignOut();
            Session.Clear();
        }
    }
}
