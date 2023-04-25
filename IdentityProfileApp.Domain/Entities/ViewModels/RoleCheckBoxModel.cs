using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class RoleCheckBoxModel
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
    }
}
