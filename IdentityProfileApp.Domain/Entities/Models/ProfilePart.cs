using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class ProfilePart:BaseModel
    {
        public ProfileParts Part { get; set; }
        public ProfileParts OppositePart { get; set; }  
    }
}
