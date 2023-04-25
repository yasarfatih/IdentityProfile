using IdentityProfileApp.Domain.Entities.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class User : BaseModel
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
        [Display(Name = "Şifre"), Required(ErrorMessage = "Şifre alanı gereklidir")]
        [StringLength(1000000000, ErrorMessage = "{0} alanı minimum {2} karakterden oluşmalıdır", MinimumLength = 6)]
        public string Password { get; set; }
        [Display(Name = "Cinsiyet"), Required(ErrorMessage = "Cinsiyet alanı gereklidir")]
        public Gender Gender { get; set; }
        [Display(Name = "Email Doğrulandı Mı")]

        public string Image { get; set; }
        public bool EmaiIsVerified { get; set; }

        public virtual ICollection<UserInRole> UserRoles { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }

        public virtual ICollection<UserDiscount> UserDiscounts { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual Setting Setting { get; set; }

        public User()
        {
            UserRoles = new HashSet<UserInRole>();
            UserProfiles = new HashSet<UserProfile>();
            UserDiscounts = new HashSet<UserDiscount>();
            Articles = new HashSet<Article>();
            EmaiIsVerified = false;
            Image = SetAvatarImageFromGender(this.Gender);
        }

        public string SetAvatarImageFromGender(Gender gender)
        {
            if (gender == Gender.Female)
                return @"~\Content\images\Avatar\Male.jpg";
            else
                return @"~\Content\images\Avatar\Female.jpg";
        }
    }
}
