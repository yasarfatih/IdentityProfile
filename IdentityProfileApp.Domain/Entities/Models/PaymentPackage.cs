using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class PaymentPackage : BaseModel
    {
        [Display(Name = "Paket İsmi")]
        public string Name { get; set; }
        [Display(Name = "Ücret")]
        public double Price { get; set; }
        [Display(Name = "Döviz Cinsi")]
        [Range(1, int.MaxValue, ErrorMessage = "Kur Cinsi Alanı Gereklidir")]
        public CurrencyType Currency { get; set; }
        [Display(Name = "Ödeme Şekli")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen Ödeme Cinsi Giriniz")]
        public PaymentType PaymentType { get; set; }

        public virtual ICollection<UserPackage> UserPackages { get; set; }
    }
}