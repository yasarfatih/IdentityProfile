using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Comment:BaseModel
    {
        public string  Message { get; set; }
        public Guid UserId { get; set; }
        public Guid ArticleId { get; set; }

        public Guid CommentId { get; set; }

        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        public Comment()
        {
            CommentId = Guid.Empty;
        }

    }
}
