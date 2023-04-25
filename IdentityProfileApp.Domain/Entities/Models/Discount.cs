using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Discount:BaseModel
    {
        [Display(Name = "İndirim Tipi"), Range(1, int.MaxValue, ErrorMessage = "Lütfen İndirim Tipi Giriniz")]
        public DiscountType DiscountType { get; set; }
        [Display(Name = "Yüzde Miktar")]
        public double Amount { get; set; }
        [Display(Name = "Başlangıç Zamanı")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Bitiş Zamanı")]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<UserDiscount> UserDiscounts { get; set; }
    }
}
