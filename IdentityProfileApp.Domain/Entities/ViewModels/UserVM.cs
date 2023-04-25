using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class UserVM
    {
        public User User { get; set; }
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
        public List<RoleCheckBoxModel> UserRoles { get; set; }

        [UIHint("ImageUpload1")]
        public HttpPostedFileBase PostedImage { get; set; }
        public UserVM()
        {
            UserRoles = new List<RoleCheckBoxModel>();
        }

    }
}
