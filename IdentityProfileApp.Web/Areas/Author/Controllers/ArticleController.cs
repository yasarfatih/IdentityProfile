using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using IdentityProfileApp.Utils.Extensions;
using IdentityProfileApp.Web.StaticClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Areas.Author.Controllers
{
    [Authorize(Roles = "Admin,Author")]
    public class ArticleController : BaseController
    {
        // GET: Author/Article
        public ActionResult Create()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            IQueryable<SelectListItem> categories = entities.Category.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            });
            TempData["categories"] = categories;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Author")]
        [ValidateInput(false)]
        public ActionResult Create(ArticleWithImage model)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            HttpPostedFileBase file = model.PostedImage == null ? null : model.PostedImage;

            model.Article.MediaType = MediaType.Video;
            if (string.IsNullOrEmpty(model.Article.VideoSource))
            {
                if (file == null)
                {
                    TempData["error"] = "Hem video source hem de fotoğraf boş olamaz";
                    return View(model);
                }

                Tuple<string, string> tuple = UploadOperations.UploadImage(file, Request.Form, "/Content/Article/", model.PostedImage.FileName);
                if (!string.IsNullOrEmpty(tuple.Item1))
                {
                    TempData["error"] = tuple.Item1;
                    return View(model);
                }
                model.Article.Image = tuple.Item2;
                model.Article.MediaType = MediaType.Image;
            }


            model.Article.Id = Guid.NewGuid();
            model.Article.UserId = entities.User.FirstOrDefault(x => x.EmailAdress == User.Identity.Name).Id;
            entities.Article.Add(model.Article);
            entities.SaveChanges();
            TempData["success"] = "Makale başarıyla eklendi";
            return RedirectToAction("List");

        }
        [Authorize(Roles = "Admin,Author")]
        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            User user = entities.User.SingleOrDefault(x => x.EmailAdress == User.Identity.Name);
            List<Article> articles = entities.Article.Where(ar => ar.UserId == user.Id).ToList();
            return View(articles);
        }
        [Authorize(Roles = "Admin,Author")]
        public ActionResult PublishSwitch(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            Article article = entities.Article.SingleOrDefault(ar => ar.Id == id);
            if (article == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir makale bulunamadı."
                });
            }
            article.IsPublished = !article.IsPublished;
            if (article.IsPublished)
            {
                article.PublishDate = DateTime.Now;
            }
            else
            {
                article.PublishDate = new DateTime(2000, 5, 17);
            }

            article.LastUpdate = DateTime.Now;
            entities.SaveChanges();

            return Json(new
            {
                Status = "ok",
                Message = article.IsPublished == true ? "Makale başarılı bir şekilde yayınlandı" : "Makale başarılı bir şekilde yayından kaldırıldı"
            });
        }


        public ActionResult Delete(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            Article articleInDb = entities.Article.SingleOrDefault(c => c.Id == id);
            if (articleInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı."
                });
            }

            string filePath = Server.MapPath("~/Content/Article/Image/" + articleInDb.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            string thumbPath = Server.MapPath("~/Content/Article/thumb/" + articleInDb.Image);
            if (System.IO.File.Exists(thumbPath))
            {
                System.IO.File.Delete(thumbPath);
            }

            entities.Article.Remove(articleInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Makale başarıyla silindi"
            });
        }


        public ActionResult Update(Guid id)
        {
            ViewBag.Title = "Makale Güncelle";
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            Article article = entities.Article.SingleOrDefault(ar => ar.Id == id);
            if (article == null)
            {
                TempData["error"] = "Belirtilen kriterlere ait bir nakale bulunamadı";
                return View();
            }
            IQueryable<SelectListItem> categories = entities.Category.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            });
            TempData["categories"] = categories;
            ArticleWithImage articleWithImage = new ArticleWithImage();
            articleWithImage.Article = article;
            return View(articleWithImage);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(ArticleWithImage model)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            Article articleInDb = entities.Article.SingleOrDefault(q => q.Id == model.Article.Id);
            if (articleInDb == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir makale bulunamadı";
                return RedirectToAction("List");
            }

            if (model.PostedImage != null)
            {
                //Kırpılmış resmi elde edelim ve sunucuya kaydedelim
                Image croppedImage = model.PostedImage.CropImage(Request.Form);
                string newFileName = model.PostedImage.FileName.GenerateFileName();
                string filePath = Server.MapPath("~/Content/Article/Image/" + newFileName);
                //yeni resim sunucuya kaydediliyor.
                croppedImage.Save(filePath);

                Image thumbImage = croppedImage.GetThumbnailImage(105, 70);
                string thumbFilePath = Server.MapPath("~/Content/Article/thumb/" + newFileName);
                //yeni resim dosyasına verilen isim modelde yer alan FileName özelliğine yükleniyor.
                model.Article.Image = newFileName;
                //eski resmi sil
                string oldFilePath = Server.MapPath("~/Content/Article/Image/" + articleInDb.Image);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }

                string oldThumbPath = Server.MapPath("~/Content/Article/thumb/" + articleInDb.Image);
                if (System.IO.File.Exists(oldThumbPath))
                {
                    System.IO.File.Delete(oldThumbPath);
                }
            }
            articleInDb.VideoSource = model.Article.VideoSource;
            articleInDb.Body = model.Article.Body;
            articleInDb.Image = model.Article.Image;
            articleInDb.Summary = model.Article.Summary;
            //to do
            articleInDb.Header = model.Article.Header;
            articleInDb.Footer = model.Article.Footer;
            entities.SaveChanges();
            return RedirectToAction("List");
        }
    }
}