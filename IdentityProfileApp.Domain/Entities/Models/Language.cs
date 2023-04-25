using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Display(Name = "Kodu"), StringLength(25)]
        [Index("NDX_LANGUAGE_00", 1, IsUnique = true)]
        public string ResourceCode { get; set; }

        [Display(Name = "Adı"), StringLength(50)]
        public string ResourceName { get; set; }

        public virtual ICollection<LanguageResource> LanguageDefinitions { get; set; }
        public override string ToString()
        {
            return ResourceName;
        }

        public Language()
        {
            ResourceCode = "";
            ResourceName = "";
            LanguageDefinitions = new HashSet<LanguageResource>();
        }
    }
}
