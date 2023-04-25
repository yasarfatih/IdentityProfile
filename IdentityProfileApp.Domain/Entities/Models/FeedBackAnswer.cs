using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class FeedBackAnswer : BaseModel
    {
        [Display(Name = "Cevap")]
        public string Body { get; set; }
        [ForeignKey("Question")]
        public Guid FeedBackQuestionId { get; set; }
        public int Order { get; set; }
        public FeedBackQuestion Question { get; set; }
    }
}
