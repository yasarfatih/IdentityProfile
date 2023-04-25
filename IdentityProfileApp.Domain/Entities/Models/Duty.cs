using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Duty : BaseModel
    {
        [Display(Name = "Başlık"), Required(ErrorMessage = "Başlık Gereklidir")]
        public string Header { get; set; }
        [Display(Name = "Görev Metni"), Required(ErrorMessage = "Görev Metni Gereklidir")]
        public string Body { get; set; }
        [Display(Name = "Süre"),Required(ErrorMessage ="Süre Gereklidir")]
        public double Duration { get; set; }
        [Display(Name = "Zaman Ölçütü"), Required(ErrorMessage = "Zaman Ölçütü Gereklidir")]
        public TimeUnit TimeUnit { get; set; }
        public virtual ICollection<ProfileDuty> ProfileDuties { get; set; }
    }
}
