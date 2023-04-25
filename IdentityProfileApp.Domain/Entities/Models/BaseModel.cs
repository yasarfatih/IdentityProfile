using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public BaseModel()
        {
            CreateDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
    }
}
