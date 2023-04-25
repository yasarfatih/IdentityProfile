using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class RegisterVM
    {
        public User User { get; set; }
        [Display(Name ="Şifre Tekrar")]
        public string ConfirmPassword { get; set; }

    }
}
