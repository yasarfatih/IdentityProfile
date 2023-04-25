using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class FeedBackQuestion:BaseModel
    {
        [Display(Name = "Soru")]
        public string Body { get; set; }

        public virtual ICollection<FeedBackAnswer> Answers { get; set; }
    }
}
