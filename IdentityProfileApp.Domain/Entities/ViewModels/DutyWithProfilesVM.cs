using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class DutyWithProfilesVM
    {
        public Duty Duty { get; set; }
        public List<Guid> Profiles { get; set; }
    }
}
