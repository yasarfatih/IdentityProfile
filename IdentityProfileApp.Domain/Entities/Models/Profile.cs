using IdentityProfileApp.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProfileApp.Domain.Entities.Models
{
    public class Profile : BaseModel
    {

        private string name;
        [Display(Name = "Profil Adı"), StringLength(5, ErrorMessage = "İsim alanı en fazla 5 karakter olabilir")]
        public string Name
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (Enum.IsDefined(typeof(ProfileParts), Part1)&&Enum.IsDefined(typeof(ProfileParts), Part2)&&Enum.IsDefined(typeof(ProfileParts), Part3)&&Enum.IsDefined(typeof(ProfileParts), Part4))
                {
                    sb.Append(Enum.GetValues(typeof(ProfileParts)).GetValue(((int)Part1) - 1).ToString());
                    sb.Append(Enum.GetValues(typeof(ProfileParts)).GetValue(((int)Part2) - 1).ToString());
                    sb.Append(Enum.GetValues(typeof(ProfileParts)).GetValue(((int)Part3) - 1).ToString());
                    sb.Append(Enum.GetValues(typeof(ProfileParts)).GetValue(((int)Part4) - 1).ToString());
                    name = sb.ToString();
                }
                else
                {
                    name = "";
                }
                return name;
            }
            set
            {
                name = value;
            }
        }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Part 1"), Required, Range(1, 8, ErrorMessage = "part 1 seçiniz")]
        public ProfileParts Part1 { get; set; }
        [Display(Name = "Part 2"), Required, Range(1, 8, ErrorMessage = "part 2 seçiniz")]
        public ProfileParts Part2 { get; set; }
        [Display(Name = "Part 3"), Required, Range(1, 8, ErrorMessage = "part 3 seçiniz")]
        public ProfileParts Part3 { get; set; }
        [Display(Name = "Part 4"), Required, Range(1, 8, ErrorMessage = "part 4 seçiniz")]
        public ProfileParts Part4 { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<ProfileDuty> ProfileDuties { get; set; }


        public Profile()
        {
            this.Features = new HashSet<Feature>();
            this.UserProfiles = new HashSet<UserProfile>();
            this.ProfileDuties = new HashSet<ProfileDuty>();
        }
    }
}
