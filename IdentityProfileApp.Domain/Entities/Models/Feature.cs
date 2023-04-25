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
    public class Feature
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Characteristics Characteristic { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Bu alan gereklidir")]
        public string Body { get; set; }
        public string Image { get; set; }
        public Guid ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
        public int Order { get; set; }
    }
}
