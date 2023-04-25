using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class LogError : BaseModel
    {
        [Column(TypeName = "varchar"), StringLength(30)]
        public string Controller { get; set; }
        [Column(TypeName = "varchar"), StringLength(30)]
        public string Action { get; set; }
        [Column(TypeName = "varchar")]
        public string Trace { get; set; }
        [Column(TypeName = "varchar")]
        public string Message { get; set; }

        public bool IsAjaxRequest { get; set; }
    }
}
