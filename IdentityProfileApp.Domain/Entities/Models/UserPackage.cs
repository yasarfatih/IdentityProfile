using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class UserPackage : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid PackageId { get; set; }
        [Display(Name = "Sona Erme Tarihi")]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "Tekrar Ediyormu")]
        public bool IsRepeat { get; set; }
        [ForeignKey("PackageId")]
        public PaymentPackage Package { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public UserPackage()
        {
            IsRepeat = true;
        }
    }
}
