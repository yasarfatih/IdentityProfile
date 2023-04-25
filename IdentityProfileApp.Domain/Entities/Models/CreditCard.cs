using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class CreditCard : BaseModel
    {
        [Display(Name ="İsim Soyisim"),StringLength(30, ErrorMessage = "İsim ve Soyisim bilgisi en fazla 30 karakter olabilir")]
        public string NameSurname { get; set; }
        [Display(Name = "Kart Numarası"), StringLength(16, ErrorMessage = "Kreadi kartı numarası en fazla 16 karakter olabilir")]
        public string CardNo { get; set; }
        [Display(Name = "SKT Ay")]
        public byte ExpireDateMonth { get; set; }
        [Display(Name = "SKT Yıl")]
        public byte ExpireDateYear { get; set; }
        [Display(Name = "CVC")]
        public int SecurityNumber { get; set; }
        public Guid UserId { get; set; }

    }
}
