using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.DTO
{
    public class BlogModel
    {
        public List<Article> Articles { get; set; }
        public MediaType MediaType { get; set; }

        public int index { get; set; }
    }
}
