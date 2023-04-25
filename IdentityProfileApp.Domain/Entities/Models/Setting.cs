using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProfileApp.Domain.Entities.Models
{

    public class Setting
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public bool ProfileSetting { get; set; }
        public virtual User User { get; set; }
    }
}