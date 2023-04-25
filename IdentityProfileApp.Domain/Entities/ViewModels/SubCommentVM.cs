using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class SubCommentVM
    {
        public User Replier { get; set; }

        public User Replied { get; set; }
        public Comment Comment { get; set; }
    }
}
