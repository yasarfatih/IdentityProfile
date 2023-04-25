using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.Extensions;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class ProfileFeatureVM
    {
        public Profile Profile { get; set; }
        public List<FeatureVM> Features { get; set; }

        public ProfileFeatureVM()
        {
            Features = new List<FeatureVM>();
            foreach (Characteristics characteristic in (Characteristics[])Enum.GetValues(typeof(Characteristics)))
            {
                Features.Add(new FeatureVM { Characteristic = characteristic, Order = characteristic.GetOrder() });
            }
        }
    }
}
