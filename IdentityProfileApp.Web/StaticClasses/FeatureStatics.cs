using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProfileApp.Web.StaticClasses
{
    public class FeatureStatics
    {
        public static List<Feature> CreateFeatures(Guid guid)
        {
            List<Feature> features = new List<Feature>();
            foreach (Characteristics characteristic in (Characteristics[])Enum.GetValues(typeof(Characteristics)))
            {
                features.Add(new Feature() { Characteristic = characteristic, ProfileId = guid });
            }
            return features;
        }
    }
}