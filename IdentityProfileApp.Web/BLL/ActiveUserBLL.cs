using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityProfileApp.Web.BLL
{
    public class ActiveUserBLL
    {
        public static IdentityProfileAppContext entites = new IdentityProfileAppContext();
        public static User GetUser(string activeUser)
        {
            return entites.User.FirstOrDefault(u => u.EmailAdress == activeUser);
        }
        public static List<User> GetUserByEmail(string activeUser)
        {
            return entites.User.Where(u => u.EmailAdress == activeUser).ToList();
        }
        public static bool UserHasProfile(string activeUser)
        {
            var user = entites.User.Include("UserProfiles").FirstOrDefault(u => u.EmailAdress == activeUser);
            return user.UserProfiles.Count > 0;
        }
        public static Profile GetUserProfile(Guid id)
        {
            return entites.UserProfile.Include("Profile").FirstOrDefault(x => x.UserId == id).Profile;
        }

        public static bool CheckEmail(string email)
        {
            return entites.User.Any(x => x.EmailAdress == email);
        }

    }
}