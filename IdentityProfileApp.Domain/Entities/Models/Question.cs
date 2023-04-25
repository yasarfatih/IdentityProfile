using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Question : BaseModel
    {
        [Display(Name ="Soru Metni")]
        public string Body { get; set; }
        public int QuestionGroupId { get; set; }
        public ProfileParts AgreePart { get; set; }
        public ProfileParts DisagreePart { get; set; }
        public Question()
        {
            QuestionGroupId = 1;
        }

    }
}
