using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.DTO
{
    public class StatisticResult
    {
        public ProfileParts Part { get; set; }
        public double Value { get; set; }
        public ProfileParts OppositePart { get; set; }
        public Color Color { get; set; }
    }
}
