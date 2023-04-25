using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class ArticleWithCommentVM
    {
        public Article Article { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
