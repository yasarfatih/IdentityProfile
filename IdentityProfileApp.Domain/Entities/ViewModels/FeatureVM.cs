using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class FeatureVM
    {
        public Characteristics Characteristic { get; set; }
        public string Body { get; set; }
        public int? Order { get; set; }
    }
}
