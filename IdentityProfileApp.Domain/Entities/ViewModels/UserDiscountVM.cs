using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.ViewModels
{
    public class UserDiscountVM
    {
        public UserDiscount UserDiscount { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
