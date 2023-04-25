using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Şehir"), StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
