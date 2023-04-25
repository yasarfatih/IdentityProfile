using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class QuestionAnswerVM
    {
        public Question Question { get; set; }
        public Answers Answers { get; set; }
    }
}
