using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class UserDiscount : BaseModel
    {
        [Display(Name = "Kullanıcı"), Required(ErrorMessage = "Kullanıcı alanı gereklidir")]
        public Guid UserId { get; set; }
        public Guid DiscountId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }
    }
}
