using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class QuestionGroup
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Soru Grup Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
