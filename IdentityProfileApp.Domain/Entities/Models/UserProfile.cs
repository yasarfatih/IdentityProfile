using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class UserProfile : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        public DateTime TestTime { get; set; }
        public string Stats { get; set; }

        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        
    }
}
