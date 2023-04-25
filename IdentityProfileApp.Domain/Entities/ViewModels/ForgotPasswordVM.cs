using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class ForgotPasswordVM
    {
        [Display(Name ="Email Adres")]
        public string Email { get; set; }
    }
}
