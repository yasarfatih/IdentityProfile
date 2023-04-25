using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index(int? page)
        {
            var entities = new IdentityProfileAppContext();
            var articles = entities.Article.Include("Category").Where(a => a.IsPublished).OrderBy(x => x.PublishDate).ToPagedList(page ?? 1, 2);
            return View(articles);
        }
        public ActionResult Detail(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var articleInDb = entities.Article.Where(a => a.Id == id).Include(a => a.Comments).SingleOrDefault();

            var commentsInDb = entities.Comment.Where(c => c.ArticleId == articleInDb.Id).ToList();
            if (articleInDb == null)
            {
                TempData["error"] = "Aradığınız makale ile ilgili bir sorun oluştu.";
                return RedirectToAction(nameof(Index));
            }
            var articleWithComment = new ArticleWithCommentVM()
            {
                Article = articleInDb,
                Comments = commentsInDb,
            };

            return View(articleWithComment);
        }
        public ActionResult GetComments(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var comments = entities.Comment.Where(c => c.ArticleId == id).ToList();
            if (comments == null)
            {
                return Json(
                new
                {
                    Status = "emty",
                    Message = "Bu kategoride bir paylaşım bulunamadı"
                });
            }
            return Json(new
            {
                Status = "ok",
                Message = comments
            });
        }
        public ActionResult AddComment(string comment, string articleId)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                TempData["error"] = "Giriş yapınız";
                return View();
            }
            var artcId = Guid.Parse(articleId);
            var entities = new IdentityProfileAppContext();
            Comment cmd = new Comment();

            cmd.Id = Guid.NewGuid();
            cmd.ArticleId = artcId;
            cmd.CreateDate = DateTime.Now;
            cmd.LastUpdate = DateTime.Now;
            cmd.CommentId = Guid.Empty;
            cmd.Message = comment;
            cmd.UserId = entities.User.Where(u => u.EmailAdress == User.Identity.Name).SingleOrDefault().Id;

            entities.Comment.Add(cmd);
            entities.SaveChanges();
            return RedirectToAction("Detail", new { id = artcId });

        }
        public ActionResult AddReply(string reply, string articleId, string commentId)
        {
            if (string.IsNullOrEmpty(User.Identity.Name))
            {
                TempData["error"] = "Giriş yapınız";
                return View();
            }
            var artcId = Guid.Parse(articleId);
            var cmdId = Guid.Parse(commentId);
            var entities = new IdentityProfileAppContext();
            Comment cmd = new Comment();

            cmd.Id = Guid.NewGuid();
            cmd.ArticleId = artcId;
            cmd.CreateDate = DateTime.Now;
            cmd.LastUpdate = DateTime.Now;
            cmd.Message = reply;
            cmd.CommentId = cmdId;
            cmd.UserId = entities.User.Where(u => u.EmailAdress == User.Identity.Name).SingleOrDefault().Id;

            entities.Comment.Add(cmd);
            entities.SaveChanges();
            return RedirectToAction("Detail", new { id = artcId, lang = HttpContext.Request.Cookies.Get("Language").Value });

        }
    }
}