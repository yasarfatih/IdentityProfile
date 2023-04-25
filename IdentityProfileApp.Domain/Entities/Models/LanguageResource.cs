using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class LanguageResource
    {
        public int Id { get; set; }
        [Display(Name = "Kaynak Numarası", Description = "Kaynak Numarası"), StringLength(25)]
        [Index("NDX_RESOURCEDEFINITION_00", 1, IsUnique = true)]
        public string ResourceNo { get; set; }

        public string Body { get; set; }
        [Index("NDX_RESOURCEDEFINITION_00", 2, IsUnique = true)]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public LanguageResource()
        {
            ResourceNo = "";
            Body = "";
        }
    }
}
