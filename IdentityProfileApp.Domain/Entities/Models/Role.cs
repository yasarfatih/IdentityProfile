using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(20, ErrorMessage = "Rol adı en fazla 20 karakter olabilir")]
        public string Name { get; set; }

        public virtual ICollection<UserInRole> UserRoles { get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserInRole>();
        }
    }
}
