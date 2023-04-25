using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Category:BaseModel
    {
        public string CategoryName { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
