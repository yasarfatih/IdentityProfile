using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class UserSettingVM
    {
        [Display(Name = "İsim"), StringLength(25, ErrorMessage = "Soyisim en fazla 25 karakter olabilir"), Required(ErrorMessage = "İsim alanı gereklidir")]
        public string Name { get; set; }
        [Display(Name = "Soyisim"), StringLength(25, ErrorMessage = "Soyisim en fazla 25 karakter olabilir"), Required(ErrorMessage = "Soyisim alanı gereklidir")]
        public string Surname { get; set; }

        //[Display(Name = "Kullanıcı Adı"), StringLength(20, ErrorMessage = "Kullanıcı Adı en fazla 20 karakter olabilir")]
        //public string UserName { get; set; }

        [Display(Name = "Telefon Numarası"), StringLength(20, ErrorMessage = "Kullanıcı Adı en fazla 20 karakter olabilir")]
        public string MobileTelNo { get; set; }
        [Display(Name = "E-Mail Adres"), Required(ErrorMessage = "Email Alanı Gereklidir")]
        public string EmailAdress { get; set; }
        [Display(Name = "Şehir")]
        public int CityId { get; set; }
        [Display(Name = "İlçe"), Range(0, double.MaxValue, ErrorMessage = "İlçe Seçimi Yapınız")]
        public int DistrictId { get; set; }
    }
}
