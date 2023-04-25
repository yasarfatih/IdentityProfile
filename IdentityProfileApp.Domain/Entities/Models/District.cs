using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "İlçe"), StringLength(20)]
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
