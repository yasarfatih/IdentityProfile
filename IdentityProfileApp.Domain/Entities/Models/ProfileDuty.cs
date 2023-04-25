using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class ProfileDuty : BaseModel
    {
        public Guid ProfileId { get; set; }
        public Guid DutyId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
        [ForeignKey("DutyId")]
        public Duty Duty { get; set; }
    }
}
