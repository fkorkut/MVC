using MyBlogSite.Panel.Models;
using MyBlogSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.Panel.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["loginuser"]!=null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }


        //Viewden veriler geliyor:HttpPost
        //Viewe sonuçu ViewBag ile gösterebiliriz.
        [HttpPost]
        public ActionResult Index(LoginModel model )
        {
            using (UserService service=new UserService())
            {
                var user = service.Authenticate(model.UserName,model.Password);
                if (user==null)
                {
                    ViewBag.LoginResult = "Hatalı kullanıcı adı veya şifre";
                    return View();

                }
                else
                {
                    //session :oturum
                    Session["loginuser"] = user;
                    //SessionId
                    return RedirectToAction("Index","Account");   //doğruysa işlem yönlendirme yaptı

                }
            }
        }

        /// <summary>
        /// Çıkış
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Remove("loginuser") ;

            return RedirectToAction("Index","Account");
        }


        public ActionResult Verify(string Id)
        {
            using (UserService service=new UserService())
            {
                bool result = service.Verify(Id);
                return View();
            }
        }
    }
}