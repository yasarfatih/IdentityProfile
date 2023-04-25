using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Article : BaseModel
    {
        [Display(Name = "Başlık"), StringLength(100, ErrorMessage = "Başlık 100 karakterden fazla olamaz")]
        public string Header { get; set; }

        [Display(Name = "Özet"), StringLength(100, ErrorMessage = "Özet bilgisi en fazla 400 karakter olmalıdır"), Required]
        public string Summary { get; set; }

        [Display(Name = "Makale")]
        public string Body { get; set; }
        [Display(Name = "Kaynakça")]
        public string Footer { get; set; }

        [Display(Name = "Yayına Geçti")]
        public bool IsPublished { get; set; }
        [Display(Name = "Yayına Geçiş Tarihi")]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Display(Name = "Video Kaynağı")]
        public string VideoSource { get; set; }
        public MediaType MediaType { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "Kategori")]
        public Guid CategoryId { get; set; }

        [ForeignKey("UserId")]
        public User Author { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public Article()
        {
            IsPublished = false;
            PublishDate = new DateTime(2000,5,17);
        }
    }
}
