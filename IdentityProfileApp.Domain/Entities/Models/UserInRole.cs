using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class UserInRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
