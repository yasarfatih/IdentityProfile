using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.DTO
{
    public class ProfileResult
    {
        public ProfileParts Part { get; set; }
        public double Value { get; set; }
        public int StatisticResult { get; set; }

    }
}
