using MyBlogSite.DTO;
using MyBlogSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.Panel.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            if (Session["loginuser"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            using (BlogService service=new BlogService())
            {
                var result = service.GetBlogs();
                return View(result);
            }
            
        }
        public ActionResult Save()
        {
            if (Session["loginuser"]==null)
            {
                return RedirectToAction("Index","Account");
            }

            ViewBag.UserId = (Session["loginuser"] as UserDTO).UserId;

            using (CategoryService service=new CategoryService())
            {
                ViewBag.Categories = service.GetCategories();
                return View();
            }
        }


        [HttpPost]
        public JsonResult Save(BlogDTO obj)
        {
            using (BlogService service=new BlogService())
            {
                obj.UserId = (Session["loginuser"] as UserDTO).UserId;
                obj.ImagePath = "";

                var result = service.Save(obj);

                if (result>0)
                {
                    return Json(true,JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);

                }
            }
        }

        public ActionResult Get(int id)
        {
            using (BlogService service=new BlogService())
            {
                var result = service.Get(id);
                if (result!=null)
                {
                    return View(result);
                }
                else
                {
                    ViewBag.ErrorMessage = "Kayıt getirirken bir hata oluştu";
                    return View();
                }
            }
        }


        /// <summary>
        /// Edit e gönnderilecek veriler tanımlandı
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            if (Session["loginuser"]==null)
            {
                return RedirectToAction("Index", "Account");
            }

            using (CategoryService categoryService=new CategoryService())
            {
                ViewBag.Categories = categoryService.GetCategories();
            }
            using (DefinitionService definitionService=new DefinitionService())
            {
                ViewBag.RecordStatuses = definitionService.GetRecordStatuses();
                ///ViewBag ile Controllerdan veriler gönderiliyor
            }
            using (BlogService blogService=new BlogService())
            {
                var result = blogService.Get(id);
                return View(result);
            }
        }

        /// <summary>
        /// Editten alınacak veriler
        /// </summary>
        [HttpPost]
        public JsonResult Edit(BlogDTO obj)
        {
            using (BlogService service=new BlogService())
            {
                obj.ImagePath = "";
                var result = service.Update(obj);
                return Json(result);
            }
        }

        public ActionResult CommentEdit(int id)
        {
            if (Session["loginuser"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            using (CommentService service = new CommentService())
            {
                var result = service.GetComments(id);

                return View(result);
            }
        }


        public ActionResult ConfirmCommentEdit(int id)
        {
            //if (Session["loginuser"] == null)
            //{
            //    return RedirectToAction("Index", "Account");
            //}
            using (CommentService service = new CommentService())
            {
                var result = service.GetConfirmed(id);

                return View(result);
            }
        }

        [HttpPost]
        public JsonResult ConfirmCommentEdit(CommentDTO comment)
        {
            using (CommentService service = new CommentService())
            {
                var result = service.GetConfirmed(comment.CommentId);
                return Json(result);
            }

        }
    }
}