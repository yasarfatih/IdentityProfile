using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProfileApp.Web.BLL
{
    public class ArticleBLL
    {
        public enum ArticleType
        {
            Previous,
            Next
        }
        public static Article GetArticle(Article article, ArticleType articleType)
        {
            var entities = new IdentityProfileAppContext();
            var articlesInDb = entities.Article.Where(a => a.Id != article.Id).ToList();

            return articleType == ArticleType.Next ? articlesInDb.Where(a => a.CreateDate >= article.CreateDate).OrderBy(a => a.CreateDate).FirstOrDefault() : articlesInDb.Where(a => a.CreateDate <= article.CreateDate).OrderByDescending(a => a.CreateDate).FirstOrDefault();

        }

        public static List<Category> GetCategories()
        {
            var entities = new IdentityProfileAppContext();
            return entities.Category.ToList();
        }
        public static Category GetCategoryById(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            return entities.Category.Where(c => c.Id == id).SingleOrDefault();
        }

        public static User GetUserById(Guid id)
        {
            var entities = new IdentityProfileAppContext();

            return entities.User.Where(c => c.Id == id).SingleOrDefault();
        }
        public static User GetUserByCommentId(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var userId = entities.Comment.FirstOrDefault(c => c.Id == id).UserId;
            return entities.User.FirstOrDefault(u => u.Id == userId);
        }

        public static string GetUserNameByCommentId(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var comment = entities.Comment.Where(c => c.Id == id).FirstOrDefault();
            var user = entities.User.Where(c => c.Id == comment.UserId).SingleOrDefault();
            return string.Format("{0} {1}", user.Name, user.Surname);
        }

        public static List<Comment> GetSubComments(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            return entities.Comment.OrderByDescending(x => x.CreateDate).Where(c => c.CommentId == id).ToList();
        }
        public static bool SubCommentsExist(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            return entities.Comment.Where(c => c.CommentId == id).Count() > 0;
        }
        public static List<Article> GetLatestArticles(int count)
        {
            var entities = new IdentityProfileAppContext();
            return entities.Article.Include("Category").OrderBy(x => x.PublishDate).Take(count).ToList();
        }
        public static List<Article> GetPopularArticles(int count)
        {
            var entities = new IdentityProfileAppContext();
            return entities.Article.Include("Category").Include("Comments").OrderByDescending(x => x.Comments.Count).Take(count).ToList();
        }
    }
}